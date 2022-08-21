using Microsoft.AspNetCore.Identity;
using Wizards.Core.Interfaces;
using Wizards.Core.Model;
using Wizards.Services.Validation.Elements;
using Wizards.Services.Validation.Settings;

namespace Wizards.Services.Validation;
public class PlayerValidator : IPlayerValidator
{
    private readonly PlayerValidationSettings _settings;
    private Dictionary<string, string> _modelStatesData;
    private bool _isValid;
    private readonly IPlayerRepository _playerRepository;
    private readonly UserManager<Player> _userManager;

    public PlayerValidator(IPlayerRepository playerRepository, UserManager<Player> userManager)
    {
        _settings = ValidationSettingsFactory.GetPlayersValidationSettings();
        _modelStatesData = new Dictionary<string, string>();
        _playerRepository = playerRepository;
        _userManager = userManager;
        _isValid = true;
    }

    public async Task Validate(Player player)
    {
        _isValid = true;

        await ValidatePlayer(player);

        if (!_isValid)
        {
            throw new InvalidModelException(_modelStatesData);
        }
    }

    public async Task Validate(Player player, string password)
    {
        _isValid = true;

        await ValidatePlayer(player);

        ValidatePassword(password, "Password");

        if (!_isValid)
        {
            throw new InvalidModelException(_modelStatesData);
        }
    }

    public async Task Validate(Player player, string currentPassword, string newPassword)
    {
        _isValid = true;

        if (!await _userManager.CheckPasswordAsync(player, currentPassword))
        {
            _isValid = false;
            _modelStatesData.Add("CurrentPassword", "Current Password is not correct!");
        }

        ValidatePassword(newPassword, "NewPassword");

        if (!_isValid)
        {
            throw new InvalidModelException(_modelStatesData);
        }
    }

    private async Task ValidatePlayer(Player player)
    {
        if (!await _playerRepository.Exist(player.Id))
        {
            ValidateUserName(player.UserName);
            await UserNameInUse(player.UserName);
        }

        ValidateEmail(player.Email);

        if (!await _playerRepository.Exist(player.Id, player.Email))
        {
            await EmailInUse(player.Email);
        }

        ValidateDateOfBirth(player.DateOfBirth);
    }

    private void ValidateUserName(string playerUserName)
    {
        foreach (var task in _settings.UserNameTasks)
        {
            var result = task.Validate(playerUserName);

            if (!result.IsValid)
            {
                _isValid = false;
                _modelStatesData.Add("UserName", $"User Name {result.Message}");
                return;
            }
        }
    }

    private void ValidatePassword(string playerPassword, string propertyName)
    {
        foreach (var task in _settings.PasswordTasks)
        {
            var result = task.Validate(playerPassword);

            if (!result.IsValid)
            {
                _isValid = false;
                _modelStatesData.Add(propertyName, $"Password {result.Message}");
                return;
            }
        }
    }

    private void ValidateEmail(string playerEmail)
    {
        foreach (var task in _settings.EmailTasks)
        {
            var result = task.Validate(playerEmail);

            if (!result.IsValid)
            {
                _isValid = false;
                _modelStatesData.Add("Email", result.Message);
                return;
            }
        }
    }

    private void ValidateDateOfBirth(DateTime playerDateOfBirth)
    {
        foreach (var task in _settings.DateOfBirthTasks)
        {
            var result = task.Validate(playerDateOfBirth);

            if (!result.IsValid)
            {
                _isValid = false;
                _modelStatesData.Add("DateOfBirth", result.Message);
            }
        }
    }

    private async Task UserNameInUse(string playerUserName)
    {
        if (_modelStatesData.Keys.Contains("UserName"))
        {
            return;
        }

        var inUseUsername = _settings.AlredyInUseTask.Validate(playerUserName,
            await _playerRepository.GetAllUserNames());

        if (!inUseUsername.IsValid)
        {
            _isValid = false;
            _modelStatesData.Add("UserName", $"User Name {inUseUsername.Message}");
        }
    }

    private async Task EmailInUse(string playerEmail)
    {
        if (_modelStatesData.Keys.Contains("Email"))
        {
            return;
        }

        var inUseEmail = _settings.AlredyInUseTask.Validate(playerEmail,
            await _playerRepository.GetAllEmails());

        if (!inUseEmail.IsValid)
        {
            _isValid = false;
            _modelStatesData.Add("Email", $"Email {inUseEmail.Message}");
        }
    }
}