using Wizards.Core.Model.WorldModels;

namespace Wizards.GamePlay.EnemiesAI;

public class EnemyAI : IEnemyAI
{
    public Task GetEnemySelectedSkillIdAsync(CombatStage stage)
    {
        var enemy = stage.Enemy;

        int currentEnemyHealthPercent = GetEnemyCurrentHealthPercent(stage, enemy);

        var previousEnemyPattern = enemy.BehaviorPatterns.SingleOrDefault(bp => bp.Id == stage.EnemyBehaviorPatternId);
        var nextEnemyPattern = enemy.BehaviorPatterns.SingleOrDefault(p => p.MinHealthPercentToTrigger > currentEnemyHealthPercent && p.MaxHealthPercentToTrigger <= currentEnemyHealthPercent);

        var previousEnemyPatternSequenceStepId = stage.EnemyPatternSequenceStepId;
        var nextEnemyPatternSequenceStepId = 0;

        var arePaternsTheSame = previousEnemyPattern.Id == nextEnemyPattern.Id;

        if (previousEnemyPatternSequenceStepId < nextEnemyPattern.SequenceOfSkillsId.Keys.Max() && arePaternsTheSame)
        {
            nextEnemyPatternSequenceStepId = previousEnemyPatternSequenceStepId + 1;          
        }

        SetNewStageStatus(stage, nextEnemyPattern, nextEnemyPatternSequenceStepId);

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