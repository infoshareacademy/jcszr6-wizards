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

        var previousEnemyPatternId = enemy.CurrentBehaviorPatternId;
        var nextEnemyPattern = enemy.BehaviorPatterns.SingleOrDefault(p => p.MinHealthPercentToTrigger < currentEnemyHealthPercent && p.MaxHealthPercentToTrigger >= currentEnemyHealthPercent);

        if (nextEnemyPattern is null)
        {
            throw new NullReferenceException("There is no correct pattern!");
        }

        var previousEnemyPatternSequenceStepId = enemy.CurrentPatternSequenceStepId;
        var nextEnemyPatternSequenceStepId = 1;

        var arePatternsTheSame = previousEnemyPatternId == nextEnemyPattern.Id;

        if (previousEnemyPatternSequenceStepId < nextEnemyPattern.SequenceOfSkillsId.Max(seq => seq.SequenceStepId) && arePatternsTheSame)
        {
            nextEnemyPatternSequenceStepId = previousEnemyPatternSequenceStepId + 1;          
        }

        SetNewStageStatus(enemy, nextEnemyPattern, nextEnemyPatternSequenceStepId);

        return Task.CompletedTask;
    }

    private static void SetNewStageStatus(CombatEnemyDto enemy, CombatBehaviorPatternDto nextEnemyPattern, int nextEnemyPatternSequenceStepId)
    {
        var step = nextEnemyPattern.SequenceOfSkillsId.SingleOrDefault(seq => seq.SequenceStepId == nextEnemyPatternSequenceStepId);

        if (step is null)
        {
            throw new NullReferenceException("Skill Step Sequence Not Found");
        }
        enemy.SelectedSkillId = step.SkillId;
        enemy.CurrentPatternSequenceStepId = nextEnemyPatternSequenceStepId;
        enemy.CurrentBehaviorPatternId = nextEnemyPattern.Id;
        enemy.SelectedSkill = enemy.GetEnemySelectedSkill();
    }

    private static int GetEnemyCurrentHealthPercent(CombatEnemyDto enemy)
    {
        var currentEnemyHealth = enemy.CurrentHealth;
        var maxEnemyHealth = enemy.Attributes.MaxHealth;
        var currentHealthPercent = (int)Math.Round((((double)currentEnemyHealth / maxEnemyHealth) * 100), 0, MidpointRounding.ToPositiveInfinity);
        return currentHealthPercent;
    }
}