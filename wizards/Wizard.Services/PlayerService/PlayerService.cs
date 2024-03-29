﻿using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Wizards.Core.Interfaces.UserModelInterfaces;
using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.UserModels.Enums;
using Wizards.Services.Extensions;
using Wizards.Services.Validation;
using Wizards.Services.Validation.Elements;

namespace Wizards.Services.PlayerService;
public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IPlayerValidator _playerValidator;
    private readonly UserManager<Player> _userManager;


    public PlayerService(IPlayerRepository playerRepository, IPlayerValidator playerValidator,
        UserManager<Player> userManager)
    {
        _playerRepository = playerRepository;
        _playerValidator = playerValidator;
        _userManager = userManager;

        _userManager.UserValidators.Clear();
        _userManager.PasswordValidators.Clear();
    }

    public async Task Create(Player newPlayer, string password)
    {
        await _playerValidator.Validate(newPlayer, password);

        var result = await _userManager.CreateAsync(newPlayer, password);
        result = await _userManager.AddToRoleAsync(newPlayer, UserRoles.RegularUser.ToString());

        if (!result.Succeeded)
        {
            throw new InvalidDataException("Uexpected Error!");
        }
    }

    public async Task Delete(ClaimsPrincipal user, string passwordConfirm)
    {
        var player = await Get(user);

        if (!await _userManager.CheckPasswordAsync(player, passwordConfirm))
        {
            var message = new Dictionary<string, string>();
            message.Add("PasswordConfirm", "Password is not correct!");
            throw new InvalidModelException(message);
        }

        await _playerRepository.Remove(player);
    }

    public async Task Update(Player player)
    {
        await _playerValidator.Validate(player);

        var playerToUpdate = await Get(player.Id);

        playerToUpdate.Email = player.Email;
        playerToUpdate.NormalizedEmail = player.Email.ToUpper();
        playerToUpdate.DateOfBirth = player.DateOfBirth;

        await _playerRepository.Update(playerToUpdate);
    }

    public async Task ChangePassword(ClaimsPrincipal user, string currentPassword, string newPassword)
    {
        var playerToUpdate = await Get(user);

        await _playerValidator.Validate(playerToUpdate, currentPassword, newPassword);

        var result = await _userManager.ChangePasswordAsync(playerToUpdate, currentPassword, newPassword);

        if (!result.Succeeded)
        {
            throw new InvalidDataException("Uexpected Error!");
        }
    }

    public async Task<Player> Get(int id)
    {
        var player = await _playerRepository.Get(id);

        if (player != null)
        {
            return player;
        }

        throw new NullReferenceException($"There is no Player with id: {id}!");
    }

    public async Task<Player> Get(ClaimsPrincipal user)
    {
        return await _playerRepository.Get(user.GetId());
    }

    public async Task SetMusicVolume(ClaimsPrincipal user, int volumeValue)
    {
        var player = await Get(user);

        player.MusicVolume = volumeValue;

        await _playerRepository.Update(player);
    }

    public async Task<int> GetMusicVolume(ClaimsPrincipal user)
    {
        var player = await Get(user);

        return player.MusicVolume;
    }
}