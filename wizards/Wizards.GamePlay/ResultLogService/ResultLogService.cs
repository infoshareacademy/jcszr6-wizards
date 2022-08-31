using Wizards.Core.Model.UserModels.Enums;
using Wizards.Core.Model.WorldModels.Enums;
using Wizards.Core.Model.WorldModels.Properties;
using Wizards.GamePlay.CombatService;
using Wizards.GamePlay.CombatService.Enums;

namespace Wizards.GamePlay.ResultLogService;

public class ResultLogService : IResultLogService
{
    public Task<RoundLog> CreateRoundLogAsync(RoundResult roundResult)
    {

        var heroMessage = GetMessageForHero(roundResult);
        var enemyMessage = GetMessageForEnemy(roundResult);

        var roundLog = new RoundLog();

        roundLog.HeroActionLog = heroMessage;
        roundLog.EnemyActionLog = enemyMessage;

        return Task.FromResult(roundLog);
    }

    private string GetMessageForEnemy(RoundResult roundResult)
    {
        var enemy = roundResult.EnemyName;
        var whatDid = "";
        var hero = $" {roundResult.HeroNickName}";
        var withWhat = "";
        var howMuchDamage = "";

        var message = "";

        if (roundResult.EnemyCombatStatus == EnemyCombatStatus.WasStunned)
        {
            message = $"{enemy} was stunned";
        }

        if (roundResult.EnemyCombatStatus == EnemyCombatStatus.Blocked)
        {
            message = $"{enemy} has been blocked by {hero}";
        }

        if (roundResult.EnemyCombatStatus == EnemyCombatStatus.Countered)
        {
            message = $"{enemy} has been countered by {hero}";
        }

        if (roundResult.EnemyCombatStatus == EnemyCombatStatus.MissesAttack)
        {
            message = $"{enemy} misses attack";
        }

        if (roundResult.EnemyCombatStatus == EnemyCombatStatus.HitsSuccessfully)
        {
            whatDid = " hits";
            withWhat = $" with {EnemySkillTypeToString(roundResult.EnemySkillType)}";
            howMuchDamage = roundResult.HeroWillBeStunned ? " stunns" : "";
            howMuchDamage += $" and deals {roundResult.HeroDamageTaken} damage";

        }

        if (roundResult.EnemySkillType == EnemySkillType.Heal)
        {
            whatDid = $" heals himself with {EnemySkillTypeToString(roundResult.EnemySkillType)}";
            hero = "";
            howMuchDamage = $" and recovers {roundResult.EnemyHealthRecovered} health points";
        }

        if (message == "")
        {
            message = $"{enemy}{whatDid}{hero}{withWhat}{howMuchDamage}";
        }

        return message;
    }

    private static string GetMessageForHero(RoundResult roundResult)
    {
        var hero = roundResult.HeroNickName;
        var whatDid = "";
        var enemy = $" {roundResult.EnemyName}";
        var withWhat = "";
        var howMuchDamage = "";
        var message = "";

        if (roundResult.HeroCombatStatus == HeroCombatStatus.WasStunned)
        {
            message = $"{hero} was stunned";
        }

        if (roundResult.EnemyCombatStatus == EnemyCombatStatus.Countered)
        {
            whatDid = " countered";
            withWhat = $" with {HeroSkillTypeToString(roundResult.HeroSkillType)}";
            howMuchDamage = $" and deals {roundResult.EnemyDamageTaken} damage";
        }

        if (roundResult.EnemyCombatStatus == EnemyCombatStatus.Blocked)
        {
            whatDid = " blocked";
            withWhat = $" with {HeroSkillTypeToString(roundResult.HeroSkillType)}";
        }

        if (roundResult.HeroCombatStatus == HeroCombatStatus.MissesAttack)
        {
            message = $"{hero} missed attack";
        }

        if (roundResult.HeroCombatStatus == HeroCombatStatus.HitsSuccessfully)
        {
            whatDid = roundResult.HeroSkillType != HeroSkillType.Block ? " hits" : " did nothing to";
            withWhat = $" with {HeroSkillTypeToString(roundResult.HeroSkillType)}";
            howMuchDamage = $" and deals {roundResult.EnemyDamageTaken} damage";
        }

        if (roundResult.HeroSkillType == HeroSkillType.Heal)
        {
            whatDid = $" heals himself with {HeroSkillTypeToString(roundResult.HeroSkillType)}";
            enemy = "";
            howMuchDamage = $" and recovers {roundResult.HeroHealthRecovered}";
        }

        if (message == "")
        {
            message = $"{hero}{whatDid}{enemy}{withWhat}{howMuchDamage}";
        }

        return message;
    }

    private static string HeroSkillTypeToString(HeroSkillType heroSkillType)
    {
        switch (heroSkillType)
        {
            case HeroSkillType.Block:
                return "block";
            case HeroSkillType.Attack:
                return "attack";
            case HeroSkillType.CounterAttack:
                return "counter attack";
            case HeroSkillType.Heal:
                return "healing skill";
            default:
                return heroSkillType.ToString();
        }
    }

    private static string EnemySkillTypeToString(EnemySkillType enemySkillType)
    {
        switch (enemySkillType)
        {
            case EnemySkillType.Attack:
                return "attack";
            case EnemySkillType.StrongAttack:
                return "strong attack";
            case EnemySkillType.Charge:
                return "charge";
            case EnemySkillType.Deadly:
                return "deadly attack";
            case EnemySkillType.Heal:
                return "healing skill";
            default:
                return enemySkillType.ToString();
        }
    }
}