using Wizards.Core.Model.WorldModels;

namespace Wizards.GamePlay.EnemiesAI;

public class EnemyAI : IEnemyAI
{
    public Task GetEnemySelectedSkillIdAsync(CombatStage stage)
    {

        var enemy = stage.Enemy;

        int currentHealthPercent = GetEnemyCurrentHealthPercent(stage, enemy);

        var nextEnemyPattern = enemy.BehaviorPatterns.SingleOrDefault(p => p.MinHealthPercentToTrigger > currentHealthPercent && p.MaxHealthPercentToTrigger <= currentHealthPercent);

        var previousEnemyPatternId = stage.EnemyBehaviorPatternId;

        if (previousEnemyPatternId != nextEnemyPattern.Id)
        {
            SetNewStageStatus(stage, nextEnemyPattern, 0);
            return Task.CompletedTask;
        }
        nextEnemyPattern = enemy.BehaviorPatterns.SingleOrDefault(p => p.Id == previousEnemyPatternId);

        var previousEnemyPatternSequenceStepId = stage.EnemyPatternSequenceStepId;

        var isMaxStep = previousEnemyPatternSequenceStepId == nextEnemyPattern.SequenceOfSkillsId.Keys.Max();

        if (isMaxStep)
        {
            SetNewStageStatus(stage, nextEnemyPattern, 0);
            return Task.CompletedTask;
        }

        var newEnemyPatternSequenceStepId = previousEnemyPatternSequenceStepId + 1;

        SetNewStageStatus(stage, nextEnemyPattern, newEnemyPatternSequenceStepId);

        return Task.CompletedTask;
    }

    private static void SetNewStageStatus(CombatStage stage, Core.Model.WorldModels.Properties.BehaviorPattern? nextEnemyPattern, int newEnemyPatternSequenceStepId)
    {
        stage.EnemySelectedSkillId = nextEnemyPattern.SequenceOfSkillsId[newEnemyPatternSequenceStepId];
        stage.EnemyPatternSequenceStepId = nextEnemyPattern.Id;
        stage.EnemyBehaviorPatternId = newEnemyPatternSequenceStepId;
    }

    private static int GetEnemyCurrentHealthPercent(CombatStage stage, Enemy enemy)
    {
        var currentEnemyHealth = stage.CurrentEnemyHealth;
        var maxEnemyHealth = enemy.Attributes.MaxHealth;
        var currentHealthPercent = (int)Math.Round((((double)currentEnemyHealth / maxEnemyHealth) * 100), 0);
        return currentHealthPercent;
    }
}