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

    private CombatStage Stage { get; set; }
    private RoundResult RoundResult { get; set; } = new RoundResult();

    public CombatService(IRandomNumberProvider randomProvider)
    {
        _randomProvider = randomProvider;
    }

    public async Task<RoundResult> CalculateRoundAsync(CombatStage stage)
    {
        CheckIsStageCorrect(stage);
        Stage = stage;

        SetGeneralInRoundResult();
        
        RoundResult.EnemyWasStunned = Stage.IsEnemyStunned;
        RoundResult.HeroWasStunned = Stage.IsHeroStunned;

        var number = await _randomProvider.GetRandomNumberAsync(1, 100);
        RoundResult.EnemyCountered = EnemyCountered();
        RoundResult.EnemyBlocked = EnemyBlocked();
        RoundResult.EnemyMissesAttack = EnemyMissesAttack(number);

        number = await _randomProvider.GetRandomNumberAsync(1, 100);
        RoundResult.HeroWillBeStunned = HeroWillBeStunned();
        RoundResult.HeroMissesAttack = HeroMissesAttack(number);

        RoundResult.EnemyDamageTaken = EnemyDamageTaken();
        RoundResult.HeroDamageTaken = GetHeroDamageTaken();

        return RoundResult;
    }

    private void SetGeneralInRoundResult()
    {
        RoundResult.HeroNickName = Stage.Hero.NickName;
        RoundResult.EnemyName = Stage.Enemy.Name;
        RoundResult.HeroSkillType = GetSelectedHeroSkill().Skill.Type;
        RoundResult.EnemySkillType = GetSelectedEnemySkill().SkillType;
    }

    private bool EnemyCountered()
    {
        return (
            !Stage.IsEnemyStunned &&
            !Stage.IsHeroStunned &&
            GetSelectedEnemySkill().SkillType == EnemySkillType.Charge &&
            GetSelectedHeroSkill().Skill.Type == HeroSkillType.CounterAttack);
    }

    private bool EnemyBlocked()
    {
        return (
            !Stage.IsEnemyStunned &&
            !Stage.IsHeroStunned &&
            GetSelectedEnemySkill().SkillType != EnemySkillType.Charge &&
            GetSelectedHeroSkill().Skill.Type == HeroSkillType.Block);
    }

    private bool EnemyMissesAttack(int randomNumber)
    {
        var enemyPrecision = Stage.Enemy.EnemyAttributes.Precision;
        var enemySkillBaseHitChance = GetSelectedEnemySkill().BaseHitChance;
        var heroCalculatedReflex = Stage.Hero.GetCalculatedAttributes().Reflex;
        
        var finalHitChance = enemyPrecision + enemySkillBaseHitChance - heroCalculatedReflex;
        
        var hasNoChanceToHit = finalHitChance <= 0 || randomNumber > finalHitChance;

        var enemyMissesAttack =
            (Stage.IsEnemyStunned || EnemyCountered() || EnemyBlocked()) ||
            (hasNoChanceToHit && !Stage.IsHeroStunned && GetSelectedEnemySkill().SkillType != EnemySkillType.Deadly);
        
        return enemyMissesAttack;
    }

    private int GetHeroDamageTaken()
    {
        var EnemyDamage = Stage.Enemy.GetCalculatedSkillDamage(GetSelectedEnemySkill());

        var finalDamageFactor = GetFinalDamageFactor(
            Stage.Enemy.GetCalculatedSkillArmorPenetrationPercent(GetSelectedEnemySkill()), 
            Stage.Hero.GetCalculatedAttributes().Defense);

        var finalEnemyDamage = (int)Math.Round(EnemyDamage * finalDamageFactor, 0 , MidpointRounding.AwayFromZero);

        if (!RoundResult.EnemyMissesAttack && !Stage.IsHeroStunned && finalEnemyDamage > 0)
        {
            return finalEnemyDamage;
        }
        
        if (!RoundResult.EnemyMissesAttack && Stage.IsHeroStunned && finalEnemyDamage > 0)
        {
            return finalEnemyDamage * 2;
        }

        return 0;
    }

    private bool HeroWillBeStunned()
    {
        return (
            !RoundResult.EnemyMissesAttack && 
            GetSelectedEnemySkill().Stunning);
    }

    private bool HeroMissesAttack(int number)
    {
        var heroSkillHitChance = Stage.Hero.GetCalculatedSkillHitChance(GetSelectedHeroSkill().Skill);
        var enemyReflex = Stage.Enemy.EnemyAttributes.Reflex;

        var finalHitChance = heroSkillHitChance - enemyReflex;

        var hasNoChanceToHit = number > finalHitChance || finalHitChance <= 0;

        var heroMissesAttack =
            (hasNoChanceToHit && Stage.IsEnemyStunned) ||
            (Stage.IsHeroStunned);

        return heroMissesAttack;
    }
    
    private int EnemyDamageTaken()
    {
        var heroDamage = Stage.Enemy.GetCalculatedSkillDamage(GetSelectedEnemySkill());

        var finalDamageFactor = GetFinalDamageFactor(
            Stage.Hero.GetCalculatedSkillArmorPenetrationPercent(GetSelectedHeroSkill().Skill),
            Stage.Enemy.EnemyAttributes.Defense);

        var finalHeroDamage = (int)Math.Round(heroDamage * finalDamageFactor, 0, MidpointRounding.AwayFromZero);

        if (!RoundResult.HeroMissesAttack && !Stage.IsEnemyStunned && finalHeroDamage > 0)
        {
            return finalHeroDamage;
        }

        if (!RoundResult.HeroMissesAttack && Stage.IsEnemyStunned && finalHeroDamage > 0)
        {
            return finalHeroDamage * 2;
        }

        return 0;
    }


    // Second Tier Helpers
    private double GetFinalDamageFactor(int attackersArmorPenetrationPercent, int defendersTotalDefense)
    {
        var finalDamageFactor = (100d
                                 + attackersArmorPenetrationPercent
                                 - defendersTotalDefense) / 100d;

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

    private HeroSkill GetSelectedHeroSkill()
    {
        var selectedHeroSkill = Stage.Hero.Skills.SingleOrDefault(s => s.Id == Stage.HeroSelectedSkillId);

        if (selectedHeroSkill == null)
        {
            throw new ArgumentException("Hero has wrong selected actions!", nameof(Stage.HeroSelectedSkillId));
        }

        return selectedHeroSkill;
    }

    private EnemySkill GetSelectedEnemySkill()
    {
        var selectedEnemySkill = Stage.Enemy.Skills.SingleOrDefault(s => s.Id == Stage.EnemySelectedSkillId);

        if (selectedEnemySkill == null)
        {
            throw new ArgumentException("Enemy has wrong selected actions!", nameof(Stage.EnemySelectedSkillId));
        }

        return selectedEnemySkill;
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