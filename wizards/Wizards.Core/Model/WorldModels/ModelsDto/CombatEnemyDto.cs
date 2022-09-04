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


    public bool IsEnemyStunned { get; set; }
    public int CurrentEnemyHealth { get; set; }


    public int EnemySelectedSkillId { get; set; }
    public int EnemyBehaviorPatternId { get; set; }
    public int EnemyPatternSequenceStepId { get; set; }
}