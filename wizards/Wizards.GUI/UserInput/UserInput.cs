using System;
using Wizards.BusinessLogic;

namespace Wizards.GUI
{
    public class UserInput
    {
        public ValueValidator Validator { get; set; }
        public Screen Screen { get; set; }

        public string GetText()
        {
            bool isValid;
            string result;

            do
            {
                result = Console.ReadLine();

                try
                {
                    isValid = Validator.Validate(result);
                }
                catch (InvalidValueException e)
                {
                    isValid = HandleException(e);
                }
            } while (!isValid);

            return result;
        }

        public int GetNumber()
        {
            bool isValid;
            int result = 0;

            do
            {
                try
                {
                    result = new ValueConverter().ToIntNumber(Console.ReadLine());
                    isValid = Validator.Validate(result);
                }
                catch (InvalidValueException e)
                {
                    isValid = HandleException(e);
                }
            } while (!isValid);

            return result;
        }

        public char GetKey(char[] expectedKeys)
        {
            bool isValid;
            char result;

            do
            {
                result = Console.ReadKey().KeyChar;

                try
                {
                    isValid = Validator.Validate(result, expectedKeys);
                }
                catch (InvalidValueException e)
                {
                    isValid = HandleException(e);
                }
            } while (!isValid);

            return result;
        }

        public void WaitForKey()
        {
            Console.ReadKey();
        }

        private bool HandleException(InvalidValueException e)
        {
            Screen.AddMessage(new Message($"{e.Message}", ConsoleColor.Red));
            Screen.Refresh();
            Screen.RemoveLastMessages(1);

            return false;
        }
    }
}