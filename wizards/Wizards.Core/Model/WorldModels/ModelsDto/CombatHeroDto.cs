using Wizards.Core.Model.UserModels.Enums;
using Wizards.Core.Model.WorldModels.ModelsDto.Properties;

namespace Wizards.Core.Model.WorldModels.ModelsDto;

public class CombatHeroDto
{
    public int Id { get; set; }
    public string NickName { get; set; }
    public HeroProfession Profession { get; set; }
    public int AvatarImageNumber { get; set; }

    public int EquippedWeaponId { get; set; }
    public double WeaponUsage { get; set; }
    public int EquippedArmorId { get; set; }
    public double ArmorUsage { get; set; }

    public CombatHeroAttributesDto Attributes { get; set; }
    public List<CombatHeroSkillDto> Skills { get; set; }

    public bool IsStunned { get; set; }
    public int CurrentHealth { get; set; }
    public CombatHeroSkillDto SelectedSkill { get; set; }
    public int SelectedSkillId { get; set; }
}