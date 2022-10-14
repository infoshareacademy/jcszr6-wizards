using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wizards.Core.Model;
using Wizards.Core.Model.UserModels;
using Wizards.Services.Extentions;
using Wizards.Services.PlayerService;
using Wizards.Services.Validation.Elements;
using WizardsWeb.ModelViews.PlayerModelViews;

namespace WizardsWeb.Controllers;

[Authorize]
public class PlayerController : Controller
{
    private readonly IPlayerService _playerService;
    private readonly IMapper _mapper;
    private readonly SignInManager<Player> _signInManager;
    private readonly ILogger<PlayerController> _logger;

    public PlayerController(IPlayerService playerService, IMapper mapper, SignInManager<Player> signInManager, ILogger<PlayerController> logger)
    {
        _playerService = playerService;
        _mapper = mapper;
        _signInManager = signInManager;
        _logger = logger;
    }

    // GET: PlayerController/Details
    public async Task<ActionResult> Details()
    {
        var player = await _playerService.Get(User);
        var playerDetails = _mapper.Map<PlayerDetailsModelView>(player);
        return View(playerDetails);
    }

    // GET: PlayerController/Create
    [AllowAnonymous]
    public async Task<ActionResult> Create()
    {
        await _signInManager.SignOutAsync();
        return View();
    }

    // POST: PlayerController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    [AllowAnonymous]
    public async Task<ActionResult> Create(PlayerCreateModelView playerCreate)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogInformation($"{playerCreate.UserName} player create failed", ModelState);
            return View(playerCreate);
        }

        var player = _mapper.Map<Player>(playerCreate);

        try
        {
            await _playerService.Create(player, playerCreate.Password);
            await _signInManager.SignInAsync(player, isPersistent: false);
            _logger.LogInformation($"{playerCreate.UserName} player account create successful");
            return RedirectToAction(nameof(Details));
        }
        catch (Exception exception)
        {

            ModelState.AddModelErrorByException(exception);
            if (exception is InvalidModelException)
            {
                _logger.LogInformation($"{playerCreate.UserName} player account create failed {exception.GetType()}", ModelState);
            }
            else
            {
                _logger.LogError($"{playerCreate.UserName} player account create failed {exception.GetType()}", ModelState);
            }
            return View(playerCreate);
        }
    }

    [AllowAnonymous]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [AllowAnonymous]
    public async Task<IActionResult> Login(PlayerLogInModelView playerLogIn)
    {
        var result = await _signInManager.PasswordSignInAsync(playerLogIn.UserName, playerLogIn.Password, false, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            _logger.LogInformation($"Login successful by {playerLogIn.UserName}");
            return RedirectToAction(nameof(Details));
        }

        ModelState.AddModelError("", "Invalid login attempt!");
        _logger.LogError($"Login failed by {playerLogIn.UserName}", ModelState);
        return View(playerLogIn);
    }

    [AllowAnonymous]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction(nameof(Index), "Home");
    }

    // GET: PlayerController/Edit
    public async Task<ActionResult> Edit()
    {
        var player = await _playerService.Get(User);
        var playerEdit = _mapper.Map<PlayerEditModelView>(player);
        return View(playerEdit);
    }

    // POST: PlayerController/Edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(PlayerEditModelView playerEdit)
    {
        var originalPlayer = await _playerService.Get(User);
        playerEdit.UserName = originalPlayer.UserName;

        if (!ModelState.IsValid)
        {
            _logger.LogInformation($"{playerEdit.UserName} account edit information failed", ModelState);
            return View(playerEdit);
        }

        var player = _mapper.Map<Player>(playerEdit);
        player.Id = User.GetId();

        try
        {
            await _playerService.Update(player);
            _logger.LogInformation($"{playerEdit.UserName} update success");
            return RedirectToAction(nameof(Details));
        }
        catch (Exception exception)
        {
            ModelState.AddModelErrorByException(exception);
            _logger.LogInformation($"{playerEdit.UserName} account edit information failed, {exception.GetType()}", ModelState);
            return View(playerEdit);
        }
    }

    [HttpGet("Player/SetVolume/{volumeValue:int}")]
    public async Task<IActionResult> SetMusicVolume(int volumeValue)
    {
        await _playerService.SetMusicVolume(User, volumeValue);
        return Ok();
    }

    [HttpGet("Player/GetVolume")]
    public async Task<IActionResult> GetMusicVolume()
    {
        var volume = await _playerService.GetMusicVolume(User);
        return Json(volume);
    }

    // GET: PlayerController/EditPassword
    public async Task<ActionResult> EditPassword()
    {
        var player = await _playerService.Get(User);
        var passwordChage = _mapper.Map<PasswordChangeModelView>(player);

        return View(passwordChage);
    }

    // POST: PlayerController/EditPassword
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> EditPassword(PasswordChangeModelView passwordChange)
    {
        var originalPlayer = await _playerService.Get(User);

        passwordChange.UserName = originalPlayer.UserName;

        if (!ModelState.IsValid)
        {
            _logger.LogInformation($"{passwordChange.UserName} password change failed", ModelState);
            return View(passwordChange);
        }

        try
        {
            await _playerService.ChangePassword(User, passwordChange.CurrentPassword, passwordChange.NewPassword);
            _logger.LogInformation($"{passwordChange.UserName} password change successful");
            return RedirectToAction(nameof(Edit));
        }
        catch (Exception exception)
        {
            ModelState.AddModelErrorByException(exception);
            if (exception is InvalidModelException)
            {
                _logger.LogInformation($"{passwordChange.UserName} password change failed {exception.GetType()}", ModelState);
            }
            else
            {
                _logger.LogError($"{passwordChange.UserName} password change failed {exception.GetType()}", ModelState);
            }
            return View(passwordChange);
        }
    }

    // GET: PlayerController/Delete
    public async Task<ActionResult> Delete()
    {
        var player = await _playerService.Get(User);
        var playerForDelete = _mapper.Map<PlayerDeleteModelView>(player);

        return View(playerForDelete);
    }

    // POST: PlayerController/Delete
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(PlayerDeleteModelView playerDelete)
    {
        var originalPlayer = await _playerService.Get(User);
        var passwordConfirm = playerDelete.PasswordConfirm;

        playerDelete = _mapper.Map<PlayerDeleteModelView>(originalPlayer);

        if (!ModelState.IsValid)
        {
            _logger.LogInformation($"{originalPlayer.UserName} delete user failed", ModelState);
            return View(playerDelete);
        }

        try
        {
            await _playerService.Delete(User, passwordConfirm);
            _logger.LogInformation($"{playerDelete.UserName} deleted successful");
            return RedirectToAction(nameof(Logout));
        }
        catch (Exception exception)
        {
            ModelState.AddModelErrorByException(exception);
            _logger.LogError($"{playerDelete.UserName} password change failed {exception.GetType()}", ModelState);
            return View(playerDelete);
        }
    }
}