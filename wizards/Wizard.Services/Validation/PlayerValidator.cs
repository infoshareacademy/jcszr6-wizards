using Wizards.Core.Interfaces;
using Wizards.Core.Model;
using Wizards.Services.Validation.Elements;
using Wizards.Services.Validation.Settings;

namespace Wizards.Services.Validation
{
    public class PlayerValidator : IPlayerValidator
    {
        private readonly PlayerValidationSettings _settings;
        private Dictionary<string, string> _modelStatesData;
        private bool _isValid;
        private readonly IPlayerRepository _playerRepository;

        public PlayerValidator(IPlayerRepository playerRepository)
        {
            _settings = ValidationSettingsFactory.GetPlayersValidationSettings();
            _modelStatesData = new Dictionary<string, string>();
            _playerRepository = playerRepository;
        }

        public async Task Validate(Player player)
        {
            _isValid = true;
            
            if ( !await _playerRepository.Exist(player.Id))
            {
                ValidateUserName(player.UserName);
                await UserNameInUse(player.UserName);
            }
            ValidatePassword(player.Password);
            ValidateEmail(player.Email);
            if (!await _playerRepository.Exist(player.Id, player.Email))
            {
                await EmailInUse(player.Email);
            }
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
                    _isValid = false;
                    _modelStatesData.Add("UserName", $"User Name {result.Message}");
                    return;
                }
            }
        }

        private void ValidatePassword(string playerPassword)
        {
            foreach (var task in _settings.PasswordTasks)
            {
                var result = task.Validate(playerPassword);

                if (!result.IsValid)
                {
                    _isValid = false;
                    _modelStatesData.Add("Password", $"Password {result.Message}");
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
            var inUseEmail = _settings.AlredyInUseTask.Validate(playerEmail,
                await _playerRepository.GetAllEmails());

            if (!inUseEmail.IsValid)
            {
                _isValid = false;
                _modelStatesData.Add("Email", $"Email {inUseEmail.Message}");
            }
        }
    }
}