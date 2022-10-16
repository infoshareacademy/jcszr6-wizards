using Wizards.Core.Model.WorldModels.Enums;

namespace Wizards.Core.Model.WorldModels.Properties;

public class EnemySkill
{
    // General
    public int Id { get; set; }
    public string Name { get; set; }
    public EnemySkillType Type { get; set; }

    // Combat
    public double DamageFactor { get; set; }
    public int BaseHitChance { get; set; }
    public int ArmorPenetrationPercent { get; set; }
    public double HealingFactor { get; set; }

    // Db relations properties
    public Enemy Enemy { get; set; }
    public int EnemyId { get; set; }
}