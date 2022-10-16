using System.Collections;
using Wizards.Core.Model.UserModels.Enums;
using Wizards.Core.Model.WorldModels.Enums;
using Wizards.Core.Model.WorldModels.Properties;
using Wizards.Core.Model.WorldModels.Properties.Enums;


namespace Wizards.Tests.GamePlayTests;

public class ResultLogServiceTestsData : IEnumerable<object[]>
{

    public IEnumerator<object[]> GetEnumerator()

    {
        RoundResult roundResult = new();
        RoundLog roundLog = new();

        roundResult.HeroNickName = "hero";
        roundResult.HeroSkillName = "heroSkill";
        roundResult.HeroSkillType = HeroSkillType.Attack;
        roundResult.HeroDamageTaken = 1;
        roundResult.HeroHealthRecovered = 1;
        roundResult.HeroWillBeStunned = false;
        roundResult.HeroCombatStatus = HeroCombatStatus.WasStunned;
        roundResult.EnemyName = "enemy";
        roundResult.EnemySkillName = "enemySkill";
        roundResult.EnemySkillType = EnemySkillType.Attack;
        roundResult.EnemyDamageTaken = 1;
        roundResult.EnemyHealthRecovered = 1;
        roundResult.EnemyWillBeStunned = false;
        roundResult.EnemyCombatStatus = EnemyCombatStatus.WasStunned;

        roundLog.HeroActionLog = "hero was stunned";
        roundLog.EnemyActionLog = "enemy was stunned";

        yield return new object[] { roundResult, roundLog };

        roundResult.EnemyCombatStatus = EnemyCombatStatus.Blocked;
        roundLog.EnemyActionLog = "enemy has been blocked by hero";
        yield return new object[] { roundResult, roundLog };

        roundResult.EnemyCombatStatus = EnemyCombatStatus.Countered;
        roundLog.EnemyActionLog = "enemy has been countered by hero";
        yield return new object[] { roundResult, roundLog };

        roundResult.EnemyCombatStatus = EnemyCombatStatus.HitsSuccessfully;
        roundLog.EnemyActionLog = "enemy hits hero with enemySkill (attack) and deals 1 damage";
        yield return new object[] { roundResult, roundLog };

        roundResult.EnemySkillType = EnemySkillType.Heal;
        roundLog.EnemyActionLog = "enemy heals himself with enemySkill (healing skill) and recovers 1 health points";
        yield return new object[] { roundResult, roundLog };

        roundResult.EnemyCombatStatus = EnemyCombatStatus.Countered;
        roundResult.HeroCombatStatus = HeroCombatStatus.HitsSuccessfully;
        roundLog.EnemyActionLog = "enemy has been countered by hero";
        roundLog.HeroActionLog = "hero counters enemy with heroSkill (attack) and deals 1 damage";
        yield return new object[] { roundResult, roundLog };

        roundResult.EnemyCombatStatus = EnemyCombatStatus.Blocked;
        roundLog.EnemyActionLog = "enemy has been blocked by hero";
        roundLog.HeroActionLog = "hero bocks enemy with heroSkill (attack)";
        yield return new object[] { roundResult, roundLog };

        roundResult.EnemyCombatStatus = EnemyCombatStatus.WasStunned;
        roundResult.HeroCombatStatus = HeroCombatStatus.MissesAttack;
        roundLog.EnemyActionLog = "enemy was stunned";
        roundLog.HeroActionLog = "hero misses";
        yield return new object[] { roundResult, roundLog };

        roundResult.HeroCombatStatus = HeroCombatStatus.HitsSuccessfully;
        roundLog.HeroActionLog = "hero hits enemy with heroSkill (attack) and deals 1 damage";
        yield return new object[] { roundResult, roundLog };

        roundResult.HeroSkillType = HeroSkillType.Block;
        roundLog.HeroActionLog = "hero did nothing to enemy with heroSkill (block) and deals 1 damage";
        yield return new object[] { roundResult, roundLog };

        roundResult.HeroSkillType = HeroSkillType.Heal;
        roundLog.HeroActionLog = "hero heals himself with heroSkill (healing skill) and recovers 1 health points";
        yield return new object[] { roundResult, roundLog };


    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}