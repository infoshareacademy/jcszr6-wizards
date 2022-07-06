using Wizards.Repository.FileOperations;
using Wizards.Services.Validation.Elements;
using Wizards.Services.Validation.Settings;

namespace Wizards.Services.Validation
{
    public class PlayerValidator : IPlayerValidator
    {
        private readonly PlayerValidationSettings _settings;
        private Dictionary<string, string> _modelStatesData;
        private bool _isValid;
        private readonly IWizardsRepository _wizardsRepository;

        public PlayerValidator(IWizardsRepository wizardsRepository)
        {
            _settings = ValidationSettingsRepository.GetPlayersValidationSettings();
            _modelStatesData = new Dictionary<string, string>();
            _wizardsRepository = wizardsRepository;
        }

        public void ValidateForCreate(Core.Model.Player player)
        {
            _isValid = true;

            ValidateUserName(player.UserName);
            ValidatePassword(player.Password);
            ValidateEmail(player.Email);
            ValidateDateOfBirth(player.DateOfBirth);
            CheckInUse(player);

            if (!_isValid)
            {
                throw new InvalidModelException(_modelStatesData);
            }
        }

        public void ValidateForUpdate(Core.Model.Player player)
        {
            _isValid = true;

            ValidateEmail(player.Email);
            ValidateDateOfBirth(player.DateOfBirth);

            if (!_isValid)
            {
                throw new InvalidModelException(_modelStatesData);
            }
        }

        public void ValidateForPasswordUpdate(Core.Model.Player player)
        {
            _isValid = true;

            ValidatePassword(player.Password);

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

        private void CheckInUse(Core.Model.Player player)
        {
            var inUseUsername = _settings.AlredyInUseTask.Validate(player.UserName,
                _wizardsRepository.GetAll().Select(p => p.UserName).ToList());

            if (!inUseUsername.IsValid)
            {
                _isValid = false;
                _modelStatesData.Add("UserName", $"User Name {inUseUsername.Message}");
            }

            var inUseEmail = _settings.AlredyInUseTask.Validate(player.Email,
                _wizardsRepository.GetAll().Select(p => p.Email).ToList());

            if (!inUseEmail.IsValid)
            {
                _isValid = false;
                _modelStatesData.Add("Email", $"Email {inUseEmail.Message}");
            }
        }
    }
}