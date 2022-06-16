using System.Collections.Generic;

namespace Wizards.BusinessLogic.Services.ModelsValidation.ValidationTasks
{
    public interface IStringValidationTask
    {
        ValidationState Validate(string value);
    }

    public interface IStringAlredyInUse
    {
        ValidationState Validate(string value, List<string> usedValues);
    }
}