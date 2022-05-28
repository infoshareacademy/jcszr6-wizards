using System;
using Wizards.BusinessLogic;

namespace Wizards.GUI
{
    public class UserInput
    {
        private ValueValidator _validator;
        private Screen _screen;

        public string GetText()
        {
            bool isValid;
            string result;

            do
            {
                result = Console.ReadLine();

                try
                {
                    isValid = _validator.Validate(result);
                }
                catch (InvalidValueException e)
                {
                    isValid = false;
                    _screen.AddMessage(new Message(e.Message,ConsoleColor.Red));
                    _screen.Refresh();
                }
            } while (!isValid);

            return result;
        }

        public int GetNumber()
        {
            bool isValid;
            int result;

            do
            {
                
                result = new ValueConverter().ToIntNumber(Console.ReadLine());

                try
                {
                    isValid = _validator.Validate(result);
                }
                catch (InvalidValueException e)
                {
                    isValid = false;
                    _screen.AddMessage(new Message(e.Message, ConsoleColor.Red));
                    _screen.Refresh();
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
                    isValid = _validator.Validate(result, expectedKeys);
                }
                catch (InvalidValueException e)
                {
                    isValid = false;
                    _screen.AddMessage(new Message(e.Message, ConsoleColor.Red));
                    _screen.Refresh();
                }

            } while (!isValid);

            return result;
        }
    }
}