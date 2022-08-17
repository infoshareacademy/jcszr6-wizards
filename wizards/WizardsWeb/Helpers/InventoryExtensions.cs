using System.Collections.Generic;
using System.Linq;
using WizardsWeb.ModelViews.Inventory;

namespace WizardsWeb.Helpers;

public static class InventoryExtensions
{
    public static int GetRepairCostForEquipment(this IEnumerable<HeroItemDetailsModelView> equipment)
    {
        var result = 0;

        if (equipment.All(hi => hi.IsEquipped))
        {
            result = equipment.Where(hi => hi.NeedsRepair()).Sum(hi => hi.RepairCost);
        }

        return result;
    }
}