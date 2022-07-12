using Wizards.Repository.TextRepo;
using Wizards.Repository.TextRepo.Enums;
using Wizards.Services.Validation.Elements;
using Wizards.Services.Validation.ValidationTasks.Interfaces;

namespace Wizards.Services.Validation.ValidationTasks
{
    public class NumberRange : INumberValidationTask
    {
        public decimal Min { get; set; }
        public decimal Max { get; set; }
        public NumberRange( decimal min, decimal max)
        {
            Min = min;
            Max = max;
        }
        public NumberRange() {}

        public ValidationState Validate(decimal value)
        {
            if (value < Min)
            {
                return new ValidationState(false, $"{TextRepository.Get(ValueErrorsMsg.NumberToLow)}{Min}");
            }

            if (value > Max)
            {
                return new ValidationState(false, $"{TextRepository.Get(ValueErrorsMsg.NumberToHigh)}{Max}");
            }

            return new ValidationState(true);
        }
        public ValidationState Validate(int value)
        {
            decimal decimalValue = value;
            return Validate(decimalValue);
        }

        public ValidationState Validate(double value)
        {
            decimal decimalValue = (decimal)value;
            return Validate(decimalValue);
        }
    }
}