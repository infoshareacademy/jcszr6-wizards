using Wizards.Core.Model.UserModels.Enums;
using Wizards.Core.Model.WorldModels.Enums;

namespace Wizards.GamePlay.HelpersAndExtensions;

public static class CombatLogicHelpers
{
    public static bool AttackerHasNoChanceToHit(int randomNumber, int finalHitChance)
    {
        return finalHitChance <= 0 || randomNumber > finalHitChance;
    }

    public static int CalculateFinalHitChance(int attackersCalculatedSkillHitChance, int defenderReflex)
    {
        return attackersCalculatedSkillHitChance - defenderReflex;
    }

    public static double CalculateFinalDamageFactor(int attackersSkillArmorPenetrationPercent, int defendersTotalDefense)
    {
        var finalDamageFactor = (100d + attackersSkillArmorPenetrationPercent - defendersTotalDefense) / 100d;

        if (finalDamageFactor >= 1.10d)
        {
            finalDamageFactor = 1.10d;
        }
        else if (finalDamageFactor <= 0d)
        {
            finalDamageFactor = 0d;
        }

        return finalDamageFactor;
    }

    public static int CalculateAttackersDamage(int attackerDamage, double finalDamageFactor)
    {
        return (int)Math.Round(attackerDamage * finalDamageFactor, 0, MidpointRounding.AwayFromZero);
    }

    public static int CalculateDefendersDamageTaken(int calculatedAttackersDamage, bool attackerMissesAttack, bool isDefenderStunned)
    {
        if (!attackerMissesAttack && !isDefenderStunned && calculatedAttackersDamage > 0)
        {
            return calculatedAttackersDamage;
        }

        if (!attackerMissesAttack && isDefenderStunned && calculatedAttackersDamage > 0)
        {
            return calculatedAttackersDamage * 2;
        }

        return 0;
    }

    public static double CalculateFinalHealingFactor(int specialization)
    {
        var finalHealingFactor = (100d + specialization / 2d) / 100d;

        if (finalHealingFactor >= 1.25d)
        {
            finalHealingFactor = 1.25d;
        }
        else if (finalHealingFactor <= 0.9d)
        {
            finalHealingFactor = 0.9d;
        }

        return finalHealingFactor;
    }

    public static int CalculateHealersHealing(int heroSkillHealing, double finalHealingFactor)
    {
        return (int)Math.Round(heroSkillHealing * finalHealingFactor, 0, MidpointRounding.AwayFromZero);
    }

    public static int CalculateRecoveredHealth(int healersHealing, bool healerIsStunned, bool opponentIsStunned)
    {
        if (!healerIsStunned && !opponentIsStunned && healersHealing > 0)
        {
            return healersHealing;
        }

        if (!healerIsStunned && opponentIsStunned && healersHealing > 0)
        {
            return healersHealing * 2;
        }

        return 0;
    }

    public static List<EnemySkillType> GetEnemySkillsTypesThatCannotMiss()
    {
        return new List<EnemySkillType>()
        {
            EnemySkillType.Deadly, 
            EnemySkillType.Charge,
        };
    }

    public static List<HeroSkillType> GetHeroSkillsTypesThatCannotMiss()
    {
        return new List<HeroSkillType>()
        {
            HeroSkillType.Block, 
            HeroSkillType.Heal
        };
    }
}