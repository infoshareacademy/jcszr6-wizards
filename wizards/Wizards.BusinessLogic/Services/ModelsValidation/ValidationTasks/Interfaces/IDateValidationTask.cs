using System;
using Wizards.BusinessLogic.Services.ModelsValidation.Elements;

namespace Wizards.BusinessLogic.Services.ModelsValidation.ValidationTasks
{
    public interface IDateValidationTask
    {
        ValidationState Validate(DateTime value);
    }
}