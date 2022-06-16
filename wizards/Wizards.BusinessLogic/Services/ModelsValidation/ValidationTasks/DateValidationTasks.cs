using System;
using System.Diagnostics.CodeAnalysis;

namespace Wizards.BusinessLogic.Services.ModelsValidation.ValidationTasks
{
    public class DateRange : IDateValidationTask
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateRange(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
        public DateRange() { }

        public ValidationState Validate(DateTime value)
        {
            if (value.Date < StartDate.Date)
            {
                return new ValidationState(false, $"{TextRepository.Get(ValueErrorsMsg.DateToLow)}{StartDate.Date:d}");
            }

            if (value.Date > EndDate.Date)
            {
                return new ValidationState(false, $"{TextRepository.Get(ValueErrorsMsg.DateToHigh)}{EndDate.Date:d}");
            }

            return new ValidationState(true);
        }
    }

    public class RestrictedAge : IDateValidationTask
    {
        public int MinimumAge { get; set; }
        public RestrictedAge(int minimumAge)
        {
            MinimumAge = minimumAge;
        }
        public RestrictedAge() { }
        
        public ValidationState Validate(DateTime value)
        {
            var highestAllowedDateOfBirth = DateTime.Now.Date.AddYears(-MinimumAge);
            if (value.Date > highestAllowedDateOfBirth.Date)
            {
                return new ValidationState(false, TextRepository.Get(ValueErrorsMsg.UserToYoung));
            }

            return new ValidationState(true);
        }
    }
}