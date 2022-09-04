using Wizards.Core.Model.UserModels.Enums;

namespace Wizards.Core.Model.WorldModels.ModelsDto.Properties;

public class CombatHeroSkillDto
{
    public string Name { get; set; }
    public HeroSkillType Type { get; set; }

    public int Damage { get; set; }
    public int HitChance { get; set; }
    public int ArmorPenetrationPercent { get; set; }
    public int Healing { get; set; }
}