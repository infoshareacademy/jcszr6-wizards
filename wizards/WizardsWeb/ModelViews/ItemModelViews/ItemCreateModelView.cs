using System.ComponentModel.DataAnnotations;
using Wizards.Core.Model.Enums;

namespace WizardsWeb.ModelViews.ItemModelViews;

public class ItemCreateModelView
{
    [Required]
    public string Name { get; set; }

    [Required]
    public ItemType Type { get; set; }

    [Required]
    [Display(Name = "Profession Restriction")]
    public ProfessionRestriction Restriction { get; set; }

    [Required]
    [Display(Name = "Item Tier (1-5)")]
    [Range(1, 5)]
    public int Tier { get; set; }

    [Required]
    [Display(Name = "Buy Price")]
    [Range(0, 100_000)]
    public int BuyPrice { get; set; }

    [Required]
    [Display(Name = "Sell Price")]
    [Range(0, 100_000)]
    public int SellPrice { get; set; }

    [Required]
    [Range(-10, 50)]
    public int Damage { get; set; }

    [Required]
    [Range(-10, 50)]
    public int Precision { get; set; }

    [Required]
    [Range(-10, 50)]
    public int Specialization { get; set; }

    [Required]
    [Display(Name = "Max Health")]
    [Range(0, 500)]
    public int MaxHealth { get; set; }

    [Required]
    [Range(-10, 50)]
    public int Reflex { get; set; }

    [Required]
    [Range(-10, 50)]
    public int Defense { get; set; }
}