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
        // TODO: Healing value for Hero and Enemy (uwaga trzeba wtedy ustawić defendera na pusty string)
        // TODO: Połączona wiadomość dla Enemy na końcu metody message = "{kto} {komu} ..."
        // TODO: Dodać przypisanie do "attacker" oraz "defender" w obu metodach
        // TODO: Dodać sytuację w której skill przeciwnika stunnuje bohatera
        // TODO: Przy efektach na Enemy typu Countered dodać "by {hero}"
        // TODO: Korekta Spacji w mergu stringa!
        // TODO: Kiedy hero Kontruje Enemy trzeba dodać do wiadomości zadane obrażenia!

        var heroMessage = GetMessageForHero(roundResult);
        var enemyMessage = GetMessageForEnemy(roundResult);

        var roundLog = new RoundLog();

        roundLog.HeroActionLog = heroMessage;
        roundLog.EnemyActionLog = enemyMessage;

        return Task.FromResult(roundLog);
    }

    private string GetMessageForEnemy(RoundResult roundResult)
    {
        var enemy = "";
        var whatDid = "";
        var hero = "";
        var howMuchDamage = "";

        var message = "";

        if (roundResult.EnemyCombatStatus == EnemyCombatStatus.WasStunned)
        {
            message = $"{enemy} was stunned";
        }

        if (roundResult.EnemyCombatStatus == EnemyCombatStatus.Blocked)
        {
            message = $"{enemy} has been blocked";
        }

        if (roundResult.EnemyCombatStatus == EnemyCombatStatus.Countered)
        {
            message = $"{enemy} has been countered";
        }

        if (roundResult.EnemyCombatStatus == EnemyCombatStatus.MissesAttack)
        {
            message = $"{enemy} misses attack";
        }

        if (roundResult.EnemyCombatStatus == EnemyCombatStatus.HitsSuccessfully)
        {
            whatDid = $"hits with {EnemySkillTypeToString(roundResult.EnemySkillType)}";
            howMuchDamage = $"and deals {roundResult.EnemyDamageTaken} damage"; // KOREKTA! HeroDamageTaken bo to Enemy zadaje obrażenia Hero!
        }

        return message;
    }

    private static string GetMessageForHero(RoundResult roundResult)
    {
        var attacker = "";
        var whatDid = "";
        var defender = "";
        var howMuchDamage = "";

        var message = "";

        if (roundResult.HeroCombatStatus == HeroCombatStatus.WasStunned)
        {
            message = $"{attacker} was stunned";
        }

        if (roundResult.EnemyCombatStatus == EnemyCombatStatus.Countered)
        {
            whatDid = "countered";
        }

        if (roundResult.EnemyCombatStatus == EnemyCombatStatus.Blocked)
        {
            whatDid = "blocked";
        }

        if (roundResult.HeroCombatStatus == HeroCombatStatus.MissesAttack)
        {
            whatDid = "missed attack";
        }

        if (roundResult.HeroCombatStatus == HeroCombatStatus.HitsSuccessfully)
        {
            whatDid = $"hits with {HeroSkillTypeToString(roundResult.HeroSkillType)}";
            howMuchDamage = $"and deals {roundResult.EnemyDamageTaken} damage";
        }

        if (message == "")
        {
            message = $"{attacker} {whatDid} {defender} {howMuchDamage}";
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