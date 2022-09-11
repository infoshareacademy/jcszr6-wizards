using Wizards.Core.Model.WorldModels.Enums;
using Wizards.Core.Model.WorldModels.ModelsDto.Properties;

namespace Wizards.Core.Model.WorldModels.ModelsDto;

public class CombatEnemyDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public EnemyType Type { get; set; }
    public int AvatarImageNumber { get; set; }

    public CombatEnemyAttributesDto Attributes { get; set; }
    public List<CombatEnemySkillDto> Skills { get; set; }
    public List<CombatBehaviorPatternDto> BehaviorPatterns { get; set; }
    public CombatEnemySkillDto SelectedSkill { get; set; }
    public int SelectedSkillId { get; set; }

    public bool IsStunned { get; set; }
    public int CurrentHealth { get; set; }

    public int CurrentBehaviorPatternId { get; set; }
    public int CurrentPatternSequenceStepId { get; set; }

    public int GoldReward { get; set; }
}