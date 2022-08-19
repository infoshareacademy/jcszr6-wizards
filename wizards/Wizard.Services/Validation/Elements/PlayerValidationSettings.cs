using Wizards.Services.Validation.ValidationTasks.Interfaces;

namespace Wizards.Services.Validation.Elements;
public class PlayerValidationSettings
{
    public List<IStringValidationTask> UserNameTasks { get; set; }
    public List<IStringValidationTask> PasswordTasks { get; set; }
    public List<IStringValidationTask> EmailTasks { get; set; }
    public List<IDateValidationTask> DateOfBirthTasks { get; set; }
    public IStringAlredyInUse AlredyInUseTask { get; set; }
}