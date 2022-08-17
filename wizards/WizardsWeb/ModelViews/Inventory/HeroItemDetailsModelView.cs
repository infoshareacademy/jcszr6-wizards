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

    public bool NeedsRepair()
    {
        return (RepairCost >= 1 && Endurance < 99);
    }

    public string GetEnduranceBarColorClass()
    {
        var bgColor = "bg-danger";
        if (Endurance >= 99)
        {
            bgColor = "bg-info";
        }
        else if (Endurance >= 66)
        {
            bgColor = "bg-success";
        }
        else if (Endurance >= 33)
        {
            bgColor = "bg-warning";
        }

        return bgColor;
    }

    public string GetItemTierColor()
    {
        var color = "secondary";

        if (Tier == 5)
        {
            color = "info";
        }
        else if (Tier == 4)
        {
            color = "warning";
        }
        else if (Tier == 3)
        {
            color = "primary";
        }
        else if (Tier == 2)
        {
            color = "success";
        }

        return color;
    }
}