using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Properties;

namespace Wizards.GamePlay.HelpersAndExtensions;

public static class StageExtensions
{
    public static Skill GetHeroSelectedSkill(this CombatStage stage)
    {
        var selectedHeroSkill = stage.Hero.Skills.SingleOrDefault(s => s.Id == stage.HeroSelectedSkillId);

        if (selectedHeroSkill == null)
        {
            throw new ArgumentNullException(nameof(stage.HeroSelectedSkillId), "Hero has wrong selected actions!");
        }

        if (selectedHeroSkill.Skill == null)
        {
            throw new ArgumentException("HeroSKill has no Skill object!", nameof(stage.HeroSelectedSkillId));
        }

        return selectedHeroSkill.Skill;
    }

    public static EnemySkill GetEnemySelectedSkill(this CombatStage stage)
    {
        var selectedEnemySkill = stage.Enemy.Skills.SingleOrDefault(s => s.Id == stage.EnemySelectedSkillId);

        if (selectedEnemySkill == null)
        {
            throw new ArgumentNullException(nameof(stage.HeroSelectedSkillId), "Enemy has wrong selected actions!");
        }

        return selectedEnemySkill;
    }
}