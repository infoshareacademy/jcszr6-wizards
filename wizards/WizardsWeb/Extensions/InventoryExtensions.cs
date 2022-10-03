using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wizards.Core.Model.UserModels.Enums;
using WizardsWeb.ModelViews.ItemModelViews;

namespace WizardsWeb.Extensions;

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

    public static string GetItemIconAddress(this ItemDetailsModelView item)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append("/Images/Items/Icons/");

        if (item.Name.ToLower().Contains("staff"))
        {
            stringBuilder.Append("Staff");
        }
        else if (item.Name.ToLower().Contains("scepter"))
        {
            stringBuilder.Append("Scepter");
        }
        else if (item.Name.ToLower().Contains("spell"))
        {
            stringBuilder.Append("Spell-book");
        }
        else if (item.Name.ToLower().Contains("mantle"))
        {
            stringBuilder.Append("Mantle");
        }
        else if (item.Name.ToLower().Contains("overcoat"))
        {
            stringBuilder.Append("Overcoat");
        }
        else if (item.Name.ToLower().Contains("vestment"))
        {
            stringBuilder.Append("Vestments");
        }
        else if (item.Name.ToLower().Contains("cup"))
        {
            stringBuilder.Append("RitualCup");
        }
        else if (item.Name.ToLower().Contains("scythe"))
        {
            stringBuilder.Append("Scythe");
        }
        else if (item.Name.ToLower().Contains("urn"))
        {
            stringBuilder.Append("Urn");
        }
        else if (item.Name.ToLower().Contains("hood"))
        {
            stringBuilder.Append("Hood");
        }
        else if (item.Name.ToLower().Contains("livery"))
        {
            stringBuilder.Append("RitualLivery");
        }
        else if (item.Name.ToLower().Contains("shroud"))
        {
            stringBuilder.Append("Shroud");
        }
        else if (item.Type == ItemType.Weapon)
        {
            stringBuilder.Append("Staff");
        }
        else if (item.Type == ItemType.Armor)
        {
            stringBuilder.Append("Overcoat");
        }

        stringBuilder.Append(".png");
        return stringBuilder.ToString();
    }
}