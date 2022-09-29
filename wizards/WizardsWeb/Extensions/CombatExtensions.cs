using System.Collections.Generic;
using System.Linq;
using Wizards.Core.Model.UserModels.Enums;
using WizardsWeb.ModelViews.CombatModelViews;

namespace WizardsWeb.Extensions;

public static class CombatExtensions
{
    public static string HealthLostPercent(this EnemySectionModelView enemy)
    {
        return $"{100 - enemy.GetCurrentHealthPercent()}%";
    }

    public static string HealthLostPercent(this HeroSectionModelView hero)
    {
        return $"{100 - hero.GetCurrentHealthPercent()}%";
    }

    public static bool ExistsSkill(this IEnumerable<HeroSkillModelView> skills, SkillSlotNumber number)
    {
        return skills.Any(s => s.SlotNumber == number);
    }

    public static HeroSkillModelView GetSkill(this IEnumerable<HeroSkillModelView> skills, SkillSlotNumber number)
    {
        return skills.SingleOrDefault(s => s.SlotNumber == number);
    }

    public static bool ShowSkillAttributes(this HeroSkillModelView heroSkill)
    {
        return (heroSkill.Type != HeroSkillType.Block && heroSkill.Type != HeroSkillType.Heal);
    }
}