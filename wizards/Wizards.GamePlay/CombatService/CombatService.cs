using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.UserModels.Enums;
using Wizards.Core.Model.UserModels.Properties;
using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Enums;
using Wizards.Core.Model.WorldModels.Properties;
using Wizards.Core.ModelExtensions;

namespace Wizards.GamePlay.CombatService;

public class CombatService : ICombatService
{
    private HeroSkill HeroSelectedSkill { get; set; }
    private EnemySkill EnemySelectedSkill { get; set; }
    private HeroAttributes CalculatedHeroAttributes { get; set; }
    private RoundResult RoundResult { get; set; } = new RoundResult();


    public Task<RoundResult> CalculateRoundAsync(CombatStage stage)
    {
        CheckIsStageCorrect(stage);
        SetProperties(stage);

        RoundResult.HeroNickName = stage.Hero.NickName;
        RoundResult.HeroSkillType = HeroSelectedSkill.Skill.Type;
        RoundResult.EnemyName = stage.Enemy.Name;
        RoundResult.EnemySkillType = EnemySelectedSkill.SkillType;

        RoundResult.EnemyWasUnableToAct = stage.IsEnemyStunned;
        RoundResult.HeroWasUnableToAct = stage.IsHeroStunned;

        RoundResult.EnemyWasCountered = (
            !stage.IsEnemyStunned &&
            !stage.IsHeroStunned &&
            EnemySelectedSkill.SkillType == EnemySkillType.Charge &&
            HeroSelectedSkill.Skill.Type == HeroSkillType.CounterAttack);

        RoundResult.EnemyWasBlocked = (
            !stage.IsEnemyStunned &&
            !stage.IsHeroStunned &&
            EnemySelectedSkill.SkillType != EnemySkillType.Charge &&
            HeroSelectedSkill.Skill.Type == HeroSkillType.Block);

        RoundResult.EnemyMissesAttack = EnemyMissesAttack(stage);


        return Task.FromResult(RoundResult);
    }

    private bool EnemyMissesAttack(CombatStage stage)
    {
        var rnd = new Random();

        var randomNumber = rnd.Next();

        var finalHitChance = stage.Enemy.EnemyAttributes.Precision + EnemySelectedSkill.BaseHitChance - CalculatedHeroAttributes.Reflex;

        var hasNoChanceToHit = finalHitChance <= 0 || randomNumber > finalHitChance;

        var result = (
                !stage.IsHeroStunned &&
                !RoundResult.EnemyWasBlocked &&
                !RoundResult.EnemyWasCountered &&
                EnemySelectedSkill.SkillType != EnemySkillType.Deadly &&
                hasNoChanceToHit) || stage.IsEnemyStunned;
        
        return result;
    }

    private void SetProperties(CombatStage stage)
    {
        HeroSelectedSkill = stage.Hero.Skills.SingleOrDefault(s => s.Id == stage.HeroSelectedSkillId);
        EnemySelectedSkill = stage.Enemy.Skills.SingleOrDefault(s => s.Id == stage.EnemySelectedSkillId);
        CalculatedHeroAttributes = stage.Hero.GetCalculatedAttributes();

        if (HeroSelectedSkill == null || EnemySelectedSkill == null)
        {
            throw new ArgumentException("Stage has wrong selected actions!", nameof(stage));
        }
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