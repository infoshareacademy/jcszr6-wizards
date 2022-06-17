using System;
using System.Collections.Generic;
using System.Linq;
using Wizards.BusinessLogic.Services.ModelsValidation.Elements;

namespace Wizards.BusinessLogic.Services.ModelsValidation
{
    public class PlayerValidator : IPlayerValidator
    {
        private readonly PlayerValidationSettings _settings;
        private Dictionary<string,string> _modelStatesData;
        private bool _isValid;
        public PlayerValidator()
        {
            _settings = ValidationSettingsRepository.GetPlayersValidationSettings();
            _modelStatesData = new Dictionary<string,string>();
        }

        public void Validate(Player player)
        {
            _isValid = true;

            ValidateUserName(player.UserName);
            ValidatePassword(player.Password);
            ValidateEmail(player.Email);
            ValidateDateOfBirth(player.DateOfBirth);

            if (!_isValid)
            {
                throw new InvalidModelException(_modelStatesData);
            }
        }

        private void ValidateUserName(string playerUserName)
        {
            foreach (var task in _settings.UserNameTasks)
            {
                var result = task.Validate(playerUserName);

                if (!result.IsValid)
                {
                    _modelStatesData.Add("UserName", $"User Name {result.Message}");
                    _isValid = false;
                    return;
                }
            }

            var inUse = _settings.AlredyInUseTask.Validate(playerUserName, GameDataRepository.GetAllPlayers().Select(p=>p.UserName).ToList());
            
            if (!inUse.IsValid)
            {
                _modelStatesData.Add("UserName", $"User Name {inUse.Message}");
                _isValid = false;
            }
        }

        private void ValidatePassword(string playerPassword)
        {
            foreach (var task in _settings.PasswordTasks)
            {
                var result = task.Validate(playerPassword);

                if (!result.IsValid)
                {
                    _modelStatesData.Add("Password", $"Password {result.Message}");
                    _isValid = false;
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
                    _modelStatesData.Add("Email", result.Message);
                    _isValid = false;
                    return;
                }
            }

            var inUse = _settings.AlredyInUseTask.Validate(playerEmail, GameDataRepository.GetAllPlayers().Select(p => p.Email).ToList());

            if (!inUse.IsValid)
            {
                _isValid = false;
                _modelStatesData.Add("Email",$"Email {inUse.Message}");
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
    }
}