using Wizards.Core.Model.UserModels.Enums;
using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Enums;
using Wizards.Core.ModelExtensions;
using Wizards.GamePlay.RandomNumberProvider;
using static Wizards.GamePlay.HelpersAndExtensions.CombatLogicHelpers;

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

        var roundResult = new RoundResult();
        var hitChanceRandomNumbers = (await _randomProvider.GetManyRandomNumbersAsync(1, 100, 2));

        SetGeneralInfo(roundResult, stage);

        roundResult.EnemyWasStunned = stage.IsEnemyStunned;
        roundResult.EnemyCountered = EnemyCountered(stage);
        roundResult.EnemyBlocked = EnemyBlocked(stage);
        roundResult.EnemyMissesAttack = EnemyMissesAttack(stage, hitChanceRandomNumbers.Dequeue());

        roundResult.HeroWasStunned = stage.IsHeroStunned;
        roundResult.HeroWillBeStunned = HeroWillBeStunned(stage.EnemySelectedSkill.Stunning, roundResult.EnemyMissesAttack);
        roundResult.HeroMissesAttack = HeroMissesAttack(stage, hitChanceRandomNumbers.Dequeue());

        roundResult.EnemyDamageTaken = EnemyDamageTaken(stage, roundResult.HeroMissesAttack);
        roundResult.HeroDamageTaken = GetHeroDamageTaken(stage, roundResult.EnemyMissesAttack);

        roundResult.EnemyHealthRecovered = EnemyHealthRecovered(stage);
        roundResult.HeroHealthRecovered = HeroHealthRecovered(stage);

        return roundResult;
    }

    private void SetGeneralInfo(RoundResult roundResult, CombatStage stage)
    {
        roundResult.HeroNickName = stage.Hero.NickName;
        roundResult.EnemyName = stage.Enemy.Name;
        roundResult.HeroSkillType = stage.HeroSelectedSkill.Type;
        roundResult.EnemySkillType = stage.EnemySelectedSkill.SkillType;
    }

    private bool AreBothStunned(CombatStage stage)
    {
        return stage.IsEnemyStunned && stage.IsHeroStunned;
    }

    private bool EnemyCountered(CombatStage stage)
    {
        return (
            !AreBothStunned(stage) &&
            stage.EnemySelectedSkill.SkillType == EnemySkillType.Charge &&
            stage.HeroSelectedSkill.Type == HeroSkillType.CounterAttack);
    }

    private bool EnemyBlocked(CombatStage stage)
    {
        return (
            !AreBothStunned(stage) &&
            stage.EnemySelectedSkill.SkillType != EnemySkillType.Charge &&
            stage.HeroSelectedSkill.Type == HeroSkillType.Block);
    }

    private bool EnemyMissesAttack(CombatStage stage, int randomNumber)
    {
        var finalHitChance = CalculateFinalHitChance(
            stage.Enemy.CalculateSkillHitChance(stage.EnemySelectedSkill),
            stage.Hero.GetCalculatedAttributes().Reflex);

        var hasNoChanceToHit = AttackerHasNoChanceToHit(randomNumber, finalHitChance);

        var enemyMissesAttack = 
            (stage.IsEnemyStunned || EnemyCountered(stage) || EnemyBlocked(stage)) ||
            (hasNoChanceToHit && !stage.IsHeroStunned && !GetEnemySkillsTypesThatCannotMiss().Contains(stage.EnemySelectedSkill.SkillType));

        return enemyMissesAttack;
    }

    private bool HeroWillBeStunned(bool isEnemySkillStunning, bool enemyMissesAttack)
    {
        return (!enemyMissesAttack && isEnemySkillStunning);
    }

    private bool HeroMissesAttack(CombatStage stage, int randomNumber)
    {
        var finalHitChance = CalculateFinalHitChance(
            stage.Hero.CalculateSkillHitChance(stage.HeroSelectedSkill),
            stage.Enemy.EnemyAttributes.Reflex);

        var hasNoChanceToHit = AttackerHasNoChanceToHit(randomNumber, finalHitChance);

        var heroMissesAttack =
            (stage.IsHeroStunned) ||
            (hasNoChanceToHit && !stage.IsEnemyStunned && GetHeroSkillsTypesThatCannotMiss().Contains(stage.HeroSelectedSkill.Type));

        return heroMissesAttack;
    }

    private int GetHeroDamageTaken(CombatStage stage, bool enemyMissesAttack)
    {
        var enemySkillDamage = stage.Enemy.CalculateSkillDamage(stage.EnemySelectedSkill);

        var finalDamageFactor = CalculateFinalDamageFactor(
            stage.Enemy.CalculateSkillArmorPenetrationPercent(stage.EnemySelectedSkill),
            stage.Hero.GetCalculatedAttributes().Defense);

        var finalEnemyDamage = CalculateAttackersDamage(enemySkillDamage, finalDamageFactor);

        return CalculateDefendersDamageTaken(finalEnemyDamage, enemyMissesAttack, stage.IsHeroStunned);
    }

    private int EnemyDamageTaken(CombatStage stage, bool heroMissesAttack)
    {
        var heroDamage = stage.Hero.CalculateSkillDamage(stage.HeroSelectedSkill);

        var finalDamageFactor = CalculateFinalDamageFactor(
            stage.Hero.CalculateSkillArmorPenetrationPercent(stage.HeroSelectedSkill),
            stage.Enemy.EnemyAttributes.Defense);

        var finalHeroDamage = CalculateAttackersDamage(heroDamage, finalDamageFactor);

        return CalculateDefendersDamageTaken(finalHeroDamage, heroMissesAttack, stage.IsEnemyStunned);
    }

    private int HeroHealthRecovered(CombatStage stage)
    {
        var heroSkillHealing = stage.Hero.CalculateSkillHealing(stage.HeroSelectedSkill);

        var finalHealingFactor = CalculateFinalHealingFactor(stage.Hero.GetCalculatedAttributes().Specialization);

        var healersHealing =  CalculateHealersHealing(heroSkillHealing, finalHealingFactor);

        return CalculateRecoveredHealth(healersHealing, stage.IsHeroStunned, stage.IsEnemyStunned);
    }

    private int EnemyHealthRecovered(CombatStage stage)
    {
        var heroSkillHealing = stage.Enemy.CalculateSkillHealing(stage.EnemySelectedSkill);

        var finalHealingFactor = CalculateFinalHealingFactor(stage.Enemy.EnemyAttributes.Specialization);

        var healersHealing = CalculateHealersHealing(heroSkillHealing, finalHealingFactor);

        return CalculateRecoveredHealth(healersHealing, stage.IsHeroStunned, stage.IsEnemyStunned);
    }

    private void CheckIsStageCorrect(CombatStage stage)
    {
        if (stage == null)
        {
            throw new ArgumentNullException(nameof(stage));
        }

        if (stage.Status != StageStatus.DuringCombat)
        {
            throw new ArgumentException("Stage is not in combat!");
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

        if (stage.HeroSelectedSkill == null)
        {
            throw new ArgumentNullException(nameof(stage.HeroSelectedSkill), "There is no Hero skill selected!");
        }

        if (stage.EnemySelectedSkill == null)
        {
            throw new ArgumentNullException(nameof(stage.EnemySelectedSkill), "There is no Enemy skill selected!");
        }
    }
}