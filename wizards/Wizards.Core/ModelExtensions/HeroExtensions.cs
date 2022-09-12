using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.UserModels.Properties;
using Wizards.Core.Model.WorldModels.ModelsDto;
using Wizards.Core.Model.WorldModels.ModelsDto.Properties;
using static Wizards.Core.ConstParameters.Params;

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

        var calculatedAttributes = new HeroAttributes()
        {
            DailyRewardEnergy = hero.Attributes.DailyRewardEnergy,
            Damage = hero.Attributes.Damage,
            Precision = hero.Attributes.Precision,
            Specialization = hero.Attributes.Specialization,
            MaxHealth = hero.Attributes.MaxHealth,
            Reflex = hero.Attributes.Reflex,
            Defense = hero.Attributes.Defense,
        };

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
            var attrFactor = CalculateItemUsageAttributesFactor(heroItem);

            calculatedAttributes.Damage += (int)Math.Round(heroItem.Item.Attributes.Damage * attrFactor, 0, MidpointRounding.AwayFromZero);
            calculatedAttributes.Precision += (int)Math.Round(heroItem.Item.Attributes.Precision * attrFactor, 0, MidpointRounding.AwayFromZero);
            calculatedAttributes.Specialization += (int)Math.Round(heroItem.Item.Attributes.Specialization * attrFactor, 0, MidpointRounding.AwayFromZero);

            calculatedAttributes.MaxHealth += (int)Math.Round(heroItem.Item.Attributes.MaxHealth * attrFactor, 0, MidpointRounding.AwayFromZero);
            calculatedAttributes.Reflex += (int)Math.Round(heroItem.Item.Attributes.Reflex * attrFactor, 0, MidpointRounding.AwayFromZero);
            calculatedAttributes.Defense += (int)Math.Round(heroItem.Item.Attributes.Defense * attrFactor, 0, MidpointRounding.AwayFromZero);
        }

        return calculatedAttributes;
    }

    private static double CalculateItemUsageAttributesFactor(HeroItem heroItem)
    {
        double result = 0d;

        if (heroItem.ItemEndurance >= ItemInGoodConditionMin)
        {
            result = ItemInGoodConditionAttrFactor;
        }
        else if (heroItem.ItemEndurance >= ItemDamagedMin)
        {
            result = ItemDamagedAttrFactor;
        }
        else if (heroItem.ItemEndurance >= ItemCrashedMin)
        {
            result = ItemCrashedAttrFactor;
        }

        return result;
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

        var hitChanceImprovement = calculatedAttributes.Precision;
        var result = skill.BaseHitChance + hitChanceImprovement;

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

    public static List<CombatHeroSkillDto> GetCombatHeroSkills(this Hero hero)
    {
        var combatSkills = new List<CombatHeroSkillDto>();

        if (hero == null)
        {
            return combatSkills;
        }

        var skills = hero.Skills.Where(hs => hs.InUse);

        if (!skills.Any())
        {
            return combatSkills;
        }

        foreach (var heroSkill in skills)
        {
            var combatSkill = new CombatHeroSkillDto()
            {
                Id = heroSkill.Id,
                Name = heroSkill.Skill.Name,
                Type = heroSkill.Skill.Type,
                SlotNumber = heroSkill.SlotNumber,
                SkillIconNumber = heroSkill.Skill.Id,

                Damage = hero.CalculateSkillDamage(heroSkill.Skill),
                HitChance = hero.CalculateSkillHitChance(heroSkill.Skill),
                ArmorPenetrationPercent = hero.CalculateSkillArmorPenetrationPercent(heroSkill.Skill),
                Healing = hero.CalculateSkillHealing(heroSkill.Skill)
            };

            combatSkills.Add(combatSkill);
        }

        return combatSkills;
    }

    public static CombatHeroSkillDto GetHeroSelectedSkill(this CombatHeroDto hero)
    {
        var selectedHeroSkill = hero.Skills.SingleOrDefault(s => s.Id == hero.SelectedSkillId);

        if (selectedHeroSkill == null)
        {
            throw new ArgumentNullException(nameof(hero.SelectedSkillId), "Hero has wrong selected actions!");
        }

        return selectedHeroSkill;
    }
}