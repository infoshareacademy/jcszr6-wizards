using System.Collections;
using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Enums;
using Wizards.Core.Model.WorldModels.ModelsDto;
using Wizards.Core.Model.WorldModels.ModelsDto.Properties;

namespace Wizards.Tests.GamePlayTests;

public class CombatServiceTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var combatStage = new CombatStage()
        {
            Status = StageStatus.DuringCombat,
            CombatHero = new CombatHeroDto()
            {
                Attributes = new CombatHeroAttributesDto(),
                SelectedSkill = new CombatHeroSkillDto()
            },
            CombatEnemy = new CombatEnemyDto()
            {
                Attributes = new CombatEnemyAttributesDto(),
                SelectedSkill = null
            },
        };
        var combatStage2 = new CombatStage()
        {
            Status = StageStatus.DuringCombat,
            CombatHero = new CombatHeroDto()
            {
                Attributes = new CombatHeroAttributesDto(),
                SelectedSkill = null
            },
            CombatEnemy = new CombatEnemyDto()
            {
                Attributes = new CombatEnemyAttributesDto()
            },
        };
        var combatStage3 = new CombatStage()
        {
            Status = StageStatus.DuringCombat,
            CombatHero = new CombatHeroDto()
            {
                Attributes = new CombatHeroAttributesDto(),
                SelectedSkill = new CombatHeroSkillDto()
            },
            CombatEnemy = new CombatEnemyDto()
            {
                Attributes = null
            },
        };
        var combatStage4 = new CombatStage()
        {
            Status = StageStatus.DuringCombat,
            CombatHero = new CombatHeroDto()
            {
                Attributes = null
            },
            CombatEnemy = new CombatEnemyDto()
        };
        var combatStage5 = new CombatStage()
        {
            Status = StageStatus.DuringCombat,
            CombatHero = new CombatHeroDto(),
            CombatEnemy = null
        };
        var combatStage6 = new CombatStage()
        {
            Status = StageStatus.DuringCombat,
            CombatHero = null
        };
        var combatStage7 = new CombatStage()
        {
            Status = StageStatus.FreshOpened,
        };

        yield return new object[] { combatStage, new ArgumentNullException() };
        yield return new object[] { combatStage2, new ArgumentNullException() };
        yield return new object[] { combatStage3, new ArgumentNullException() };
        yield return new object[] { combatStage4, new ArgumentNullException() };
        yield return new object[] { combatStage5, new ArgumentNullException() };
        yield return new object[] { combatStage6, new ArgumentNullException() };
        yield return new object[] { combatStage7, new ArgumentException("Stage is not in combat!") };
        yield return new object[] { null, new ArgumentNullException() };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}