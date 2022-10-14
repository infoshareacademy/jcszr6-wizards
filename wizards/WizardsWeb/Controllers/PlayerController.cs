﻿using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wizards.Core.Interfaces.LoggerInterface;
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
    private readonly IWizardsLogger _logger;


    public PlayerController(IPlayerService playerService, IMapper mapper, SignInManager<Player> signInManager, IWizardsLogger logger)
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
            await _logger.SendLogAsync<PlayerController>(LogLevel.Information, $"{playerCreate.UserName} player create failed", ModelState);
            return View(playerCreate);
        }

        var player = _mapper.Map<Player>(playerCreate);

        try
        {
            await _playerService.Create(player, playerCreate.Password);
            await _signInManager.SignInAsync(player, isPersistent: false);
            await _logger.SendLogAsync<PlayerController>(LogLevel.Information, $"{playerCreate.UserName} player account create successful");
            return RedirectToAction(nameof(Details));
        }
        catch (Exception exception)
        {

            ModelState.AddModelErrorByException(exception);
            if (exception is InvalidModelException)
            {
                await _logger.SendLogAsync<PlayerController>(LogLevel.Information, $"{playerCreate.UserName} player account create failed {exception.GetType()}", ModelState, exception);
            }
            else
            {
                await _logger.SendLogAsync<PlayerController>(LogLevel.Error, $"{playerCreate.UserName} player account create failed {exception.GetType()}", ModelState, exception);
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
            await _logger.SendLogAsync<PlayerController>(LogLevel.Information, $"Login successful by {playerLogIn.UserName}");
            return RedirectToAction(nameof(Details));
        }

        ModelState.AddModelError("", "Invalid login attempt!");
        await _logger.SendLogAsync<PlayerController>(LogLevel.Information, $"Login failed by {playerLogIn.UserName}", ModelState);
        return View(playerLogIn);
    }

    [AllowAnonymous]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        await _logger.SendLogAsync<PlayerController>(LogLevel.Information, "User successfully Logout!");
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
            await _logger.SendLogAsync<PlayerController>(LogLevel.Information, $"{playerEdit.UserName} account edit information failed", ModelState);
            return View(playerEdit);
        }

        var player = _mapper.Map<Player>(playerEdit);
        player.Id = User.GetId();

        try
        {
            await _playerService.Update(player);
            await _logger.SendLogAsync<PlayerController>(LogLevel.Information, $"{playerEdit.UserName} update success");
            return RedirectToAction(nameof(Details));
        }
        catch (Exception exception)
        {
            ModelState.AddModelErrorByException(exception);
            await _logger.SendLogAsync<PlayerController>(LogLevel.Information, $"{playerEdit.UserName} account edit information failed, {exception.GetType()}", ModelState, exception);
            return View(playerEdit);
        }
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
            await _logger.SendLogAsync<PlayerController>(LogLevel.Information, $"{passwordChange.UserName} password change failed", ModelState);
            return View(passwordChange);
        }

        try
        {
            await _playerService.ChangePassword(User, passwordChange.CurrentPassword, passwordChange.NewPassword);
            await _logger.SendLogAsync<PlayerController>(LogLevel.Information, $"{passwordChange.UserName} password change successful");
            return RedirectToAction(nameof(Edit));
        }
        catch (Exception exception)
        {
            ModelState.AddModelErrorByException(exception);
            if (exception is InvalidModelException)
            {
                await _logger.SendLogAsync<PlayerController>(LogLevel.Information, $"{passwordChange.UserName} password change failed {exception.GetType()}", ModelState, exception);
            }
            else
            {
                await _logger.SendLogAsync<PlayerController>(LogLevel.Error, $"{passwordChange.UserName} password change failed {exception.GetType()}", ModelState, exception);
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
            await _logger.SendLogAsync<PlayerController>(LogLevel.Information, $"{originalPlayer.UserName} delete user failed", ModelState);
            return View(playerDelete);
        }

        try
        {
            await _playerService.Delete(User, passwordConfirm);
            await _logger.SendLogAsync<PlayerController>(LogLevel.Information, $"{playerDelete.UserName} deleted successful");
            return RedirectToAction(nameof(Logout));
        }
        catch (Exception exception)
        {
            ModelState.AddModelErrorByException(exception);
            await _logger.SendLogAsync<PlayerController>(LogLevel.Information, $"{playerDelete.UserName} password change failed {exception.GetType()}", ModelState, exception);
            return View(playerDelete);
        }
    }
}