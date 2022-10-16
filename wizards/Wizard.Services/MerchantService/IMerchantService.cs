using System.Security.Claims;
using Wizards.Core.Model.UserModels;

namespace Wizards.Services.MerchantService;

public interface IMerchantService
{
    Task BuyItemAsync(int itemId, ClaimsPrincipal user);
    Task SellItemAsync(ClaimsPrincipal user);
    Task<List<Item>> GetMerchantStorageAsync(ClaimsPrincipal user);
}