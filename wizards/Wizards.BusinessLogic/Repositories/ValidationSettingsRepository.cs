using System;
using System.Collections.Generic;
using System.Linq;
using Wizards.BusinessLogic.Services.ModelsValidation.Elements;
using Wizards.BusinessLogic.Services.ModelsValidation.ValidationTasks;

namespace Wizards.BusinessLogic
{
    public static class ValidationSettingsRepository
    {
        private static PlayerValidationSettings _playerSettings;

        static ValidationSettingsRepository()
        {
            _playerSettings = new PlayerValidationSettings()
            {
                UserNameTasks = new List<IStringValidationTask>()
                {
                    new IsNull(),
                    new StringMinLength(3),
                    new StringMaxLength(20),
                    new RestrictedWords(),
                    new AllowedCharacters("abcdefghijklmnopqrstuvwxyząàáâäćçęèéêëíîïłńñóôöùúûüźż1234567890-_"),
                },
                AlredyInUseTask = new AlredyInUse(),
                PasswordTasks = new List<IStringValidationTask>()
                {
                    new IsNull(),
                    new StringMinLength(8),
                    new AllowedCharacters("abcdefghijklmnopqrstuvwxyząàáâäćçęèéêëíîïłńñóôöùúûüźż1234567890,.;:?!'@#$%^&*()_+-=`~"),
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

    public class IsPasswordHardEnough : IStringValidationTask
    {
        public ValidationState Validate(string value)
        {
            bool hasOneUpper = true;
            bool hasOneDigit = true;
            bool hasOneSpecial = true;

            if (!value.Any(c => char.IsUpper(c)))
            {
                hasOneUpper = false;
            }

            if (!value.Any(c => char.IsDigit(c)))
            {
                hasOneDigit = false;
            }

            if (!value.Any(c => char.IsPunctuation(c) || char.IsSymbol(c)))
            {
                hasOneSpecial = false;
            }

            if (hasOneUpper && hasOneDigit && hasOneSpecial)
            {
                return new ValidationState(true);
            }

            return new ValidationState(false, TextRepository.Get(ValueErrorsMsg.PasswordNotHard));
        }
    }
}