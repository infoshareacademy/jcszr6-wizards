using Wizards.Core.Model.UserModels.Enums;
using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Enums;
using Wizards.Core.Model.WorldModels.Properties;
using Wizards.Core.Model.WorldModels.Properties.Enums;
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

        roundResult.EnemyCombatStatus = GetEnemyCombatStatus(stage, hitChanceRandomNumbers.Dequeue());
        roundResult.HeroCombatStatus = GetHeroCombatStatus(stage, hitChanceRandomNumbers.Dequeue());

        roundResult.EnemyWillBeStunned = EnemyCountered(stage);
        roundResult.HeroWillBeStunned = HeroWillBeStunned(stage, roundResult.EnemyCombatStatus);

        roundResult.EnemyDamageTaken = EnemyDamageTaken(stage, roundResult.HeroCombatStatus);
        roundResult.HeroDamageTaken = GetHeroDamageTaken(stage, roundResult.EnemyCombatStatus);

        roundResult.EnemyHealthRecovered = EnemyHealthRecovered(stage);
        roundResult.HeroHealthRecovered = HeroHealthRecovered(stage);

        return roundResult;
    }

    private EnemyCombatStatus GetEnemyCombatStatus(CombatStage stage, int randomNumberForHitChance)
    {
        var result = EnemyCombatStatus.HitsSuccessfully;

        if (stage.CombatEnemy.IsStunned)
        {
            result = EnemyCombatStatus.WasStunned;
        }
        else if (EnemyCountered(stage))
        {
            result = EnemyCombatStatus.Countered;
        }
        else if (EnemyBlocked(stage))
        {
            result = EnemyCombatStatus.Blocked;
        }
        else if (EnemyMissesAttack(stage, randomNumberForHitChance))
        {
            result = EnemyCombatStatus.MissesAttack;
        }

        return result;
    }

    private HeroCombatStatus GetHeroCombatStatus(CombatStage stage, int randomNumberForHitChance)
    {
        var result = HeroCombatStatus.HitsSuccessfully;

        if (stage.CombatHero.IsStunned)
        {
            result = HeroCombatStatus.WasStunned;
        }
        else if (HeroMissesAttack(stage, randomNumberForHitChance))
        {
            result = HeroCombatStatus.MissesAttack;
        }

        return result;
    }

    private void SetGeneralInfo(RoundResult roundResult, CombatStage stage)
    {
        roundResult.HeroNickName = stage.CombatHero.NickName;
        roundResult.EnemyName = stage.CombatEnemy.Name;
        roundResult.HeroSkillType = stage.CombatHero.SelectedSkill.Type;
        roundResult.EnemySkillType = stage.CombatEnemy.SelectedSkill.Type;
        roundResult.HeroSkillName = stage.CombatHero.SelectedSkill.Name;
        roundResult.EnemySkillName = stage.CombatEnemy.SelectedSkill.Name;
    }

    private bool IsAnyoneOfThemStunned(CombatStage stage)
    {
        return stage.CombatEnemy.IsStunned || stage.CombatHero.IsStunned;
    }

    private bool EnemyCountered(CombatStage stage)
    {
        return (
            !IsAnyoneOfThemStunned(stage) &&
            stage.CombatEnemy.SelectedSkill.Type == EnemySkillType.Charge &&
            stage.CombatHero.SelectedSkill.Type == HeroSkillType.CounterAttack);
    }

    private bool EnemyBlocked(CombatStage stage)
    {
        return (
            !IsAnyoneOfThemStunned(stage) &&
            stage.CombatEnemy.SelectedSkill.Type != EnemySkillType.Charge &&
            stage.CombatEnemy.SelectedSkill.Type != EnemySkillType.Deadly && 
            stage.CombatHero.SelectedSkill.Type == HeroSkillType.Block);
    }

    private bool EnemyMissesAttack(CombatStage stage, int randomNumber)
    {
        var finalHitChance = CalculateFinalHitChance(
            stage.CombatEnemy.SelectedSkill.HitChance,
            stage.CombatHero.Attributes.Reflex);

        var hasNoChanceToHit = AttackerHasNoChanceToHit(randomNumber, finalHitChance);

        var enemyMissesAttack =
            (hasNoChanceToHit && !stage.CombatHero.IsStunned && !GetEnemySkillsTypesThatCannotMiss().Contains(stage.CombatEnemy.SelectedSkill.Type));

        return enemyMissesAttack;
    }

    private bool HeroWillBeStunned(CombatStage stage, EnemyCombatStatus enemyCombatStatus)
    {
        var hits = enemyCombatStatus == EnemyCombatStatus.HitsSuccessfully;
        var skillStunning = stage.CombatEnemy.SelectedSkill.Type == EnemySkillType.Stunning;
        var skillIsCharge = stage.CombatEnemy.SelectedSkill.Type == EnemySkillType.Charge;

        return (hits && (skillStunning || skillIsCharge));
    }

    private bool HeroMissesAttack(CombatStage stage, int randomNumber)
    {
        var finalHitChance = CalculateFinalHitChance(
            stage.CombatHero.SelectedSkill.HitChance,
            stage.CombatEnemy.Attributes.Reflex);

        var hasNoChanceToHit = AttackerHasNoChanceToHit(randomNumber, finalHitChance);

        var heroMissesAttack =
            (hasNoChanceToHit && !stage.CombatEnemy.IsStunned && !GetHeroSkillsTypesThatCannotMiss().Contains(stage.CombatHero.SelectedSkill.Type));

        return heroMissesAttack;
    }

    private int GetHeroDamageTaken(CombatStage stage, EnemyCombatStatus enemyCombatStatus)
    {
        var enemyMissesAttack = enemyCombatStatus != EnemyCombatStatus.HitsSuccessfully;
        var enemySkillDamage = stage.CombatEnemy.SelectedSkill.Damage;

        var finalDamageFactor = CalculateFinalDamageFactor(
            stage.CombatEnemy.SelectedSkill.ArmorPenetrationPercent,
            stage.CombatHero.Attributes.Defense);

        var finalEnemyDamage = CalculateAttackersDamage(enemySkillDamage, finalDamageFactor);

        return CalculateDefendersDamageTaken(finalEnemyDamage, enemyMissesAttack, stage.CombatHero.IsStunned);
    }

    private int EnemyDamageTaken(CombatStage stage, HeroCombatStatus heroCombatStatus)
    {
        var heroMissesAttack = heroCombatStatus != HeroCombatStatus.HitsSuccessfully;
        var heroDamage = stage.CombatHero.SelectedSkill.Damage;
        
        var finalDamageFactor = CalculateFinalDamageFactor(
            stage.CombatHero.SelectedSkill.ArmorPenetrationPercent,
            stage.CombatEnemy.Attributes.Defense);
        
        var finalHeroDamage = CalculateAttackersDamage(heroDamage, finalDamageFactor);

        return CalculateDefendersDamageTaken(finalHeroDamage, heroMissesAttack, stage.CombatEnemy.IsStunned);
    }

    private int HeroHealthRecovered(CombatStage stage)
    {
        var heroSkillHealing = stage.CombatHero.SelectedSkill.Healing;
        var finalHealingFactor = CalculateFinalHealingFactor(stage.CombatHero.Attributes.Specialization);
        var healersHealing = CalculateHealersHealing(heroSkillHealing, finalHealingFactor);

        return CalculateRecoveredHealth(healersHealing, stage.CombatHero.IsStunned, stage.CombatEnemy.IsStunned);
    }

    private int EnemyHealthRecovered(CombatStage stage)
    {
        var heroSkillHealing = stage.CombatEnemy.SelectedSkill.Healing;
        var finalHealingFactor = CalculateFinalHealingFactor(stage.CombatEnemy.Attributes.Specialization);
        var healersHealing = CalculateHealersHealing(heroSkillHealing, finalHealingFactor);

        return CalculateRecoveredHealth(healersHealing, stage.CombatEnemy.IsStunned, stage.CombatHero.IsStunned);
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

        if (stage.CombatHero == null)
        {
            throw new ArgumentNullException(nameof(stage.CombatHero));
        }

        if (stage.CombatEnemy == null)
        {
            throw new ArgumentNullException(nameof(stage.CombatEnemy));
        }

        if (stage.CombatHero.Attributes == null || stage.CombatHero.Skills == null)
        {
            throw new ArgumentNullException(nameof(stage.CombatHero), "Hero is not completed!");
        }

        if (stage.CombatEnemy.Attributes == null || stage.CombatEnemy.Skills == null)
        {
            throw new ArgumentNullException(nameof(stage.CombatEnemy), "Enemy is not completed!");
        }

        if (stage.CombatHero.SelectedSkill == null)
        {
            throw new ArgumentNullException(nameof(stage.CombatHero.SelectedSkill), "There is no Hero skill selected!");
        }

        if (stage.CombatEnemy.SelectedSkill == null)
        {
            throw new ArgumentNullException(nameof(stage.CombatEnemy.SelectedSkill), "There is no Enemy skill selected!");
        }
    }
}