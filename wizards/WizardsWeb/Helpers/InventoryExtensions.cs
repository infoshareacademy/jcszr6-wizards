using System.Collections.Generic;
using System.Linq;
using WizardsWeb.ModelViews.ItemModelViews;

namespace WizardsWeb.Helpers;

public static class InventoryExtensions
{
    public static int GetRepairCostForEquipment(this IEnumerable<ItemDetailsModelView> items)
    {
        var result = 0;

        if (items.All(i => i.IsEquipped))
        {
            result = items.Where(i => i.NeedsRepair()).Sum(i => i.RepairCost);
        }

        return result;
    }

    public static bool CanShowRepairEquipmentButton(this IEnumerable<ItemDetailsModelView> items)
    {
        return items.All(i => !i.IsInMerchantMode && !i.IsMerchantItem && i.IsEquipped) && items.Any(i =>i.NeedsRepair());
    }

    public static bool CanShowBuyPrice(this IEnumerable<ItemDetailsModelView> items)
    {
        return items.All(i => i.IsMerchantItem);
    }

    public static bool CanShowSellPrice(this IEnumerable<ItemDetailsModelView> items)
    {
        return items.All(i => !i.IsMerchantItem && i.IsInMerchantMode);
    }

    public static bool CanShowEndurance(this IEnumerable<ItemDetailsModelView> items)
    {
        return items.All(i => !i.IsMerchantItem && !i.IsInMerchantMode);
    }
}