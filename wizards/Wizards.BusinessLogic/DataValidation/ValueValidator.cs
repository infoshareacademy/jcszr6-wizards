using System;
using System.Collections.Generic;
using System.Linq;

namespace Wizards.BusinessLogic.ConsoleDataInput
{
    public class ValueValidator
    {
        private List<string> restrictedWords = new List<string>()
        {
            "dupa", "kupa"
        };

        private List<char> allowedLetter = new List<char>()
        {
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'
        };

        private List<char> allowedInterpunktors = new List<char>()
        {
            '-','_','(',')','+','=','*','/',',','.','!','?','%','@'
        };

        public bool AllowLetters { get; set; }
        public bool AllowDigits { get; set; }
        public bool AllowInterpunktors { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        public ValueValidator()
        {
            AllowLetters = true;
            AllowDigits = true;
            AllowInterpunktors = true;
            Min = 0;
            Max = 50;
        }

        public bool IsValid(string value)
        {
            bool result = true;
            value = value.ToLower();

            if (string.IsNullOrWhiteSpace(value))
            {
                result = false;
                throw new TextIsEmptyException();
            }
            else if (value.Length >= Min)
            {
                result = false;
                throw new TextToShortException();
            }
            else if (value.Length <= Max)
            {
                result = false;
                throw new TextToLongException();
            }
            else if (restrictedWords.Any(r => value.Contains(r)))
            {
                result = false;
                throw new TextContainsRestrictedWords();
            }
            else if (!CheckCharacters(value))
            {
                result = false;
                throw new InvalidCharacterException();
            }

            return result;
        }

        private bool CheckCharacters(string value)
        {
            bool result = false;
            bool checkLetters = false;
            bool checkDigits = false;
            bool checkInterpunktors = false;


            if (AllowLetters && value
                    .Where(v => char.IsLetter(v))
                    .All(v => allowedLetter.Contains(v)))
            {
                checkLetters = true;
            }
            else if (!AllowDigits && !value.Any(v => char.IsLetter(v)))
            {
                checkLetters = true;
            }

            if (!AllowDigits && !value.Any(v => char.IsDigit(v)))
            {
                checkDigits = true;
            }

            if (AllowInterpunktors && value.Where(v =>
                    char.IsPunctuation(v) ||
                    char.IsSymbol(v))
                    .All(v => allowedInterpunktors.Contains(v)))
            {
                checkInterpunktors = true;
            }
            else if (!AllowInterpunktors && !value.Any(v => char.IsPunctuation(v) || char.IsSymbol(v)))
            {
                checkInterpunktors = true;
            }

            result = (checkLetters && checkDigits && checkInterpunktors);

            return result;
        }
    }
}