using System;
using System.Runtime.Serialization;

namespace Wizards.BusinessLogic.ConsoleDataInput
{

    [Serializable]
    public class InvalidCharacterException : Exception
    {
        public InvalidCharacterException()
        {
        }
    }

    public class TextIsEmptyException : Exception
    {
        public TextIsEmptyException()
        {
        }
    }

    public class TextToShortException : Exception
    {
        public TextToShortException()
        {
        }
    }

    public class TextToLongException : Exception
    {
        public TextToLongException()
        {
        }
    }

    public class TextContainsRestrictedWords : Exception
    {
        public TextContainsRestrictedWords()
        {
        }
    }


}