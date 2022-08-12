using System.ComponentModel.DataAnnotations;

namespace WizardsWeb.ModelViews.Inventory.Properties;

public class ItemAttributesDetailsModelView
{
    // Offensive
    public int Damage { get; set; }
    public int Precision { get; set; }
    public int Specialization { get; set; }

    // Defensive
    [Display(Name = "Maximum Health")]
    public int MaxHealth { get; set; }
    public int Reflex { get; set; }
    public int Defense { get; set; }
}