using Wizards.Core.Model.UserModels.Enums;
using Wizards.Core.Model.WorldModels.Enums;
using Wizards.Core.Model.WorldModels.Properties;
using Wizards.Core.Model.WorldModels.Properties.Enums;
using Wizards.GamePlay.CombatService;


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
            message = $"{enemy} misses";
        }

        if (roundResult.EnemyCombatStatus == EnemyCombatStatus.HitsSuccessfully)
        {
            whatDid = " hits";
            withWhat = $" with {roundResult.EnemySkillName} ({EnemySkillTypeToString(roundResult.EnemySkillType)})";
            var stuns = roundResult.HeroWillBeStunned ? ", stuns" : "";
            howMuchDamage = $"{stuns} and deals {roundResult.HeroDamageTaken} damage";
        }

        if (roundResult.EnemySkillType == EnemySkillType.Heal)
        {
            whatDid = " heals";
            hero = " himself";
            withWhat = $" with {roundResult.EnemySkillName} ({EnemySkillTypeToString(roundResult.EnemySkillType)})";
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
            whatDid = " counters";
            withWhat = $" with {roundResult.HeroSkillName} ({HeroSkillTypeToString(roundResult.HeroSkillType)})";
            howMuchDamage = $" and deals {roundResult.EnemyDamageTaken} damage";
            message = $"{hero}{whatDid}{enemy}{withWhat}{howMuchDamage}";
        }

        if (roundResult.EnemyCombatStatus == EnemyCombatStatus.Blocked)
        {
            whatDid = " blocks";
            withWhat = $" with {roundResult.HeroSkillName} ({HeroSkillTypeToString(roundResult.HeroSkillType)})";
            message = $"{hero}{whatDid}{enemy}{withWhat}{howMuchDamage}";
        }

        if (roundResult.HeroCombatStatus == HeroCombatStatus.MissesAttack)
        {
            message = $"{hero} misses";
        }

        if (roundResult.HeroCombatStatus == HeroCombatStatus.HitsSuccessfully)
        {
            whatDid = roundResult.HeroSkillType != HeroSkillType.Block ? " hits" : " did nothing to";
            withWhat = $" with {roundResult.HeroSkillName} ({HeroSkillTypeToString(roundResult.HeroSkillType)})";
            howMuchDamage = $" and deals {roundResult.EnemyDamageTaken} damage";
        }

        if (roundResult.HeroSkillType == HeroSkillType.Heal)
        {
            whatDid = " heals";
            enemy = " himself";
            withWhat = $" with {roundResult.HeroSkillName} ({HeroSkillTypeToString(roundResult.HeroSkillType)})";
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