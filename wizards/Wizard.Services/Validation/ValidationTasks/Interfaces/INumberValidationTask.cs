using Wizards.Services.Validation.Elements;

namespace Wizards.Services.Validation.ValidationTasks.Interfaces
{
    public interface INumberValidationTask
    {
        ValidationState Validate(int value);
        ValidationState Validate(double value);
        ValidationState Validate(decimal value);
    }
}