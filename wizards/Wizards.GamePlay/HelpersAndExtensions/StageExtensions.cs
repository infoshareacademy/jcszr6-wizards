using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Properties;

namespace Wizards.GamePlay.HelpersAndExtensions;

public static class StageExtensions
{
    public static HeroSkill GetHeroSelectedSkill(this CombatStage stage)
    {
        var selectedHeroSkill = stage.Hero.Skills.SingleOrDefault(s => s.Id == stage.HeroSelectedSkillId);

        if (selectedHeroSkill == null)
        {
            throw new ArgumentException("Hero has wrong selected actions!", nameof(stage.HeroSelectedSkillId));
        }

        return selectedHeroSkill;
    }

    public static EnemySkill GetEnemySelectedSkill(this CombatStage stage)
    {
        var selectedEnemySkill = stage.Enemy.Skills.SingleOrDefault(s => s.Id == stage.EnemySelectedSkillId);

        if (selectedEnemySkill == null)
        {
            throw new ArgumentException("Enemy has wrong selected actions!", nameof(stage.EnemySelectedSkillId));
        }

        return selectedEnemySkill;
    }
}