﻿using System.Collections.Generic;
using System.Linq;
using Wizards.BusinessLogic.Services.ModelsValidation.Elements;

namespace Wizards.BusinessLogic.Services.ModelsValidation.ValidationTasks
{
    public class IsNull : IStringValidationTask
    {
        public ValidationState Validate(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return new ValidationState(false, TextRepository.Get(ValueErrorsMsg.IsNull));
            }

            return new ValidationState(true);
        }
    }

    public partial class StringMinLength : IStringValidationTask
    {
        public int MinLength { get; set; }
        public StringMinLength(int minLength)
        {
            MinLength = minLength;
        }

        public ValidationState Validate(string value)
        {
            if (value.Length < MinLength)
            {
                return new ValidationState(false, $"{TextRepository.Get(ValueErrorsMsg.ToShort)}{MinLength}");
            }

            return new ValidationState(true);
        }
    }
    public partial class StringMaxLength : IStringValidationTask
    {
        public int MaxLength { get; set; }
        public StringMaxLength(int maxLength)
        {
            MaxLength = maxLength;
        }

        public ValidationState Validate(string value)
        {
            if (value.Length > MaxLength)
            {
                return new ValidationState(false, $"{TextRepository.Get(ValueErrorsMsg.ToLong)}{MaxLength}");
            }

            return new ValidationState(true);
        }
    }
    public class AllowedCharacters : IStringValidationTask
    {
        public string AllowedChars { get; set; }
        public AllowedCharacters(string allowedChars)
        {
            AllowedChars = allowedChars;
        }
        public AllowedCharacters() { }

        public ValidationState Validate(string value)
        {
            value = value.ToLower();
            var isValid = !value.Any(c => !AllowedChars.Contains(c));

            if (!isValid)
            {
                var characters = $"[ {string.Join(" ",value.Where(c => !AllowedChars.Contains(c)).ToList())} ]";
                return new ValidationState(false,
                    $"{TextRepository.Get(ValueErrorsMsg.HasRestrictedCharacter)}{characters}");
            }

            return new ValidationState(true);
        }
    }

    public class RestrictedWords : IStringValidationTask
    {
        public ValidationState Validate(string value)
        {
            var restrictedWords = TextRepository.RestrictedWords;
            value = value.ToLower();
            var isValid = !restrictedWords.Any(w => value.Contains(w));

            if (!isValid)
            {
                return new ValidationState(false, TextRepository.Get(ValueErrorsMsg.HasRestrictedWord));
            }

            return new ValidationState(true);
        }
    }

    public class IsEmail : IStringValidationTask
    {
        public ValidationState Validate(string value)
        {
            int dotPosition = 0;
            int atPosition = 0;
            
            if (value.Contains("@") && value.Contains("."))
            {
                atPosition = value.ToLower().IndexOf("@");
                dotPosition = value.ToLower().IndexOf(".", atPosition + 1);
            }
            
            var isValid = (dotPosition < value.Length &&
                           dotPosition > 0 &&
                           atPosition > 0);

            if (!isValid)
            {
                return new ValidationState(false, TextRepository.Get(ValueErrorsMsg.MailNotCorrect));
            }

            return new ValidationState(true);
        }
    }

    public class AlredyInUse :IStringAlredyInUse
    {
        public ValidationState Validate(string value, List<string> usedValues)
        {
            var isValid = !usedValues.Any(u => value.ToLower() == u.ToLower());

            if (!isValid)
            {
                return new ValidationState(false, TextRepository.Get(ValueErrorsMsg.AlredyInUse));
            }

            return new ValidationState(true);
        }

    }
}