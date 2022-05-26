using System;
using System.Runtime.Serialization;

namespace Wizards.BusinessLogic
{

    [Serializable]
    public class InvalidValueException : Exception
    {

        public InvalidValueException()
        {
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