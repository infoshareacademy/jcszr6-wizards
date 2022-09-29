using System.ComponentModel.DataAnnotations;
using Wizards.Core.Model.UserModels.Enums;

namespace WizardsWeb.ModelViews.CombatModelViews;

public class HeroSkillModelView
{
    public int Id { get; set; }
    public SkillSlotNumber SlotNumber { get; set; }
    
    public string Name { get; set; }
    public HeroSkillType Type { get; set; }
    public string Description { get; set; }
    public int SkillIconNumber { get; set; }

    [Display(Name = "Damage")]
    public int Damage { get; set; }
    [Display(Name = "Hit Chance")]
    public int HitChance { get; set; }
    [Display(Name = "Armor overpass")]
    public int ArmorPenetrationPercent { get; set; }
    [Display(Name = "Healing")]
    public int Healing { get; set; }
}