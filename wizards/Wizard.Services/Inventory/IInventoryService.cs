using System.Security.Claims;
using Wizards.Core.Model;

namespace Wizards.Services.Inventory;

public interface IInventoryService
{
    Task<HeroItem> GetHeroItem(ClaimsPrincipal user);
    Task RepairItem(ClaimsPrincipal user);
    Task RepairAllItems(ClaimsPrincipal user, bool equippedOnly = false);
    Task Equip(ClaimsPrincipal user);
    Task Unequip(ClaimsPrincipal user);
}