using System.ComponentModel.DataAnnotations;
using Wizards.Core.Model.Enums;
using WizardsWeb.ModelViews.Inventory.Properties;

namespace WizardsWeb.ModelViews.Inventory;

public class HeroItemDetailsModelView
{
    public int Id { get; set; }
    // Basics
    public string Name { get; set; }
    public ItemType Type { get; set; }
    public ProfessionRestriction Restriction { get; set; }
    [Display(Name = "Item Tier")]
    public int Tier { get; set; }

    // Attributes
    public bool IsEquipped { get; set; }
    public ItemAttributesDetailsModelView Attributes { get; set; }
    
    // Economic
    [Display(Name = "Item Endurance")]
    public double Endurance { get; set; }
    [Display(Name = "Repair Cost")]
    public int  RepairCost { get; set; }
    [Display(Name = "Sell Price")]
    public int SellPrice { get; set; }
}