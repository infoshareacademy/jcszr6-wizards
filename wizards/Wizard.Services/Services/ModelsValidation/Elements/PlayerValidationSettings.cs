using System.Collections.Generic;
using Wizards.BusinessLogic.Services.ModelsValidation.ValidationTasks;

namespace Wizards.BusinessLogic.Services.ModelsValidation.Elements
{
    public class PlayerValidationSettings
    {
        public List<IStringValidationTask> UserNameTasks { get; set; }
        public List<IStringValidationTask> PasswordTasks { get; set; }
        public List<IStringValidationTask> EmailTasks { get; set; }
        public List<IDateValidationTask> DateOfBirthTasks { get; set; }
        public IStringAlredyInUse AlredyInUseTask { get; set; }

        public PlayerValidationSettings() { }
    }
}