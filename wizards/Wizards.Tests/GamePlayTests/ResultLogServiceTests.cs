using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Wizards.Core.Model.WorldModels.Properties;
using Wizards.GamePlay.ResultLogService;
using Xunit.Sdk;

namespace Wizards.Tests.GamePlayTests
{
    public class ResultLogServiceTests
    {

        [Theory]
        [ClassData(typeof(ResultLogServiceTestsData))]
        public async Task CreateRoundLogAsync_WithClassData_ReturnCorrectLog(RoundResult roundResult, RoundLog expected)
        {
            ResultLogService resultLogService = new();

            var result = await resultLogService.CreateRoundLogAsync(roundResult);

            result.Should().BeEquivalentTo(expected);
        }



    }
}
