using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Properties;
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

        [Theory]
        [ClassData(typeof(CombatServiceTestCorrectData))]
        public async Task CalculateRoundAsync_WithCorrectCombatStage_ReturnsCorrectRoundResult(CombatStage combatStage, RoundResult expected)
        {
            var queue = new Queue<int>();
            queue.Enqueue(50);
            queue.Enqueue(50);
            var queueTask = Task.FromResult(queue);

            var randomMock = new Mock<IRandomNumberProvider>();
            randomMock.Setup(r => r.GetManyRandomNumbersAsync(1, 100, 2)).Returns(queueTask);

            var combatService = new CombatService(randomMock.Object);

            var result = await combatService.CalculateRoundAsync(combatStage);

            result.Should().BeEquivalentTo(expected);
        }
    }
}