using System;

namespace Wizards.BusinessLogic
{
    public class ValueConverter
    {
        public int ToIntNumber(string textToconvert)
        {
            int number;
            
            if (Int32.TryParse(textToconvert, out number))
            {
                return number;
            }
            
            throw new InvalidValueException(TextRepository.Get(ValueErrorsMsg.IsNotNumber));
        }

        public DateTime ToDate(int day, int month, int year)
        {
            DateTime date;

            if (DateTime.TryParse($"{day}-{month}-{year}", out date))
            {
                return date;
            }

            throw new InvalidValueException(TextRepository.Get(ValueErrorsMsg.DateNotCorrect));

        }

    }
}