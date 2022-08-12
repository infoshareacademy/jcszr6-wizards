using System.ComponentModel.DataAnnotations;
using Wizards.Core.Model.Enums;
using WizardsWeb.ModelViews.Inventory.Properties;

namespace WizardsWeb.ModelViews.Inventory;

public class HeroItemDetailsModelView
{
    // Basics
    public string Name { get; set; }
    public ItemType Type { get; set; }
    public ProfessionRestriction Restriction { get; set; }
    public int Tier { get; set; }

    // Attributes
    public bool Equipped { get; set; }
    public ItemAttributesDetailsModelView Attributes { get; set; }
    
    // Economic
    [Display(Name = "Item Endurance")]
    public decimal Endurance { get; set; }
    [Display(Name = "Repair Cost")]
    public int  RepairCost { get; set; }
    [Display(Name = "Sell Price")]
    public int SellPrice { get; set; }
}