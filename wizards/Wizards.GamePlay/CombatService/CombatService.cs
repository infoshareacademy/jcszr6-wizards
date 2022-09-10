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
        roundResult.HeroWillBeStunned = HeroWillBeStunned(stage.CombatEnemy.EnemySelectedSkill.Stunning, roundResult.EnemyCombatStatus);

        roundResult.EnemyDamageTaken = EnemyDamageTaken(stage, roundResult.HeroCombatStatus);
        roundResult.HeroDamageTaken = GetHeroDamageTaken(stage, roundResult.EnemyCombatStatus);

        roundResult.EnemyHealthRecovered = EnemyHealthRecovered(stage);
        roundResult.HeroHealthRecovered = HeroHealthRecovered(stage);

        return roundResult;
    }

    private EnemyCombatStatus GetEnemyCombatStatus(CombatStage stage, int randomNumberForHitChance)
    {
        var result = EnemyCombatStatus.HitsSuccessfully;

        if (stage.CombatEnemy.IsEnemyStunned)
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

        if (stage.CombatHero.IsHeroStunned)
        {
            result = HeroCombatStatus.WasStunned;
        }

        if (HeroMissesAttack(stage, randomNumberForHitChance))
        {
            result = HeroCombatStatus.MissesAttack;
        }

        return result;
    }

    private void SetGeneralInfo(RoundResult roundResult, CombatStage stage)
    {
        roundResult.HeroNickName = stage.CombatHero.NickName;
        roundResult.EnemyName = stage.CombatEnemy.Name;
        roundResult.HeroSkillType = stage.CombatHero.HeroSelectedSkill.Type;
        roundResult.EnemySkillType = stage.CombatEnemy.EnemySelectedSkill.Type;
        roundResult.HeroSkillName = stage.CombatHero.HeroSelectedSkill.Name;
        roundResult.EnemySkillName = stage.CombatEnemy.EnemySelectedSkill.Name;
    }

    private bool AreBothStunned(CombatStage stage)
    {
        return stage.CombatEnemy.IsEnemyStunned && stage.CombatHero.IsHeroStunned;
    }

    private bool EnemyCountered(CombatStage stage)
    {
        return (
            !AreBothStunned(stage) &&
            stage.CombatEnemy.EnemySelectedSkill.Type == EnemySkillType.Charge &&
            stage.CombatHero.HeroSelectedSkill.Type == HeroSkillType.CounterAttack);
    }

    private bool EnemyBlocked(CombatStage stage)
    {
        return (
            !AreBothStunned(stage) &&
            stage.CombatEnemy.EnemySelectedSkill.Type != EnemySkillType.Charge &&
            stage.CombatHero.HeroSelectedSkill.Type == HeroSkillType.Block);
    }

    private bool EnemyMissesAttack(CombatStage stage, int randomNumber)
    {
        var finalHitChance = CalculateFinalHitChance(
            stage.CombatEnemy.EnemySelectedSkill.HitChance,
            stage.CombatHero.Attributes.Reflex);

        var hasNoChanceToHit = AttackerHasNoChanceToHit(randomNumber, finalHitChance);

        var enemyMissesAttack =
            (hasNoChanceToHit && !stage.CombatHero.IsHeroStunned && !GetEnemySkillsTypesThatCannotMiss().Contains(stage.CombatEnemy.EnemySelectedSkill.Type));

        return enemyMissesAttack;
    }

    private bool HeroWillBeStunned(bool isEnemySkillStunning, EnemyCombatStatus enemyCombatStatus)
    {
        var enemyMissesAttack = enemyCombatStatus != EnemyCombatStatus.HitsSuccessfully;
        
        return (!enemyMissesAttack && isEnemySkillStunning);
    }

    private bool HeroMissesAttack(CombatStage stage, int randomNumber)
    {
        var finalHitChance = CalculateFinalHitChance(
            stage.CombatHero.HeroSelectedSkill.HitChance,
            stage.CombatEnemy.Attributes.Reflex);

        var hasNoChanceToHit = AttackerHasNoChanceToHit(randomNumber, finalHitChance);

        var heroMissesAttack =
            (hasNoChanceToHit && !stage.CombatEnemy.IsEnemyStunned && GetHeroSkillsTypesThatCannotMiss().Contains(stage.CombatHero.HeroSelectedSkill.Type));

        return heroMissesAttack;
    }

    private int GetHeroDamageTaken(CombatStage stage, EnemyCombatStatus enemyCombatStatus)
    {
        var enemyMissesAttack = enemyCombatStatus != EnemyCombatStatus.HitsSuccessfully;
        var enemySkillDamage = stage.CombatEnemy.EnemySelectedSkill.Damage;

        var finalDamageFactor = CalculateFinalDamageFactor(
            stage.CombatEnemy.EnemySelectedSkill.ArmorPenetrationPercent,
            stage.CombatHero.Attributes.Defense);

        var finalEnemyDamage = CalculateAttackersDamage(enemySkillDamage, finalDamageFactor);

        return CalculateDefendersDamageTaken(finalEnemyDamage, enemyMissesAttack, stage.CombatHero.IsHeroStunned);
    }

    private int EnemyDamageTaken(CombatStage stage, HeroCombatStatus heroCombatStatus)
    {
        var heroMissesAttack = heroCombatStatus != HeroCombatStatus.HitsSuccessfully;
        var heroDamage = stage.CombatHero.HeroSelectedSkill.Damage;
        
        var finalDamageFactor = CalculateFinalDamageFactor(
            stage.CombatHero.HeroSelectedSkill.ArmorPenetrationPercent,
            stage.CombatEnemy.Attributes.Defense);
        
        var finalHeroDamage = CalculateAttackersDamage(heroDamage, finalDamageFactor);

        return CalculateDefendersDamageTaken(finalHeroDamage, heroMissesAttack, stage.CombatEnemy.IsEnemyStunned);
    }

    private int HeroHealthRecovered(CombatStage stage)
    {
        var heroSkillHealing = stage.CombatHero.HeroSelectedSkill.Healing;
        var finalHealingFactor = CalculateFinalHealingFactor(stage.CombatHero.Attributes.Specialization);
        var healersHealing = CalculateHealersHealing(heroSkillHealing, finalHealingFactor);

        return CalculateRecoveredHealth(healersHealing, stage.CombatHero.IsHeroStunned, stage.CombatEnemy.IsEnemyStunned);
    }

    private int EnemyHealthRecovered(CombatStage stage)
    {
        var heroSkillHealing = stage.CombatEnemy.EnemySelectedSkill.Healing;
        var finalHealingFactor = CalculateFinalHealingFactor(stage.CombatEnemy.Attributes.Specialization);
        var healersHealing = CalculateHealersHealing(heroSkillHealing, finalHealingFactor);

        return CalculateRecoveredHealth(healersHealing, stage.CombatHero.IsHeroStunned, stage.CombatEnemy.IsEnemyStunned);
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

        if (stage.CombatHero.Attributes == null || stage.CombatHero.HeroSkills == null)
        {
            throw new ArgumentNullException(nameof(stage.CombatHero), "Hero is not completed!");
        }

        if (stage.CombatEnemy.Attributes == null || stage.CombatEnemy.Skills == null)
        {
            throw new ArgumentNullException(nameof(stage.CombatEnemy), "Enemy is not completed!");
        }

        if (stage.CombatHero.HeroSelectedSkill == null)
        {
            throw new ArgumentNullException(nameof(stage.CombatHero.HeroSelectedSkill), "There is no Hero skill selected!");
        }

        if (stage.CombatEnemy.EnemySelectedSkill == null)
        {
            throw new ArgumentNullException(nameof(stage.CombatEnemy.EnemySelectedSkill), "There is no Enemy skill selected!");
        }
    }
}