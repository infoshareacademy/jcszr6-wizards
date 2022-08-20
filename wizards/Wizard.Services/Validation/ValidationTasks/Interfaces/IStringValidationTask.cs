using Wizards.Services.Validation.Elements;

namespace Wizards.Services.Validation.ValidationTasks.Interfaces;

public interface IStringValidationTask
{
    ValidationState Validate(string value);
}

public interface IStringAlredyInUse
{
    ValidationState Validate(string value, List<string> usedValues);
}