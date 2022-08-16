using Wizards.Core.Model;

namespace Wizards.Services.Helpers;

public static class HeroExtensions
{
    public static double GetAvargeItemTier(this Hero hero)
    {
        var avargeItemTier = hero.Inventory
            .Where(hi => hi.InUse)
            .Select(hi => hi.Item.Tier)
            .Average();
        
        return Math.Round(avargeItemTier, 2);
    }
}