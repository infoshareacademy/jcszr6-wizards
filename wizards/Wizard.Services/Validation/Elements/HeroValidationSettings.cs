using Wizards.Services.Validation.ValidationTasks.Interfaces;

namespace Wizards.Services.Validation.Elements;

public class HeroValidationSettings
{
    public List<IStringValidationTask> NickNameTasks { get; set; }
    public List<INumberValidationTask> AvatarTasks { get; set; }
    public List<INumberValidationTask> ProfessionTasks { get; set; }
    public IStringAlredyInUse AlredyInUseTask { get; set; }
}