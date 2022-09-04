using Wizards.Core.Model.WorldModels.Enums;

namespace Wizards.Core.Model.WorldModels.ModelsDto.Properties;

public class CombatEnemySkillDto
{
    // General
    public int Id { get; set; }
    public string Name { get; set; }
    public EnemySkillType Type { get; set; }

    // Combat
    public int Damage { get; set; }
    public int HitChance { get; set; }
    public int ArmorPenetrationPercent { get; set; }
    public int Healing { get; set; }

    // Another effects
    public bool Stunning { get; set; }
}