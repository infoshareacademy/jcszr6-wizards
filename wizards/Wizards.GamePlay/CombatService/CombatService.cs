using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.UserModels.Enums;
using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Enums;
using Wizards.Core.Model.WorldModels.Properties;
using Wizards.Core.ModelExtensions;
using Wizards.GamePlay.RandomNumberProvider;

namespace Wizards.GamePlay.CombatService;

public class CombatService : ICombatService
{
    private readonly IRandomNumberProvider _randomProvider;

    public CombatService(IRandomNumberProvider randomProvider)
    {
        _randomProvider = randomProvider;
    }

    public async Task<RoundResult> CalculateRoundAsync(CombatStage stage)
    {
        CheckIsStageCorrect(stage);

        var enemySelectedSkill = GetEnemySelectedSkill(stage);

        var roundResult = new RoundResult();
        SetGeneralInfo(roundResult, stage);

        roundResult.EnemyWasStunned = stage.IsEnemyStunned;
        roundResult.HeroWasStunned = stage.IsHeroStunned;

        var randomNumber = await _randomProvider.GetRandomNumberAsync(1, 100);
        roundResult.EnemyCountered = EnemyCountered(stage);
        roundResult.EnemyBlocked = EnemyBlocked(stage);
        roundResult.EnemyMissesAttack = EnemyMissesAttack(stage, randomNumber);

        randomNumber = await _randomProvider.GetRandomNumberAsync(1, 100);
        roundResult.HeroWillBeStunned = HeroWillBeStunned(enemySelectedSkill.Stunning, roundResult.EnemyMissesAttack);
        roundResult.HeroMissesAttack = HeroMissesAttack(stage, randomNumber);

        roundResult.EnemyDamageTaken = EnemyDamageTaken(stage, roundResult.HeroMissesAttack);
        roundResult.HeroDamageTaken = GetHeroDamageTaken(stage, roundResult.EnemyMissesAttack);

        return roundResult;
    }

    private void SetGeneralInfo(RoundResult roundResult, CombatStage stage)
    {
        roundResult.HeroNickName = stage.Hero.NickName;
        roundResult.EnemyName = stage.Enemy.Name;
        roundResult.HeroSkillType = GetHeroSelectedSkill(stage).Skill.Type;
        roundResult.EnemySkillType = GetEnemySelectedSkill(stage).SkillType;
    }

    private bool EnemyCountered(CombatStage stage)
    {
        return (
            !AreBothStunned(stage) &&
            GetEnemySelectedSkill(stage).SkillType == EnemySkillType.Charge &&
            GetHeroSelectedSkill(stage).Skill.Type == HeroSkillType.CounterAttack);
    }

    private bool EnemyBlocked(CombatStage stage)
    {
        return (
            !AreBothStunned(stage) &&
            GetEnemySelectedSkill(stage).SkillType != EnemySkillType.Charge &&
            GetHeroSelectedSkill(stage).Skill.Type == HeroSkillType.Block);
    }

    private bool EnemyMissesAttack(CombatStage stage, int randomNumber)
    {
        var finalHitChance = CalculateFinalHitChance(
            stage.Enemy.GetCalculatedSkillHitChance(GetEnemySelectedSkill(stage)),
            stage.Hero.GetCalculatedAttributes().Reflex);

        var hasNoChanceToHit = HasNoChanceToHit(randomNumber, finalHitChance);

        var enemyMissesAttack =
            (stage.IsEnemyStunned || EnemyCountered(stage) || EnemyBlocked(stage)) ||
            (hasNoChanceToHit && !stage.IsHeroStunned && !GetEnemySkillsTypesThatCannotMiss().Contains(GetEnemySelectedSkill(stage).SkillType));

        return enemyMissesAttack;
    }

    private bool HeroMissesAttack(CombatStage stage, int randomNumber)
    {
        var finalHitChance = CalculateFinalHitChance(
            stage.Hero.GetCalculatedSkillHitChance(GetHeroSelectedSkill(stage).Skill),
            stage.Enemy.EnemyAttributes.Reflex);

        var hasNoChanceToHit = HasNoChanceToHit(randomNumber, finalHitChance);

        var heroMissesAttack =
            (stage.IsHeroStunned) ||
            (hasNoChanceToHit && !stage.IsEnemyStunned && GetHeroSkillsTypesThatCannotMiss().Contains(GetHeroSelectedSkill(stage).Skill.Type));

        return heroMissesAttack;
    }

    private int GetHeroDamageTaken(CombatStage stage, bool enemyMissesAttack)
    {
        var enemyDamage = stage.Enemy.GetCalculatedSkillDamage(GetEnemySelectedSkill(stage));

        var finalDamageFactor = CalculateFinalDamageFactor(
            stage.Enemy.GetCalculatedSkillArmorPenetrationPercent(GetEnemySelectedSkill(stage)),
            stage.Hero.GetCalculatedAttributes().Defense);

        var finalEnemyDamage = CalculateAttackersDamage(enemyDamage, finalDamageFactor);

        return CalculateDefendersDamageTaken(finalEnemyDamage, enemyMissesAttack, stage.IsHeroStunned);
    }

