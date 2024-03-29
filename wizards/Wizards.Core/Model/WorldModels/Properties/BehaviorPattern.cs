﻿namespace Wizards.Core.Model.WorldModels.Properties;

public class BehaviorPattern
{
    // General
    public int Id { get; set; }

    // Patterns
    public int MinHealthPercentToTrigger { get; set; }
    public int MaxHealthPercentToTrigger { get; set; }
    public List<SkillSequenceStep> SequenceOfSkillsId { get; set; }

    // Db relations properties
    public Enemy Enemy { get; set; }
    public int EnemyId { get; set; }
}