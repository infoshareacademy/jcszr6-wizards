using FluentAssertions;
using System.Text.Json;
using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.ModelsDto;
using Wizards.GamePlay.EnemyAI;

namespace Wizards.Tests.GamePlayTests;

public class EnemyAITests
{
    [Theory]
    [ClassData(typeof(EnemyAITestsData))]
    public async Task SelectNextEnemyActionAsync_WithClassData_ChangeStageStatus(CombatStage stage, CombatEnemyDto expected)
    {
        EnemyAI enemyAI = new();

        string json = JsonSerializer.Serialize(stage);
        var stageForTest = JsonSerializer.Deserialize<CombatStage>(json);

        await enemyAI.SelectNextEnemyActionAsync(stageForTest);

        stageForTest.CombatEnemy.SelectedSkillId.Should().Be(expected.SelectedSkillId);
        stageForTest.CombatEnemy.CurrentPatternSequenceStepId.Should().Be(expected.CurrentPatternSequenceStepId);
        stageForTest.CombatEnemy.CurrentBehaviorPatternId.Should().Be(expected.CurrentBehaviorPatternId);
        stageForTest.CombatEnemy.SelectedSkill.Should().BeEquivalentTo(expected.SelectedSkill);
    }
}