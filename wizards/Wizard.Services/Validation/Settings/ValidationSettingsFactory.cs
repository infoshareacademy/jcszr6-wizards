using Wizards.Repository.TextRepo;
using Wizards.Repository.TextRepo.Enums;
using Wizards.Services.Validation.Elements;
using Wizards.Services.Validation.ValidationTasks;
using Wizards.Services.Validation.ValidationTasks.Interfaces;

namespace Wizards.Services.Validation.Settings
{
    public static class ValidationSettingsFactory
    {
        private static PlayerValidationSettings _playerSettings;

        static ValidationSettingsFactory()
        {
            _playerSettings = new PlayerValidationSettings()
            {
                UserNameTasks = new List<IStringValidationTask>()
                {
                    new IsNull(),
                    new StringMinLength(3),
                    new StringMaxLength(20),
                    new RestrictedWords(),
                    new AllowedCharacters("abcdefghijklmnopqrstuvwxyz1234567890-_"),
                },
                AlredyInUseTask = new AlredyInUse(),
                PasswordTasks = new List<IStringValidationTask>()
                {
                    new IsNull(),
                    new StringMinLength(8),
                    new AllowedCharacters("abcdefghijklmnopqrstuvwxyz1234567890,.;:?!'@#$%^&*()_+-=`~"),
                    new IsPasswordHardEnough()
                },
                EmailTasks = new List<IStringValidationTask>()
                {
                    new IsNull(),
                    new IsEmail()
                },
                DateOfBirthTasks = new List<IDateValidationTask>()
                {
                    new DateMin(new DateTime(1900, 1, 1)),
                    new RestrictedAge(10)
                }
            };
        }

        public static PlayerValidationSettings GetPlayersValidationSettings()
        {
            return _playerSettings;
        }
    }
}