using System;
using System.Linq;
using Wizards.BusinessLogic.Services.ModelsValidation.Elements;

namespace Wizards.BusinessLogic.Services.ModelsValidation
{
    public class PlayerValidator : IPlayerValidator
    {
        public PlayerValidationSettings Settings { get; private set; }
        public PlayerValidator()
        {
            Settings = ValidationSettingsRepository.GetPlayersValidationSettings();
        }
        public void Validate(Player player)
        {
            ValidateUserName(player.UserName);
            ValidatePassword(player.Password);
            ValidateEmail(player.Email);
            ValidateDateOfBirth(player.DateOfBirth);
        }
        private void ValidateUserName(string playerUserName)
        {
            foreach (var task in Settings.UserNameTasks)
            {
                var result = task.Validate(playerUserName);

                if (!result.IsValid)
                {
                    throw new InvalidValueException("User Name ", result.Message);
                }
            }

            var inUse = Settings.AlredyInUseTask.Validate(playerUserName, GameDataRepository.GetAllPlayers().Select(p=>p.UserName).ToList());
            
            if (!inUse.IsValid)
            {
                throw new InvalidValueException("User Name ", inUse.Message);
            }

        }
        private void ValidatePassword(string playerPassword)
        {
            foreach (var task in Settings.PasswordTasks)
            {
                var result = task.Validate(playerPassword);

                if (!result.IsValid)
                {
                    throw new InvalidValueException("User Name ", result.Message);
                }
            }
        }
        private void ValidateEmail(string playerEmail)
        {
            foreach (var task in Settings.EmailTasks)
            {
                var result = task.Validate(playerEmail);

                if (!result.IsValid)
                {
                    throw new InvalidValueException("User Name ", result.Message);
                }
            }

            Settings.AlredyInUseTask.Validate(playerEmail, GameDataRepository.GetAllPlayers().Select(p => p.Email).ToList());
        }

        private void ValidateDateOfBirth(DateTime playerDateOfBirth)
        {
            foreach (var task in Settings.DateOfBirthTasks)
            {
                var result = task.Validate(playerDateOfBirth);

                if (!result.IsValid)
                {
                    throw new InvalidValueException("User Name ", result.Message);
                }
            }
        }
    }
}