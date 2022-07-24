using System;
using System.Threading.Tasks;
using AutoMapper;
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

        public PlayerController(IPlayerService playerService, IMapper mapper)
        {
            _playerService = playerService;
            _mapper = mapper;
        }

        // GET: PlayerController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var player = await _playerService.Get(id);
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

            var player = _mapper.Map<Player>(playerCreate);

            try
            {
                await _playerService.Add(player);
                return RedirectToAction(nameof(Details), new { id = player.Id });
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

        // GET: PlayerController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var player = await _playerService.Get(id);
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
        public async Task<ActionResult> EditPassword(int id)
        {
            var player = await _playerService.Get(id);
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
        public async Task<ActionResult> Delete(int id)
        {
            var player = await _playerService.Get(id);
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
