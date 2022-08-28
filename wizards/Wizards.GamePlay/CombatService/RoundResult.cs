using Wizards.Core.Model.UserModels.Enums;
using Wizards.Core.Model.WorldModels.Enums;

namespace Wizards.GamePlay.CombatService;

public class RoundResult
{
    // Hero report
    public string HeroNickName { get; set; }
    public HeroSkillType HeroSkillType { get; set; }

    public int HeroDamageTaken { get; set; }
    public int HeroHealthRecovered { get; set; }
    public bool HeroWillBeStunned { get; set; }
    public bool HeroMissesAttack { get; set; }
    public bool HeroWasStunned { get; set; }

    // Enemy report
    public string EnemyName { get; set; }
    public EnemySkillType EnemySkillType { get; set; }
    
    public int EnemyDamageTaken { get; set; }
    public int EnemyHealthRecovered { get; set; }
    public bool EnemyMissesAttack { get; set; }
    public bool EnemyBlocked { get; set; }
    public bool EnemyCountered { get; set; }
    public bool EnemyWasStunned { get; set; }
}