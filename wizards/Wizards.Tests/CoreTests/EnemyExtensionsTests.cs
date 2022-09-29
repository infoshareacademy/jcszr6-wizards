using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.ModelsDto.Properties;
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

        [Fact]
        public void CalculateSkillDamage_WithNullEnemySkill_ThrowException()
        {
            var enemy = new Enemy();
            EnemySkill enemySkill = null;
            var result = () => enemy.CalculateSkillDamage(enemySkill);

            result.Should().Throw<ArgumentNullException>();

        }

        [Fact]
        public void CalculateSkillHitChance_WithNullAsEnemy_ThrowException()
        {
            var enemySkill = new EnemySkill();
            Enemy enemy = null;
            var result = () => enemy.CalculateSkillHitChance(enemySkill);

            result.Should().Throw<ArgumentNullException>();

        }

        [Fact]
        public void CalculateSkillHitChance_WithNullEnemySkill_ThrowException()
        {
            var enemy = new Enemy();
            EnemySkill enemySkill = null;
            var result = () => enemy.CalculateSkillHitChance(enemySkill);

            result.Should().Throw<ArgumentNullException>();

        }

        [Fact]
        public void CalculateSkillArmorPenetrationPercent_WithNullAsEnemy_ThrowException()
        {
            var enemySkill = new EnemySkill();
            Enemy enemy = null;
            var result = () => enemy.CalculateSkillArmorPenetrationPercent(enemySkill);

            result.Should().Throw<ArgumentNullException>();

        }

        [Fact]
        public void CalculateSkillArmorPenetrationPercent_WithNullEnemySkill_ThrowException()
        {
            var enemy = new Enemy();
            EnemySkill enemySkill = null;
            var result = () => enemy.CalculateSkillArmorPenetrationPercent(enemySkill);

            result.Should().Throw<ArgumentNullException>();

        }

        [Fact]
        public void CalculateSkillHealing_WithNullAsEnemy_ThrowException()
        {
            var enemySkill = new EnemySkill();
            Enemy enemy = null;
            var result = () => enemy.CalculateSkillHealing(enemySkill);

            result.Should().Throw<ArgumentNullException>();

        }

        [Fact]
        public void CalculateSkillHealing_WithNullEnemySkill_ThrowException()
        {
            var enemy = new Enemy();
            EnemySkill enemySkill = null;
            var result = () => enemy.CalculateSkillHealing(enemySkill);

            result.Should().Throw<ArgumentNullException>();

        }

        [Fact]
        public void GetEnemyCombatSkills_WithNullAsEnemy_ThrowException()
        {
            var enemySkill = new EnemySkill();
            Enemy enemy = null;
            var result = enemy.GetEnemyCombatSkills();

            result.Count.Should().Be(0);

        }


    }
}
