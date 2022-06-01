using System;
using System.Collections.Generic;
using System.Linq;


namespace Wizards.BusinessLogic
{
    public class ValueValidator
    {
        public bool AllowLetters { get; set; }
        public bool AllowDigits { get; set; }
        public bool AllowSpecialCharacters { get; set; }
        public bool AllowSpace { get; set; }
        public bool CheckIsMail { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        
        private readonly List<char> allowedSpecialCharacters = new()
        {
            '(',')','*','+','-','/',',','.',':',';','=','?','!','#','@','$','%','^','&','[',']','{','}','<','>','|','_','\\'
        };
        public List<string> AlredyInUseValues { get; set; }

        public ValueValidator()
        {
            AllowLetters = true;
            AllowDigits = true;
            AllowSpecialCharacters = false;
            AllowSpace = true;
            CheckIsMail = false;
            Min = 0;
            Max = 50;
        }
        public ValueValidator(List<string> alredyInUseValues) : this()
        {
            AlredyInUseValues = alredyInUseValues;
        }

        public bool Validate(string inputValue)
        {

            string value = inputValue.ToLower();

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidValueException(TextRepository.Get(ValueErrorsMsg.IsNull));
            }

            if (value.Length < Min)
            {
                throw new InvalidValueException(TextRepository.Get(ValueErrorsMsg.ToShort));
            }

            if (value.Length > Max)
            {
                throw new InvalidValueException(TextRepository.Get(ValueErrorsMsg.ToLong));
            }

            if (TextRepository.RestrictedWords.Any(r => value.Contains(r)))
            {
                throw new InvalidValueException(TextRepository.Get(ValueErrorsMsg.HasRestrictedWord));
            }

            if (!CheckCharacters(value))
            {
                throw new InvalidValueException(TextRepository.Get(ValueErrorsMsg.HasRestrictedCharacter));
            }

            if (CheckInUse(value))
            {
                throw new InvalidValueException(TextRepository.Get(ValueErrorsMsg.AlredyInUse));
            }

            if (!CheckIsMailCorrect(value))
            {
                throw new InvalidValueException(TextRepository.Get(ValueErrorsMsg.MailNotCorrect));
            }

            return true;
        }

        public bool Validate(int inputValue)
        {
            if (inputValue > Max)
            {
                throw new InvalidValueException(TextRepository.Get(ValueErrorsMsg.NumberToHigh));
            }

            if (inputValue < Min)
            {
                throw new InvalidValueException(TextRepository.Get(ValueErrorsMsg.NumberToLow));
            }

            return true;
        }

        public bool Validate(char key, char[] expectedKeys)
        {
            if (!expectedKeys.Contains(key))
            {
                throw new InvalidValueException(TextRepository.Get(ValueErrorsMsg.InvalidKey));
            }

            return true;
        }

        private bool CheckCharacters(string value)
        {
            return (CheckLetters(value) && CheckDigits(value) && CheckSpecialCharacters(value) && CheckSpace(value));
        }

        private bool CheckLetters(string value)
        {
            if (AllowLetters && value
                    .Where(c => char.IsLetter(c))
                    .All(c => c >= 97 && c <= 122))
            {
                return true;
            }

            if (!AllowLetters && !value.Any(v => char.IsLetter(v)))
            {
                return true;
            }

            return false;
        }

        private bool CheckDigits(string value)
        {
            if (!AllowDigits && value.Any(v => char.IsDigit(v)))
            {
                return false;
            }

            return true;
        }

        private bool CheckSpecialCharacters(string value)
        {
            var filtredText = value.Where(v => !char.IsLetter(v) && !char.IsDigit(v) && v != ' ').ToList();
            if (AllowSpecialCharacters && !filtredText.Any(v => !allowedSpecialCharacters.Contains(v)))
            {
                return true;
            }
            
            if (!AllowSpecialCharacters && !value.Any(v => !char.IsLetter(v) && !char.IsDigit(v) && v != ' '))
            {
                return true;
            }

            return false;
        }

        private bool CheckSpace(string value)
        {
            if (value.Contains(' ') && !AllowSpace)
            {
                return false;
            }

            return true;
        }

        private bool CheckInUse(string value)
        {
            if (AlredyInUseValues == null)
            {
                return false;
            }

            if (AlredyInUseValues.Any(a => a.ToLower() == value.ToLower()))
            {
                return true;
            }

            return false;
        }

        private bool CheckIsMailCorrect(string value)
        {
            char[] chars = { '@', '.' };

            if (CheckIsMail)
            {
                return (chars.All(c => value.Contains(c)));
            }

            return true;
        }

    }
}