    private int EnemyDamageTaken(CombatStage stage, bool heroMissesAttack)
    {
        var heroDamage = stage.Enemy.GetCalculatedSkillDamage(GetEnemySelectedSkill(stage));

        var finalDamageFactor = CalculateFinalDamageFactor(
            stage.Hero.GetCalculatedSkillArmorPenetrationPercent(GetHeroSelectedSkill(stage).Skill),
            stage.Enemy.EnemyAttributes.Defense);

        var finalHeroDamage = CalculateAttackersDamage(heroDamage, finalDamageFactor);

        return CalculateDefendersDamageTaken(finalHeroDamage, heroMissesAttack, stage.IsEnemyStunned);
    }


    // Candidates for Helpers
    private static bool HasNoChanceToHit(int randomNumber, int finalHitChance)
    {
        return finalHitChance <= 0 || randomNumber > finalHitChance;
    }

    private static int CalculateFinalHitChance(int attackersCalculatedSkillHitChance, int defenderReflex)
    {
        return attackersCalculatedSkillHitChance - defenderReflex;
    }

    private static double CalculateFinalDamageFactor(int attackersSkillArmorPenetrationPercent, int defendersTotalDefense)
    {
        var finalDamageFactor = (100d + attackersSkillArmorPenetrationPercent - defendersTotalDefense) / 100d;

        if (finalDamageFactor >= 1.10d)
        {
            finalDamageFactor = 1.10d;
        }
        else if (finalDamageFactor <= 0d)
        {
            finalDamageFactor = 0d;
        }

        return finalDamageFactor;
    }

    private static int CalculateAttackersDamage(int attackerDamage, double finalDamageFactor)
    {
        return (int)Math.Round(attackerDamage * finalDamageFactor, 0, MidpointRounding.AwayFromZero);
    }

    private static int CalculateDefendersDamageTaken(int calculatedAttackersDamage, bool attackerMissesAttack, bool isDefenderStunned)
    {
        if (!attackerMissesAttack && !isDefenderStunned && calculatedAttackersDamage > 0)
        {
            return calculatedAttackersDamage;
        }

        if (!attackerMissesAttack && isDefenderStunned && calculatedAttackersDamage > 0)
        {
            return calculatedAttackersDamage * 2;
        }

        return 0;
    }

    private static bool HeroWillBeStunned(bool isEnemySkillStunning, bool enemyMissesAttack)
    {
        return (!enemyMissesAttack && isEnemySkillStunning);
    }

    private static List<EnemySkillType> GetEnemySkillsTypesThatCannotMiss()
    {
        return new List<EnemySkillType>() { EnemySkillType.Deadly, EnemySkillType.Charge, };
    }

    private static List<HeroSkillType> GetHeroSkillsTypesThatCannotMiss()
    {
        return new List<HeroSkillType>() { HeroSkillType.Block, HeroSkillType.Heal};
    }


    // Candidates for Extensions
    private HeroSkill GetHeroSelectedSkill(CombatStage stage)
    {
        var selectedHeroSkill = stage.Hero.Skills.SingleOrDefault(s => s.Id == stage.HeroSelectedSkillId);

        if (selectedHeroSkill == null)
        {
            throw new ArgumentException("Hero has wrong selected actions!", nameof(stage.HeroSelectedSkillId));
        }

        return selectedHeroSkill;
    }

    private EnemySkill GetEnemySelectedSkill(CombatStage stage)
    {
        var selectedEnemySkill = stage.Enemy.Skills.SingleOrDefault(s => s.Id == stage.EnemySelectedSkillId);

        if (selectedEnemySkill == null)
        {
            throw new ArgumentException("Enemy has wrong selected actions!", nameof(stage.EnemySelectedSkillId));
        }

        return selectedEnemySkill;
    }

    private bool AreBothStunned(CombatStage stage)
    {
        return stage.IsEnemyStunned && stage.IsHeroStunned;
    }


    // Check method for incoming CombatStageObject
    private void CheckIsStageCorrect(CombatStage stage)
    {
        if (stage == null)
        {
            throw new ArgumentNullException(nameof(stage));
        }

        if (!stage.InUse)
        {
            throw new ArgumentException("Stage is not in use!");
        }

        if (stage.Hero == null)
        {
            throw new ArgumentNullException(nameof(stage.Hero));
        }

        if (stage.Enemy == null)
        {
            throw new ArgumentNullException(nameof(stage.Enemy));
        }

        if (stage.Hero.Inventory == null || stage.Hero.Attributes == null || stage.Hero.Skills == null)
        {
            throw new ArgumentNullException(nameof(stage.Hero), "Hero is not completed!");
        }

        if (stage.Enemy.EnemyAttributes == null || stage.Enemy.Skills == null)
        {
            throw new ArgumentNullException(nameof(stage.Enemy), "Enemy is not completed!");
        }
    }
}