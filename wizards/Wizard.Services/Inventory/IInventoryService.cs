using System.Security.Claims;
using Wizards.Core.Model.ManyToManyTables;

namespace Wizards.Services.Inventory;

public interface IInventoryService
{
    Task<List<HeroItem>> GetHeroInventory(ClaimsPrincipal user);
    Task<HeroItem> GetHeroItem(ClaimsPrincipal user);
    Task RepairItem(ClaimsPrincipal user);
    Task RepairAllItems(ClaimsPrincipal user, bool equippedOnly = false);
    Task Equip(ClaimsPrincipal user);
    Task Unequip(ClaimsPrincipal user);
}