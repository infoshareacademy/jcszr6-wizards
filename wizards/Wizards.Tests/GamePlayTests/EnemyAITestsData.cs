using System.Collections;
using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.ModelsDto;
using Wizards.Core.Model.WorldModels.ModelsDto.Properties;
using Wizards.Core.Model.WorldModels.Properties;

namespace Wizards.Tests.GamePlayTests;

public class EnemyAITestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        CombatStage combatStage = new();
        CombatEnemyDto combatEnemyDto = new();

        combatStage.CombatEnemy = new CombatEnemyDto();
        combatStage.CombatEnemy.CurrentHealth = 100;
        combatStage.CombatEnemy.Attributes = new CombatEnemyAttributesDto() { MaxHealth = 100 };
        combatStage.CombatEnemy.CurrentBehaviorPatternId = 1;
        combatStage.CombatEnemy.BehaviorPatterns = new List<CombatBehaviorPatternDto>();

        combatStage.CombatEnemy.BehaviorPatterns.Add(new CombatBehaviorPatternDto() { Id = 1, MaxHealthPercentToTrigger = 100, MinHealthPercentToTrigger = 50, SequenceOfSkillsId = new List<SkillSequenceStep>() });
        combatStage.CombatEnemy.BehaviorPatterns[0].SequenceOfSkillsId.Add(new SkillSequenceStep() { SequenceStepId = 1, SkillId = 1 });
        combatStage.CombatEnemy.BehaviorPatterns[0].SequenceOfSkillsId.Add(new SkillSequenceStep() { SequenceStepId = 2, SkillId = 2 });

        combatStage.CombatEnemy.BehaviorPatterns.Add(new CombatBehaviorPatternDto() { Id = 2, MaxHealthPercentToTrigger = 50, MinHealthPercentToTrigger = 0, SequenceOfSkillsId = new List<SkillSequenceStep>() });
        combatStage.CombatEnemy.BehaviorPatterns[1].SequenceOfSkillsId.Add(new SkillSequenceStep() { SequenceStepId = 1, SkillId = 3 });
        combatStage.CombatEnemy.BehaviorPatterns[1].SequenceOfSkillsId.Add(new SkillSequenceStep() { SequenceStepId = 2, SkillId = 4 });

        combatStage.CombatEnemy.CurrentPatternSequenceStepId = 1;

        combatStage.CombatEnemy.Skills = new List<CombatEnemySkillDto>
        {
            new CombatEnemySkillDto() { Id = 1 },
            new CombatEnemySkillDto() { Id = 2 },
            new CombatEnemySkillDto() { Id = 3 },
            new CombatEnemySkillDto() { Id = 4 }
        };

        combatEnemyDto.SelectedSkillId = 2;
        combatEnemyDto.CurrentPatternSequenceStepId = 2;
        combatEnemyDto.CurrentBehaviorPatternId = 1;
        combatEnemyDto.SelectedSkill = new CombatEnemySkillDto() { Id = 2 };

        yield return new object[] { combatStage, combatEnemyDto };

        combatStage.CombatEnemy.CurrentPatternSequenceStepId = 2;
        combatStage.CombatEnemy.CurrentBehaviorPatternId = 1;
        combatEnemyDto.CurrentPatternSequenceStepId = 1;
        combatEnemyDto.SelectedSkillId = 1;
        combatEnemyDto.SelectedSkill.Id = 1;

        yield return new object[] { combatStage, combatEnemyDto };

        combatStage.CombatEnemy.CurrentHealth = 99;
        combatStage.CombatEnemy.CurrentBehaviorPatternId = 1;
        combatStage.CombatEnemy.CurrentPatternSequenceStepId = 1;
        combatEnemyDto.CurrentBehaviorPatternId = 1;
        combatEnemyDto.CurrentPatternSequenceStepId = 2;
        combatEnemyDto.SelectedSkillId = 2;
        combatEnemyDto.SelectedSkill.Id = 2;

        yield return new object[] { combatStage, combatEnemyDto };

        combatStage.CombatEnemy.CurrentHealth = 51;
        combatStage.CombatEnemy.CurrentBehaviorPatternId = 1;
        combatStage.CombatEnemy.CurrentPatternSequenceStepId = 1;
        combatEnemyDto.CurrentBehaviorPatternId = 1;
        combatEnemyDto.CurrentPatternSequenceStepId = 2;
        combatEnemyDto.SelectedSkillId = 2;
        combatEnemyDto.SelectedSkill.Id = 2;

        yield return new object[] { combatStage, combatEnemyDto };

        combatStage.CombatEnemy.CurrentHealth = 50;
        combatStage.CombatEnemy.CurrentBehaviorPatternId = 1;
        combatStage.CombatEnemy.CurrentPatternSequenceStepId = 1;
        combatEnemyDto.CurrentBehaviorPatternId = 2;
        combatEnemyDto.CurrentPatternSequenceStepId = 1;
        combatEnemyDto.SelectedSkillId = 3;
        combatEnemyDto.SelectedSkill.Id = 3;

        yield return new object[] { combatStage, combatEnemyDto };

        combatStage.CombatEnemy.CurrentHealth = 30;
        combatStage.CombatEnemy.CurrentBehaviorPatternId = 2;
        combatStage.CombatEnemy.CurrentPatternSequenceStepId = 1;
        combatEnemyDto.CurrentBehaviorPatternId = 2;
        combatEnemyDto.CurrentPatternSequenceStepId = 2;
        combatEnemyDto.SelectedSkillId = 4;
        combatEnemyDto.SelectedSkill.Id = 4;

        yield return new object[] { combatStage, combatEnemyDto };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}