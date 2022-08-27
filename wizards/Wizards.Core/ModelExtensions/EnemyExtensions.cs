using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Properties;

namespace Wizards.Core.ModelExtensions;

public static class EnemyExtensions
{

    public static int GetCalculatedSkillDamage(this Enemy enemy, EnemySkill enemySkill)
    {
        if (enemy == null || enemySkill == null)
        {
            throw new ArgumentNullException();
        }

        var enemyAttributes = enemy.EnemyAttributes;

        var baseDamage = enemyAttributes.Damage;
        
        var result = (int)Math.Round(enemySkill.DamageFactor * baseDamage, 0, MidpointRounding.AwayFromZero);

        return result;
    }

    public static int GetCalculatedSkillHitChance(this Enemy enemy, EnemySkill enemySkill)
    {
        if (enemy == null || enemySkill == null)
        {
            throw new ArgumentNullException();
        }

        var enemyAttributes = enemy.EnemyAttributes;

        var basePrecision = enemyAttributes.Precision;

        var result = enemySkill.BaseHitChance + basePrecision;

        return result;
    }

    public static int GetCalculatedSkillArmorPenetrationPercent(this Enemy enemy, EnemySkill enemySkill)
    {
        if (enemy == null || enemySkill == null)
        {
            throw new ArgumentNullException();
        }

        var enemyAttributes = enemy.EnemyAttributes;

        var basePercent = enemyAttributes.Specialization;

        var result = enemySkill.ArmorPenetrationPercent + basePercent;

        return result;
    }

    public static int GetCalculatedSkillHealing(this Enemy enemy, EnemySkill enemySkill)
    {
        if (enemy == null || enemySkill == null)
        {
            throw new ArgumentNullException();
        }

        var enemyAttributes = enemy.EnemyAttributes;

        var maxHealth = enemyAttributes.MaxHealth;

        var result = (int)Math.Round(enemySkill.HealingFactor * maxHealth, 0, MidpointRounding.AwayFromZero);

        return result;
    }
}