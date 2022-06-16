using System;
using System.Runtime.Serialization;

namespace Wizards.BusinessLogic
{

    [Serializable]
    public class InvalidValueException : Exception
    {
        public string MyMessage { get; private set; }
        public string NameOfElement { get; private set; }
        public InvalidValueException()
        {
        }

        public InvalidValueException(string nameOfElement, string myMessage)
        {
            NameOfElement = nameOfElement;
            MyMessage = myMessage;
        }
        public InvalidValueException(string message) : base(message)
        {
        }

        public InvalidValueException(string message, Exception inner) : base(message, inner)
        {
        }

        protected InvalidValueException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }

}