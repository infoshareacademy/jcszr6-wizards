using FluentAssertions;
using Wizards.Core.Model.UserModels.Enums;
using Wizards.Core.Model.WorldModels.Enums;
using Wizards.GamePlay.HelpersAndExtensions;
using static Wizards.Core.ConstParameters.Params;

namespace Wizards.Tests.GamePlayTests;

public class CombatLogicHelpersTests
{
    [Theory]
    [InlineData(50, 50, false)]
    [InlineData(50, 0, true)]
    [InlineData(51, 50, true)]
    [InlineData(0, 100, false)]
    public void AttackerHasNoChanceToHit_WithTestData_ReturnValidResult(int valueOne, int valueTwo, bool expcected)
    {
        var result = CombatLogicHelpers.AttackerHasNoChanceToHit(valueOne, valueTwo);
        result.Should().Be(expcected);
    }

    [Theory]
    [InlineData(100, 50, 50)]
    public void CalculateFinalHitChance_WithTestData_ReturnFinalHitChance(int valueOne, int valueTwo, int expcected)
    {
        var result = CombatLogicHelpers.CalculateFinalHitChance(valueOne, valueTwo);
        result.Should().Be(expcected);
    }

    [Theory]
    [InlineData(100, 50, MaxDamageFactor)]
    [InlineData(10, 0, MaxDamageFactor)]
    [InlineData(0, 100, MinDamageFactor)]
    [InlineData(50, 150, MinDamageFactor)]
    [InlineData(20, 70, 0.5)]
    public void CalculateFinalDamageFactor_WithTestData_ReturnFinalDamageFactor(int valueOne, int valueTwo, double expcected)
    {
        var result = CombatLogicHelpers.CalculateFinalDamageFactor(valueOne, valueTwo);
        result.Should().Be(expcected);
    }

    [Theory]
    [InlineData(10, 10d, 100)]
    [InlineData(9, 0.5d, 5)]
    [InlineData(149, 0.01d, 1)]
    public void CalculateAttackersDamage_WithTestData_ReturnDamage(int valueOne, double valueTwo, int expcected)
    {
        var result = CombatLogicHelpers.CalculateAttackersDamage(valueOne, valueTwo);
        result.Should().Be(expcected);
    }

    [Theory]
    [InlineData(10, false, false, 10)]
    [InlineData(10, false, true, 20)]
    [InlineData(MinOutgoingDamage, false, false, MinOutgoingDamage)]
    [InlineData(10, true, true, MinOutgoingDamage)]

    public void CalculateDefendersDamageTaken_WithTestData_ReturnDefendersDamageTaken(int valueOne, bool valueTwo, bool valueThree, int expcected)
    {
        var result = CombatLogicHelpers.CalculateDefendersDamageTaken(valueOne, valueTwo, valueThree);
        result.Should().Be(expcected);
    }

    [Theory]
    [InlineData(10, 1.2d)]
    [InlineData(12, 1.24d)]
    [InlineData(13, MaxHealingFactor)]
    [InlineData(-5, MinHealingFactor)]
    [InlineData(-6, MinHealingFactor)]
    public void CalculateFinalHealingFactor_WithTestData_ReturnFinalHealingFactor(int valueOne, double expcected)
    {
        var result = CombatLogicHelpers.CalculateFinalHealingFactor(valueOne);
        result.Should().Be(expcected);
    }

    [Theory]
    [InlineData(10, 1.5d, 15)]
    [InlineData(10, 10d, 100)]
    [InlineData(9, 0.5d, 5)]
    [InlineData(149, 0.01d, 1)]
    public void CalculateHealersHealing_WithTestData_ReturnHealersHealing(int valueOne, double valueTwo, int expcected)
    {
        var result = CombatLogicHelpers.CalculateHealersHealing(valueOne, valueTwo);
        result.Should().Be(expcected);
    }

    [Theory]
    [InlineData(10, false, false, 10)]
    [InlineData(10, false, true, 15)]
    [InlineData(MinOutgoingHealing, false, true, MinOutgoingHealing)]
    [InlineData(10, true, true, MinOutgoingHealing)]
    public void CalculateRecoveredHealth_WithTestData_ReturnRecoveredHealth(int valueOne, bool valueTwo, bool valueThree, int expcected)
    {
        var result = CombatLogicHelpers.CalculateRecoveredHealth(valueOne, valueTwo, valueThree);
        result.Should().Be(expcected);
    }

    [Fact]
    public void GetEnemySkillsTypesThatCannotMiss_ReturnProperValue()
    {
        var result = CombatLogicHelpers.GetEnemySkillsTypesThatCannotMiss();
        var expectedList = new List<EnemySkillType>()
            {
                EnemySkillType.Deadly,
                EnemySkillType.Charge,
            };
        result.Should().BeEquivalentTo(expectedList);
    }

    [Fact]
    public void GetHeroSkillsTypesThatCannotMiss_ReturnProperValue()
    {
        var result = CombatLogicHelpers.GetHeroSkillsTypesThatCannotMiss();
        var expectedList = new List<HeroSkillType>()
            {
                HeroSkillType.Block,
                HeroSkillType.Heal
            };
        result.Should().BeEquivalentTo(expectedList);
    }

}