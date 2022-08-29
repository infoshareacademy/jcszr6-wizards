﻿using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.UserModels.Properties;

namespace Wizards.Core.ModelExtensions;

public static class HeroExtensions
{
    public static double GetAverageItemTier(this Hero hero)
    {
        if (hero == null)
        {
            return 0d;
        }

        if (!hero.Inventory.Any(hi => hi.InUse))
        {
            return 0d;
        }

        double avargeItemTier = hero.Inventory
            .Where(hi => hi.InUse)
            .Sum(hi => hi.Item.Tier) / 2d;

        return Math.Round(avargeItemTier, 2);
    }

    public static HeroAttributes GetCalculatedAttributes(this Hero hero)
    {
        if (hero.Attributes == null)
        {
            throw new ArgumentNullException();
        }

        var calculatedAttributes = hero.Attributes;

        if (hero.Inventory.Count == 0)
        {
            return calculatedAttributes;
        }

        if (hero.Inventory.Any(hi => hi.Item == null) || hero.Inventory.Any(hi => hi.Item.Attributes == null))
        {
            throw new ArgumentNullException();
        }

        var heroEquippedItems = hero.Inventory.Where(hi => hi.InUse).ToList();

        foreach (var heroItem in heroEquippedItems)
        {
            calculatedAttributes.Damage += heroItem.Item.Attributes.Damage;
            calculatedAttributes.Precision += heroItem.Item.Attributes.Precision;
            calculatedAttributes.Specialization += heroItem.Item.Attributes.Specialization;

            calculatedAttributes.MaxHealth += heroItem.Item.Attributes.MaxHealth;
            calculatedAttributes.Reflex += heroItem.Item.Attributes.Reflex;
            calculatedAttributes.Defense += heroItem.Item.Attributes.Defense;
        }

        return calculatedAttributes;
    }

    public static int CalculateSkillDamage(this Hero hero, Skill skill)
    {
        if (hero == null || skill == null)
        {
            throw new ArgumentNullException();
        }

        var calculatedAttributes = hero.GetCalculatedAttributes();

        var baseDamage = calculatedAttributes.Damage;
        var result = (int)Math.Round(skill.DamageFactor * baseDamage, 0, MidpointRounding.AwayFromZero);

        return result;
    }

    public static int CalculateSkillHitChance(this Hero hero, Skill skill)
    {
        if (hero == null || skill == null)
        {
            throw new ArgumentNullException();
        }

        var calculatedAttributes = hero.GetCalculatedAttributes();

        var HitChanceImprovement = calculatedAttributes.Precision;
        var result = skill.BaseHitChance + HitChanceImprovement;

        return result;
    }

    public static int CalculateSkillArmorPenetrationPercent(this Hero hero, Skill skill)
    {
        if (hero == null || skill == null)
        {
            throw new ArgumentNullException();
        }

        var calculatedAttributes = hero.GetCalculatedAttributes();

        var armorPenetrationImprovement = calculatedAttributes.Specialization;
        var result = skill.ArmorPenetrationPercent + armorPenetrationImprovement;

        return result;
    }

    public static int CalculateSkillHealing(this Hero hero, Skill skill)
    {
        if (hero == null || skill == null)
        {
            throw new ArgumentNullException();
        }

        var calculatedAttributes = hero.GetCalculatedAttributes();

        var maxHealth = calculatedAttributes.MaxHealth;
        var result = (int)Math.Round(skill.HealingFactor * maxHealth, 0, MidpointRounding.AwayFromZero);

        return result;
    }
}