using System;
using System.Collections.Generic;
using System.Linq;
using Wizards.GUI;

namespace Wizards.BusinessLogic.ConsoleDataInput
{
    public class ValueValidator
    {
        private readonly List<char> allowedInterpunktors = new List<char>()
        {
            '!','(',')','*','+',',','.','-','/',':',';','=','?'
        };

        public bool AllowLetters { get; set; }
        public bool AllowDigits { get; set; }
        public bool AllowInterpunktors { get; set; }
        public bool AllowSpace { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public List<string> AlredyInUseValues { get; set; }

        public ValueValidator()
        {
            AllowLetters = true;
            AllowDigits = true;
            AllowInterpunktors = false;
            AllowSpace = true;
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

            return true;
        }

        private bool CheckInUse(string value)
        {
            if (AlredyInUseValues == null)
            {
                return false;
            }

            if (AlredyInUseValues.Any(a => a == value))
            {
                return true;
            }

            return false;
        }

        private bool CheckCharacters(string value)
        {
            bool checkLetters = CheckLetters(value);
            bool checkDigits = CheckDigits(value);
            bool checkInterpunktors = CHeckSpecialCharacters(value);
            bool checkSpace = CheckSpace(value);

            return (checkLetters && checkDigits && checkInterpunktors && checkSpace);
        }

        private bool CheckSpace(string value)
        {
            bool checkSpace = true;

            if (value.Contains(' ') && !AllowSpace)
            {
                checkSpace = false;
            }

            return checkSpace;
        }

        private bool CHeckSpecialCharacters(string value)
        {
            bool checkSpecialCharacters = false;

            if (AllowInterpunktors && value.Where(v => 
                        !char.IsLetter(v) && 
                        !char.IsDigit(v) &&
                        v != ' ')
                    .All(v => allowedInterpunktors.Contains(v)))
            {
                checkSpecialCharacters = true;
            }
            else if (!AllowInterpunktors && !value.Any(v => !char.IsLetter(v) && !char.IsDigit(v) && v != ' '))
            {
                checkSpecialCharacters = true;
            }

            return checkSpecialCharacters;
        }

        private bool CheckDigits(string value)
        {
            if (!AllowDigits && !value.Any(v => char.IsDigit(v)))
            {
                return false;
            }

            return true;
        }

        private bool CheckLetters(string value)
        {
            bool checkLetters = false;

            if (AllowLetters && value
                    .Where(c => char.IsLetter(c))
                    .All(c => c >= 97 && c <= 122))
            {
                checkLetters = true;
            }
            else if (!AllowLetters && !value.Any(v => char.IsLetter(v)))
            {
                checkLetters = true;
            }

            return checkLetters;
        }
    }
}