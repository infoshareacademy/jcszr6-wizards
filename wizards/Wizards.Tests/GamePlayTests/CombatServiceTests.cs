using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizards.Core.Model.WorldModels;
using Wizards.GamePlay.CombatService;
using Wizards.GamePlay.RandomNumberProvider;

namespace Wizards.Tests.GamePlayTests
{
    public class CombatServiceTests
    {
        [Fact]
        public void CalculateRoundAsync_WithNullCombatStage_ThrowException()
        {

            var randomNumberProvider = new RandomNumberProvider();
            var combatService = new CombatService(randomNumberProvider);
            CombatStage stage = null;
            var result = () => combatService.CalculateRoundAsync(stage);

            result.Should().ThrowAsync<ArgumentNullException>();

        }

        [Theory]
        [ClassData(typeof(CombatServiceTestData))]
        public async Task CalculateRoundAsync_WithNullsInsideCombatStage_ThrowsProperException(CombatStage input, Exception expected)
        {
            var randomNumberProvider = new RandomNumberProvider();
            var combatService = new CombatService(randomNumberProvider);
            var resultExceptionType = typeof(int);

            try
            {
                await combatService.CalculateRoundAsync(input);
            }
            catch (Exception exception)
            {
                resultExceptionType = exception.GetType();
            }

            resultExceptionType.Should().Be(expected.GetType());
        }

    }
}
