using Wizards.Core.Model.UserModels.Enums;
using Wizards.Core.Model.WorldModels.Enums;
using static Wizards.Core.ConstParameters.Params;

namespace Wizards.GamePlay.HelpersAndExtensions;

public static class CombatLogicHelpers
{
    public static bool AttackerHasNoChanceToHit(int randomNumber, int finalHitChance)
    {
        return finalHitChance <= 0 || (randomNumber > finalHitChance && finalHitChance < 100);
    }

    public static int CalculateFinalHitChance(int attackersCalculatedSkillHitChance, int defenderReflex)
    {
        return attackersCalculatedSkillHitChance - defenderReflex;
    }

    public static double CalculateFinalDamageFactor(int attackersSkillArmorPenetrationPercent, int defendersTotalDefense)
    {
        var finalDamageFactor = (MaxPercentNumber + attackersSkillArmorPenetrationPercent - defendersTotalDefense) / PercentDivider;

        if (finalDamageFactor >= MaxDamageFactor)
        {
            finalDamageFactor = MaxDamageFactor;
        }
        else if (finalDamageFactor <= MinDamageFactor)
        {
            finalDamageFactor = MinDamageFactor;
        }

        return finalDamageFactor;
    }

    public static int CalculateAttackersDamage(int attackerDamage, double finalDamageFactor)
    {
        return (int)Math.Round(attackerDamage * finalDamageFactor, 0, MidpointRounding.AwayFromZero);
    }

    public static int CalculateDefendersDamageTaken(int calculatedAttackersDamage, bool attackerMissesAttack, bool isDefenderStunned)
    {
        if (!attackerMissesAttack && !isDefenderStunned && calculatedAttackersDamage > MinOutgoingDamage)
        {
            return calculatedAttackersDamage;
        }

        if (!attackerMissesAttack && isDefenderStunned && calculatedAttackersDamage > MinOutgoingDamage)
        {
            return (int)Math.Round(calculatedAttackersDamage * BonusDamageFactor, 0, MidpointRounding.AwayFromZero);
        }

        return MinOutgoingDamage;
    }

    public static double CalculateFinalHealingFactor(int specialization)
    {
        var finalHealingFactor = (MaxPercentNumber + specialization * SpecializationFactorForHealing) / PercentDivider;

        if (finalHealingFactor >= MaxHealingFactor)
        {
            finalHealingFactor = MaxHealingFactor;
        }
        else if (finalHealingFactor <= MinHealingFactor)
        {
            finalHealingFactor = MinHealingFactor;
        }

        return finalHealingFactor;
    }

    public static int CalculateHealersHealing(int heroSkillHealing, double finalHealingFactor)
    {
        return (int)Math.Round(heroSkillHealing * finalHealingFactor, 0, MidpointRounding.AwayFromZero);
    }

    public static int CalculateRecoveredHealth(int healersHealing, bool healerIsStunned, bool opponentIsStunned)
    {
        if (!healerIsStunned && !opponentIsStunned && healersHealing > MinOutgoingHealing)
        {
            return healersHealing;
        }

        if (!healerIsStunned && opponentIsStunned && healersHealing > MinOutgoingHealing)
        {
            return (int)Math.Round(healersHealing * BonusHealingFactor,0,MidpointRounding.AwayFromZero);
        }

        return MinOutgoingHealing;
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