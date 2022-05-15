using System;

namespace Wizards.BusinessLogic.ConsoleDataInput
{
    public static class UserInput
    {
        public static string GetText(int maxLenght = 1000)
        {
            string resultText;
            
            do
            {
                resultText = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(resultText) && resultText.Length > maxLenght)
                {
                    continue;
                }

                break;

            } while (true);

            return resultText;
        }

        public static int GetIntegerNumber(int minValue = Int32.MinValue, int maxValue = Int32.MaxValue)
        {
            int resultNumber;

            do
            {
                string inputText = GetText();

                if (Int32.TryParse(inputText, out resultNumber) && resultNumber >= minValue && resultNumber <= maxValue)
                {
                    break;
                }

            } while (true);
            
            return resultNumber;
        }
    }
}