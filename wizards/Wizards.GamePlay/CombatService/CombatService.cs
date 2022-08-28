using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.UserModels.Enums;
using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Enums;
using Wizards.Core.Model.WorldModels.Properties;
using Wizards.Core.ModelExtensions;
using Wizards.GamePlay.HelpersAndExtensions;
using Wizards.GamePlay.RandomNumberProvider;

namespace Wizards.GamePlay.CombatService;

public class CombatService : ICombatService
{
    private readonly IRandomNumberProvider _randomProvider;

    private HeroSkill HeroSelectedSkill { get; set; }
    private EnemySkill EnemySelectedSkill { get; set; }

    public CombatService(IRandomNumberProvider randomProvider)
    {
        _randomProvider = randomProvider;
    }

    public async Task<RoundResult> CalculateRoundAsync(CombatStage stage)
    {
        CheckIsStageCorrect(stage);
        EnemySelectedSkill = stage.GetEnemySelectedSkill();
        HeroSelectedSkill = stage.GetHeroSelectedSkill();

        var roundResult = new RoundResult();
        var randomNumbers = (await _randomProvider.GetManyRandomNumbersAsync(1, 100, 2));

        SetGeneralInfo(roundResult, stage);

        roundResult.EnemyWasStunned = stage.IsEnemyStunned;
        roundResult.EnemyCountered = EnemyCountered(stage);
        roundResult.EnemyBlocked = EnemyBlocked(stage);
        roundResult.EnemyMissesAttack = EnemyMissesAttack(stage, randomNumbers[1]);

        roundResult.HeroWasStunned = stage.IsHeroStunned;
        roundResult.HeroWillBeStunned = HeroWillBeStunned(EnemySelectedSkill.Stunning, roundResult.EnemyMissesAttack);
        roundResult.HeroMissesAttack = HeroMissesAttack(stage, randomNumbers[2]);

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
        roundResult.HeroSkillType = HeroSelectedSkill.Skill.Type;
        roundResult.EnemySkillType = EnemySelectedSkill.SkillType;
    }

    private bool AreBothStunned(CombatStage stage)
    {
        return stage.IsEnemyStunned && stage.IsHeroStunned;
    }

    private bool EnemyCountered(CombatStage stage)
    {
        return (
            !AreBothStunned(stage) &&
            EnemySelectedSkill.SkillType == EnemySkillType.Charge &&
            HeroSelectedSkill.Skill.Type == HeroSkillType.CounterAttack);
    }

    private bool EnemyBlocked(CombatStage stage)
    {
        return (
            !AreBothStunned(stage) &&
            EnemySelectedSkill.SkillType != EnemySkillType.Charge &&
            HeroSelectedSkill.Skill.Type == HeroSkillType.Block);
    }

    private bool EnemyMissesAttack(CombatStage stage, int randomNumber)
    {
        var finalHitChance = CombatLogicHelpers.CalculateFinalHitChance(
            stage.Enemy.CalculateSkillHitChance(EnemySelectedSkill),
            stage.Hero.GetCalculatedAttributes().Reflex);

        var hasNoChanceToHit = CombatLogicHelpers.AttackerHasNoChanceToHit(randomNumber, finalHitChance);

        var enemyMissesAttack =
            (stage.IsEnemyStunned || EnemyCountered(stage) || EnemyBlocked(stage)) ||
            (hasNoChanceToHit && !stage.IsHeroStunned && !CombatLogicHelpers.GetEnemySkillsTypesThatCannotMiss().Contains(EnemySelectedSkill.SkillType));

        return enemyMissesAttack;
    }

    private bool HeroWillBeStunned(bool isEnemySkillStunning, bool enemyMissesAttack)
    {
        return (!enemyMissesAttack && isEnemySkillStunning);
    }

    private bool HeroMissesAttack(CombatStage stage, int randomNumber)
    {
        var finalHitChance = CombatLogicHelpers.CalculateFinalHitChance(
            stage.Hero.CalculateSkillHitChance(HeroSelectedSkill.Skill),
            stage.Enemy.EnemyAttributes.Reflex);

        var hasNoChanceToHit = CombatLogicHelpers.AttackerHasNoChanceToHit(randomNumber, finalHitChance);

        var heroMissesAttack =
            (stage.IsHeroStunned) ||
            (hasNoChanceToHit && !stage.IsEnemyStunned && CombatLogicHelpers.GetHeroSkillsTypesThatCannotMiss().Contains(HeroSelectedSkill.Skill.Type));

        return heroMissesAttack;
    }

    private int GetHeroDamageTaken(CombatStage stage, bool enemyMissesAttack)
    {
        var enemySkillDamage = stage.Enemy.CalculateSkillDamage(EnemySelectedSkill);

        var finalDamageFactor = CombatLogicHelpers.CalculateFinalDamageFactor(
            stage.Enemy.CalculateSkillArmorPenetrationPercent(EnemySelectedSkill),
            stage.Hero.GetCalculatedAttributes().Defense);

        var finalEnemyDamage = CombatLogicHelpers.CalculateAttackersDamage(enemySkillDamage, finalDamageFactor);

        return CombatLogicHelpers.CalculateDefendersDamageTaken(finalEnemyDamage, enemyMissesAttack, stage.IsHeroStunned);
    }

    private int EnemyDamageTaken(CombatStage stage, bool heroMissesAttack)
    {
        var heroDamage = stage.Hero.CalculateSkillDamage(HeroSelectedSkill.Skill);

        var finalDamageFactor = CombatLogicHelpers.CalculateFinalDamageFactor(
            stage.Hero.CalculateSkillArmorPenetrationPercent(HeroSelectedSkill.Skill),
            stage.Enemy.EnemyAttributes.Defense);

        var finalHeroDamage = CombatLogicHelpers.CalculateAttackersDamage(heroDamage, finalDamageFactor);

        return CombatLogicHelpers.CalculateDefendersDamageTaken(finalHeroDamage, heroMissesAttack, stage.IsEnemyStunned);
    }

    private int HeroHealthRecovered(CombatStage stage)
    {
        var heroSkillHealing = stage.Hero.CalculateSkillHealing(HeroSelectedSkill.Skill);

        var finalHealingFactor = CombatLogicHelpers.CalculateFinalHealingFactor(stage.Hero.GetCalculatedAttributes().Specialization);

        var healersHealing =  CombatLogicHelpers.CalculateHealersHealing(heroSkillHealing, finalHealingFactor);

        return CombatLogicHelpers.CalculateRecoveredHealth(healersHealing, stage.IsHeroStunned, stage.IsEnemyStunned);
    }

    private int EnemyHealthRecovered(CombatStage stage)
    {
        var heroSkillHealing = stage.Enemy.CalculateSkillHealing(EnemySelectedSkill);

        var finalHealingFactor = CombatLogicHelpers.CalculateFinalHealingFactor(stage.Enemy.EnemyAttributes.Specialization);

        var healersHealing = CombatLogicHelpers.CalculateHealersHealing(heroSkillHealing, finalHealingFactor);

        return CombatLogicHelpers.CalculateRecoveredHealth(healersHealing, stage.IsHeroStunned, stage.IsEnemyStunned);
    }

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