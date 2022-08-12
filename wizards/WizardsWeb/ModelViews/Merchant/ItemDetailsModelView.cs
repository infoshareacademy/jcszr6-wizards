using System.ComponentModel.DataAnnotations;
using Wizards.Core.Model.Enums;
using WizardsWeb.ModelViews.Inventory;
using WizardsWeb.ModelViews.Inventory.Properties;

namespace WizardsWeb.ModelViews.Merchant;


public class ItemDetailsModelView
{
    // Basics
    public string Name { get; set; }
    public ItemType Type { get; set; }
    public ProfessionRestriction Restriction { get; set; }
    public int Tier { get; set; }

    // Attributes
    public ItemAttributesDetailsModelView Attributes { get; set; }

    // Economic
    [Display(Name = "Buy Price")]
    public int BuyPrice { get; set; }
}