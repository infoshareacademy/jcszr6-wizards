using System.Collections;
using Wizards.Core.Model.UserModels.Enums;
using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Enums;
using Wizards.Core.Model.WorldModels.ModelsDto;
using Wizards.Core.Model.WorldModels.ModelsDto.Properties;
using Wizards.Core.Model.WorldModels.Properties;
using Wizards.Core.Model.WorldModels.Properties.Enums;

namespace Wizards.Tests.GamePlayTests;

public class CombatServiceTestCorrectData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var combatStage = new CombatStage();
        var combatHero = new CombatHeroDto();
        var combatEnemy = new CombatEnemyDto();
        combatHero.NickName = "Hero";
        combatHero.SelectedSkill = new CombatHeroSkillDto() { Type = HeroSkillType.Attack, Name = "HeroSkill" };
        combatEnemy.Name = "Enemy";
        combatEnemy.SelectedSkill = new CombatEnemySkillDto() { Type = EnemySkillType.Attack, Name = "EnemySkill" };
        combatEnemy.IsStunned = false;
        combatHero.IsStunned = false;
        combatEnemy.SelectedSkill.HitChance = 50;
        combatHero.Attributes = new CombatHeroAttributesDto() { Reflex = 0 };
        combatHero.SelectedSkill.HitChance = 50;
        combatEnemy.Attributes = new CombatEnemyAttributesDto() { Reflex = 0 };
        combatHero.SelectedSkill.Damage = 100;
        combatHero.SelectedSkill.ArmorPenetrationPercent = 0;
        combatEnemy.Attributes.Defense = 0;
        combatEnemy.SelectedSkill.Damage = 100;
        combatEnemy.SelectedSkill.ArmorPenetrationPercent = 0;
        combatHero.Attributes.Defense = 0;
        combatEnemy.Attributes.Specialization = 10;
        combatEnemy.SelectedSkill.Healing = 100;
        combatHero.Attributes.Specialization = 10;
        combatHero.SelectedSkill.Healing = 100;
        combatHero.Attributes.MaxHealth = 1000;
        combatEnemy.Attributes.MaxHealth = 1000;
        combatHero.CurrentHealth = 1000;
        combatEnemy.CurrentHealth = 1000;

        combatHero.Skills = new List<CombatHeroSkillDto>();
        combatEnemy.Skills = new List<CombatEnemySkillDto>();

        combatStage.Status = StageStatus.DuringCombat;
        combatStage.CombatHero = combatHero;
        combatStage.CombatEnemy = combatEnemy;

        var roundResult = new RoundResult()
        {
            HeroNickName = combatStage.CombatHero.NickName,
            EnemyName = combatStage.CombatEnemy.Name,
            HeroSkillType = combatStage.CombatHero.SelectedSkill.Type,
            EnemySkillType = combatStage.CombatEnemy.SelectedSkill.Type,
            HeroSkillName = combatStage.CombatHero.SelectedSkill.Name,
            EnemySkillName = combatStage.CombatEnemy.SelectedSkill.Name,

            EnemyCombatStatus = EnemyCombatStatus.HitsSuccessfully,
            HeroCombatStatus = HeroCombatStatus.HitsSuccessfully,
            EnemyWillBeStunned = false,
            HeroWillBeStunned = false,
            EnemyDamageTaken = 100,
            HeroDamageTaken = 100,
            EnemyHealthRecovered = 120,
            HeroHealthRecovered = 120,
        };

        yield return new object[] { combatStage, roundResult };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}