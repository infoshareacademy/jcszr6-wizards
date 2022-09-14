using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Properties;
using Wizards.Core.ModelExtensions;

namespace Wizards.Tests.CoreTests
{
    public class EnemyExtensionsTests
    {
        [Fact]
        public void CalculateSkillDamage_WithNullAsEnemy_ThrowException()
        {
            var enemySkill = new EnemySkill();
            Enemy enemy = null;
            var result = () => enemy.CalculateSkillDamage(enemySkill);

            result.Should().Throw<ArgumentNullException>();

        }

    }
}
