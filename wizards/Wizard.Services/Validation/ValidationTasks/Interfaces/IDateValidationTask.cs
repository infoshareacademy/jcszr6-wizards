using Wizards.Services.Validation.Elements;

namespace Wizards.Services.Validation.ValidationTasks.Interfaces;
public interface IDateValidationTask
{
    ValidationState Validate(DateTime value);
}