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
                task.Validate(playerUserName);
            }

            Settings.AlredyInUseTask.Validate(playerUserName, Repository.GetAllPlayers().Select(p=>p.UserName).ToList());
        }
        private void ValidatePassword(string playerPassword)
        {
            foreach (var task in Settings.PasswordTasks)
            {
                task.Validate(playerPassword);
            }
        }
        private void ValidateEmail(string playerEmail)
        {
            foreach (var task in Settings.EmailTasks)
            {
                task.Validate(playerEmail);
            }

            Settings.AlredyInUseTask.Validate(playerEmail, Repository.GetAllPlayers().Select(p => p.Email).ToList());
        }

        private void ValidateDateOfBirth(DateTime playerDateOfBirth)
        {
            foreach (var task in Settings.DateOfBirthTasks)
            {
                task.Validate(playerDateOfBirth);
            }
        }
    }
}