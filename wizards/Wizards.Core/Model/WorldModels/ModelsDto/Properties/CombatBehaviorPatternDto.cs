namespace Wizards.Core.Model.WorldModels.ModelsDto.Properties;

public class CombatBehaviorPatternDto
{
    // General
    public int Id { get; set; }

    // Patterns
    public int MinHealthPercentToTrigger { get; set; }
    public int MaxHealthPercentToTrigger { get; set; }
    public Dictionary<int, int> SequenceOfSkillsId { get; set; }
}