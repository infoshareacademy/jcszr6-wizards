using System;

namespace Wizards.BusinessLogic.Services.ModelsValidation.ValidationTasks
{
    public interface IDateValidationTask
    {
        ValidationState Validate(DateTime value);
    }
}