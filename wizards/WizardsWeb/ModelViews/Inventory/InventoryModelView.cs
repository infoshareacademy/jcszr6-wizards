using System.Collections.Generic;
using System.Linq;
using WizardsWeb.ModelViews.HeroModelViews.Properties;
using WizardsWeb.ModelViews.ItemModelViews;

namespace WizardsWeb.ModelViews.Inventory;

public class InventoryModelView
{
    public string HeroNickName { get; set; }
    public HeroAttributesModelView Attributes { get; set; }

    public HeroSummaryModelView HeroSummary { get; set; }

    public List<ItemDetailsModelView> Equipped { get; set; }
    public List<ItemDetailsModelView> Weapons { get; set; }
    public List<ItemDetailsModelView> Armors { get; set; }
    public List<ItemDetailsModelView> Miscellaneous { get; set; }

    public InventoryModelView()
    {
        Equipped = new List<ItemDetailsModelView>();
        Weapons = new List<ItemDetailsModelView>();
        Armors = new List<ItemDetailsModelView>();
        Miscellaneous = new List<ItemDetailsModelView>();
    }

    public int GetRepairCostForAllItems()
    {
        var inventory = new List<ItemDetailsModelView>();
        inventory.AddRange(Equipped);
        inventory.AddRange(Weapons);
        inventory.AddRange(Armors);
        inventory.AddRange(Miscellaneous);
        var result = inventory
            .Where(hi => hi.NeedsRepair())
            .Sum(hi => hi.RepairCost);

        return result;
    }
}