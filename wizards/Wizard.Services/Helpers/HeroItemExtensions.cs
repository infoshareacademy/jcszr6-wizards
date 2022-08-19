using Wizards.Core.Model;

namespace Wizards.Services.Helpers;

public static class HeroItemExtensions
{
    public static int GetCalculatedSellPrice(this HeroItem heroItem)
    {
        if (heroItem == null)
        {
            return 0;
        }

        if (heroItem.Item == null)
        {
            return 0;
        }

        return (int)Math.Round(heroItem.Item.SellPrice * (heroItem.ItemEndurance / 100d), 0);
    }

    public static int GetCalculatedRepairCost(this HeroItem heroItem)
    {
        if (heroItem == null)
        {
            return 0;
        }

        if (heroItem.Item == null)
        {
            return 0;
        }

        return (int)Math.Round(heroItem.Item.BuyPrice * ((100d - heroItem.ItemEndurance) / 100), 0);
    }
}