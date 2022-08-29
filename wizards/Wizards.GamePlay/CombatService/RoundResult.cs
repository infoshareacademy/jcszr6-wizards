using Wizards.Core.Model.UserModels.Enums;
using Wizards.Core.Model.WorldModels.Enums;
using Wizards.GamePlay.CombatService.Enums;

namespace Wizards.GamePlay.CombatService;

public class RoundResult
{
    // Hero report
    public string HeroNickName { get; set; }
    public HeroSkillType HeroSkillType { get; set; }

    public int HeroDamageTaken { get; set; }
    public int HeroHealthRecovered { get; set; }
    public bool HeroWillBeStunned { get; set; }
    public HeroCombatStatus HeroCombatStatus { get; set; }

    // Enemy report
    public string EnemyName { get; set; }
    public EnemySkillType EnemySkillType { get; set; }
    
    public int EnemyDamageTaken { get; set; }
    public int EnemyHealthRecovered { get; set; }
    public bool EnemyWillBeStunned { get; set; }
    public EnemyCombatStatus EnemyCombatStatus { get; set; }
}