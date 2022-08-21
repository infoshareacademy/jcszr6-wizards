using Wizards.Repository.TextRepo;
using Wizards.Repository.TextRepo.Enums;
using Wizards.Services.Validation.Elements;
using Wizards.Services.Validation.ValidationTasks.Interfaces;

namespace Wizards.Services.Validation.ValidationTasks;
public class DateMin : IDateValidationTask
{
    public DateTime Date { get; set; }

    public DateMin(DateTime startDate)
    {
        Date = startDate;
    }
    public DateMin() { }

    public ValidationState Validate(DateTime value)
    {
        if (value.Date < Date.Date)
        {
            return new ValidationState(false, $"{TextRepository.Get(ValueErrorsMsg.DateToLow)}{Date.Date:d}");
        }

        return new ValidationState(true);
    }
}
public class DateMax : IDateValidationTask
{
    public DateTime Date { get; set; }
    public DateMax(DateTime maxDate)
    {
        Date = maxDate;
    }
    public DateMax() { }

    public ValidationState Validate(DateTime value)
    {
        if (value.Date > Date.Date)
        {
            return new ValidationState(false, $"{TextRepository.Get(ValueErrorsMsg.DateToHigh)}{Date.Date:d}");
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
            return new ValidationState(false, $"{TextRepository.Get(ValueErrorsMsg.UserToYoung)}{MinimumAge}");
        }

        return new ValidationState(true);
    }
}

public class DateIsNotNull : IDateValidationTask
{
    public DateIsNotNull() { }

    public ValidationState Validate(DateTime value)
    {
        if (value == null)
        {
            return new ValidationState(false, $"{TextRepository.Get(ValueErrorsMsg.IsNull)}");
        }

        return new ValidationState(true);
    }
}