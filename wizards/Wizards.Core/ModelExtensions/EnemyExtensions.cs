using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.ModelsDto;
using Wizards.Core.Model.WorldModels.ModelsDto.Properties;
using Wizards.Core.Model.WorldModels.Properties;

namespace Wizards.Core.ModelExtensions;

public static class EnemyExtensions
{
    public static int CalculateSkillDamage(this Enemy enemy, EnemySkill enemySkill)
    {
        if (enemy == null || enemySkill == null)
        {
            throw new ArgumentNullException();
        }

        var enemyAttributes = enemy.Attributes;

        var baseDamage = enemyAttributes.Damage;

        var result = (int)Math.Round(enemySkill.DamageFactor * baseDamage, 0, MidpointRounding.AwayFromZero);

        return result;
    }

    public static int CalculateSkillHitChance(this Enemy enemy, EnemySkill enemySkill)
    {
        if (enemy == null || enemySkill == null)
        {
            throw new ArgumentNullException();
        }

        var enemyAttributes = enemy.Attributes;

        var basePrecision = enemyAttributes.Precision;

        var result = enemySkill.BaseHitChance + basePrecision;

        return result;
    }

    public static int CalculateSkillArmorPenetrationPercent(this Enemy enemy, EnemySkill enemySkill)
    {
        if (enemy == null || enemySkill == null)
        {
            throw new ArgumentNullException();
        }

        var enemyAttributes = enemy.Attributes;

        var basePercent = enemyAttributes.Specialization;

        var result = enemySkill.ArmorPenetrationPercent + basePercent;

        return result;
    }

    public static int CalculateSkillHealing(this Enemy enemy, EnemySkill enemySkill)
    {
        if (enemy == null || enemySkill == null)
        {
            throw new ArgumentNullException();
        }

        var enemyAttributes = enemy.Attributes;

        var maxHealth = enemyAttributes.MaxHealth;

        var result = (int)Math.Round(enemySkill.HealingFactor * maxHealth, 0, MidpointRounding.AwayFromZero);

        return result;
    }

    public static List<CombatEnemySkillDto> GetEnemyCombatSkills(this Enemy enemy)
    {
        var combatSkills = new List<CombatEnemySkillDto>();

        if (enemy == null)
        {
            return combatSkills;
        }

        var enemySkills = enemy.Skills;

        if (!enemySkills.Any())
        {
            return combatSkills;
        }

        foreach (var enemySkill in enemySkills)
        {
            var combatSkill = new CombatEnemySkillDto()
            {
                Id = enemySkill.Id,
                Name = enemySkill.Name,
                Type = enemySkill.Type,

                Damage = enemy.CalculateSkillDamage(enemySkill),
                HitChance = enemy.CalculateSkillHitChance(enemySkill),
                ArmorPenetrationPercent = enemy.CalculateSkillArmorPenetrationPercent(enemySkill),
                Healing = enemy.CalculateSkillHealing(enemySkill),
                Stunning = enemySkill.Stunning
            };
        }

        return combatSkills;
    }

    public static CombatEnemySkillDto GetEnemySelectedSkill(this CombatEnemyDto enemy)
    {
        var selectedEnemySkill = enemy.Skills.SingleOrDefault(s => s.Id == enemy.SelectedSkillId);

        if (selectedEnemySkill == null)
        {
            throw new ArgumentNullException(nameof(enemy.SelectedSkill), "Enemy has wrong selected actions!");
        }

        return selectedEnemySkill;
    }
}