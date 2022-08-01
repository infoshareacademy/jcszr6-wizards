using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wizards.Core.Model;
using Wizards.Services.PlayerService;
using Wizards.Services.Validation.Elements;
using WizardsWeb.ModelViews;

namespace WizardsWeb.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;
        private readonly IMapper _mapper;
        private readonly UserManager<Player> _userManager;
        private readonly SignInManager<Player> _signInManager;


        public PlayerController(IPlayerService playerService, IMapper mapper, UserManager<Player> userManager, SignInManager<Player> signInManager)
        {
            _playerService = playerService;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: PlayerController  "LocalHost4449987/Details"
        public async Task<ActionResult> Details()
        {
            var playerId = Int32.Parse(_userManager.GetUserId(User));

            var player = await _playerService.Get(playerId);
            var playerDetails = _mapper.Map<PlayerDetailsModelView>(player);
            return View(playerDetails);
        }

        // GET: PlayerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlayerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PlayerCreateModelView playerCreate)
        {
            if (!ModelState.IsValid)
            {
                return View(playerCreate);
            }

            try
            {
                _userManager.Options.User.RequireUniqueEmail = true;
                _userManager.Options.User.AllowedUserNameCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890-_";
                _userManager.Options.Password.RequireDigit = true;
                _userManager.Options.Password.RequireLowercase = true;
                _userManager.Options.Password.RequireUppercase = true;
                _userManager.Options.Password.RequireNonAlphanumeric = true;
                _userManager.Options.Password.RequiredLength = 8;

                var user = new Player { UserName = playerCreate.UserName, Email = playerCreate.Email, DateOfBirth = playerCreate.DateOfBirth };
                
                var result = await _userManager.CreateAsync(user, playerCreate.Password);
                
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction(nameof(Details));
                }

                return View(playerCreate);
            }
            catch (InvalidModelException exception)
            {
                foreach (var data in exception.ModelStatesData)
                {
                    ModelState.AddModelError(data.Key, data.Value);
                }

                return View(playerCreate);
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(PlayerLogInModelView playerLogIn)
        {
            var result = await _signInManager.PasswordSignInAsync(playerLogIn.UserName, playerLogIn.Password, false, lockoutOnFailure: false);
            
            if (result.Succeeded)
            {
                return RedirectToAction("Details", "Player");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            
            return View(playerLogIn);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            
            return RedirectToAction(nameof(Index), "Home");
        }

        // GET: PlayerController/Edit/5
        public async Task<ActionResult> Edit()
        {
            var playerId = Int32.Parse(_userManager.GetUserId(User));
            var player = await _playerService.Get(playerId);
            var playerEdit = _mapper.Map<PlayerEditModelView>(player);
            return View(playerEdit);
        }

        // POST: PlayerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PlayerEditModelView playerEdit)
        {
            var originalPlayer = await _playerService.Get(playerEdit.Id);
            playerEdit.UserName = originalPlayer.UserName;

            if (!ModelState.IsValid)
            {
                return View(playerEdit);
            }

            var player = _mapper.Map<Player>(playerEdit);
            //player.Password = originalPlayer.Password;

            try
            {
                await _playerService.Update(player.Id, player);
                return RedirectToAction(nameof(Details), new { id = player.Id });
            }
            catch (InvalidModelException exception)
            {
                foreach (var data in exception.ModelStatesData)
                {
                    ModelState.AddModelError(data.Key, data.Value);
                }

                return View(playerEdit);
            }
        }

        // GET: PlayerController/EditPassword/5
        public async Task<ActionResult> EditPassword()
        {
            var playerId = Int32.Parse(_userManager.GetUserId(User));
            var player = await _playerService.Get(playerId);
            var passwordChage = _mapper.Map<PasswordChangeModelView>(player);
            return View(passwordChage);
        }

        // POST: PlayerController/EditPassword/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditPassword(PasswordChangeModelView passwordChange)
        {
            var originalPlayer = await _playerService.Get(passwordChange.Id);
            passwordChange.UserName = originalPlayer.UserName;

            //if (originalPlayer.Password != passwordChange.EnterOldPassword)
            //{
            //    ModelState.AddModelError("EnterOldPassword", "Incorrect actual Password!");
            //}

            if (!ModelState.IsValid)
            {
                return View(passwordChange);
            }

            var player = _mapper.Map<Player>(passwordChange);
            player.Email = originalPlayer.Email;
            player.DateOfBirth = originalPlayer.DateOfBirth;

            try
            {
                await _playerService.UpdatePassword(player.Id, player);
                return RedirectToAction(nameof(Edit), new { id = player.Id });
            }
            catch (InvalidModelException exception)
            {
                foreach (var data in exception.ModelStatesData)
                {
                    ModelState.AddModelError("NewPassword", data.Value);
                }

                return View(passwordChange);
            }
        }


        // GET: PlayerController/Delete/5
        public async Task<ActionResult> Delete()
        {
            var playerId = Int32.Parse(_userManager.GetUserId(User));
            var player = await _playerService.Get(playerId);
            var playerForDelete = _mapper.Map<PlayerDeleteModelView>(player);
            return View(playerForDelete);
        }

        // POST: PlayerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(PlayerDeleteModelView playerDelete)
        {
            var originalPlayer = await _playerService.Get(playerDelete.Id);
            playerDelete.UserName = originalPlayer.UserName;

            //if (originalPlayer.Password != playerDelete.PasswordToConfirmDelete)
            //{
            //    ModelState.AddModelError("PasswordToConfirmDelete", "Invalid Password!");
            //}

            if (!ModelState.IsValid)
            {
                return View(playerDelete);
            }

            try
            {
                await _playerService.Delete(playerDelete.Id);
                return RedirectToAction(nameof(Index), "Home");
            }
            catch
            {
                return View(playerDelete);
            }
        }
    }
}
