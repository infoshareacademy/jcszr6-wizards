﻿using Wizards.Core.Model.UserModels.Enums;
using Wizards.Core.Model.WorldModels.Enums;
using Wizards.Core.Model.WorldModels.Properties.Enums;

namespace Wizards.Core.Model.WorldModels.Properties;

public class RoundResult
{
    // Hero report
    public string HeroNickName { get; set; }
    public string HeroSkillName { get; set; }
    public HeroSkillType HeroSkillType { get; set; }

    public int HeroDamageTaken { get; set; }
    public int HeroHealthRecovered { get; set; }
    public bool HeroWillBeStunned { get; set; }
    public HeroCombatStatus HeroCombatStatus { get; set; }

    // Enemy report
    public string EnemyName { get; set; }
    public string EnemySkillName { get; set; }
    public EnemySkillType EnemySkillType { get; set; }
    
    public int EnemyDamageTaken { get; set; }
    public int EnemyHealthRecovered { get; set; }
    public bool EnemyWillBeStunned { get; set; }
    public EnemyCombatStatus EnemyCombatStatus { get; set; }
}