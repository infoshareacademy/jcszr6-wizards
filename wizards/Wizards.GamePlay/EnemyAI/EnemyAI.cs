using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.ModelsDto;
using Wizards.Core.Model.WorldModels.ModelsDto.Properties;
using Wizards.Core.ModelExtensions;

namespace Wizards.GamePlay.EnemyAI;

public class EnemyAI : IEnemyAI
{
    public Task SelectNextEnemyActionAsync(CombatStage stage)
    {
        var enemy = stage.CombatEnemy;

        int currentEnemyHealthPercent = GetEnemyCurrentHealthPercent(enemy);

        var previousEnemyPattern = enemy.BehaviorPatterns.SingleOrDefault(bp => bp.Id == enemy.EnemyBehaviorPatternId);
        var nextEnemyPattern = enemy.BehaviorPatterns.SingleOrDefault(p => p.MinHealthPercentToTrigger > currentEnemyHealthPercent && p.MaxHealthPercentToTrigger <= currentEnemyHealthPercent);

        var previousEnemyPatternSequenceStepId = enemy.EnemyPatternSequenceStepId;
        var nextEnemyPatternSequenceStepId = 0;

        var arePatternsTheSame = previousEnemyPattern.Id == nextEnemyPattern.Id;

        if (previousEnemyPatternSequenceStepId < nextEnemyPattern.SequenceOfSkillsId.Keys.Max() && arePatternsTheSame)
        {
            nextEnemyPatternSequenceStepId = previousEnemyPatternSequenceStepId + 1;          
        }

        SetNewStageStatus(enemy, nextEnemyPattern, nextEnemyPatternSequenceStepId);

        return Task.CompletedTask;
    }

    private static void SetNewStageStatus(CombatEnemyDto enemy, CombatBehaviorPatternDto nextEnemyPattern, int nextEnemyPatternSequenceStepId)
    {
        enemy.EnemySelectedSkillId = nextEnemyPattern.SequenceOfSkillsId[nextEnemyPatternSequenceStepId];
        enemy.EnemyPatternSequenceStepId = nextEnemyPattern.Id;
        enemy.EnemyBehaviorPatternId = nextEnemyPatternSequenceStepId;
        enemy.EnemySelectedSkill = enemy.GetEnemySelectedSkill();
    }

    private static int GetEnemyCurrentHealthPercent(CombatEnemyDto enemy)
    {
        var currentEnemyHealth = enemy.CurrentEnemyHealth;
        var maxEnemyHealth = enemy.Attributes.MaxHealth;
        var currentHealthPercent = (int)Math.Round((((double)currentEnemyHealth / maxEnemyHealth) * 100), 0);
        return currentHealthPercent;
    }
}