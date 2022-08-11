using System.Security.Claims;
using Wizards.Core.Model;
using Wizards.Core.Model.Enums;
using Wizards.Core.Model.ManyToManyTables;

namespace Wizards.Services.MerchantService;

public interface IMerchantService
{
    Task BuyItemAsync(int itemId, int heroId);
    Task SellItemAsync(int heroItemId);
    Task<HeroItem> GetHeroItemAsync(ClaimsPrincipal user);
    Task<Item> GetItemAsync(int id);
    Task<List<Item>> GetMerchantStorageAsync(ProfessionRestriction professionRestriction);
}