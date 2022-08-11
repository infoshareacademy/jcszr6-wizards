using System.Security.Claims;
using Wizards.Core.Model;
using Wizards.Core.Model.Enums;
using Wizards.Core.Model.ManyToManyTables;

namespace Wizards.Services.MerchantService;

public interface IMerchantService
{
    Task BuyItemAsync(int itemId, ClaimsPrincipal user);
    Task SellItemAsync(ClaimsPrincipal user);
    Task<List<Item>> GetMerchantStorageAsync(ClaimsPrincipal user);
}