using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WizardsWeb.ModelViews.Properties;

namespace WizardsWeb.ModelViews.Inventory;

public class InventoryModelView
{
    public HeroAttributesModelView Attributes { get; set; }
    [Display(Name ="Item Tier: ")]
    public double HerosAvargeItemTier { get; set; }
    
    public int Gold { get; set; }
    
    public List<HeroItemDetailsModelView> Equipped { get; set; }
    public List<HeroItemDetailsModelView> Weapons { get; set; }
    public List<HeroItemDetailsModelView> Armors { get; set; }
    public List<HeroItemDetailsModelView> Miscellaneous { get; set; }

    public InventoryModelView()
    {
        Equipped = new List<HeroItemDetailsModelView>();
        Weapons = new List<HeroItemDetailsModelView>();
        Armors = new List<HeroItemDetailsModelView>();
        Miscellaneous = new List<HeroItemDetailsModelView>();
    }
}