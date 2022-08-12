using System.Collections.Generic;
using WizardsWeb.ModelViews.Properties;

namespace WizardsWeb.ModelViews.Inventory;

public class InventoryModelView
{
    public HeroAttributesModelView Attributes { get; set; }
    public int ItemTier { get; set; }
    
    public int Gold { get; set; }
    
    public List<HeroItemDetailsModelView> Equipped { get; set; }
    public List<HeroItemDetailsModelView> Weapons { get; set; }
    public List<HeroItemDetailsModelView> Armors { get; set; }
    public List<HeroItemDetailsModelView> Miscellaneous { get; set; }

}