using Wizards.Core.Model;

namespace Wizards.Services.Helpers;

public static class HeroExtensions
{
    public static double GetAvargeItemTier(this Hero hero)
    {
        if (hero == null)
        {
            return 0d;
        }

        if (!hero.Inventory.Any(hi => hi.InUse))
        {
            return 0d;
        }

        var avargeItemTier = hero.Inventory
            .Where(hi => hi.InUse)
            .Select(hi => hi.Item.Tier)
            .Average();
        
        return Math.Round(avargeItemTier, 2);
    }
}