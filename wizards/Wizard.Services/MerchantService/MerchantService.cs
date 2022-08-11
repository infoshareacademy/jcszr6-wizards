using System.Security.Claims;
using Wizards.Core.Interfaces;
using Wizards.Core.Model;
using Wizards.Core.Model.Enums;
using Wizards.Core.Model.ManyToManyTables;

namespace Wizards.Services.MerchantService;

public class MerchantService : IMerchantService
{
    private readonly IHeroItemRepository _heroItemRepository;
    private readonly IItemRepository _itemRepository;
    private readonly IHeroRepository _heroRepository;

    public MerchantService(IHeroItemRepository heroItemRepository, IItemRepository itemRepository, IHeroRepository heroRepository)
    {
        _heroItemRepository = heroItemRepository;
        _itemRepository = itemRepository;
        _heroRepository = heroRepository;
    }

    public async Task BuyItemAsync(int itemId, int heroId)
    {
        var hero = await _heroRepository.Get(heroId);
        var item = await _itemRepository.Get(itemId);

        var heroItem = new HeroItem() { HeroId = heroId, ItemId = itemId, InUse = false, ItemEndurance = 100d, };

        await _heroItemRepository.AddAsync(heroItem);
    }

    public Task SellItemAsync(int heroItemId)
    {
        throw new NotImplementedException();
    }

    public Task<HeroItem> GetHeroItemAsync(ClaimsPrincipal user)
    {
        throw new NotImplementedException();
    }

    public Task<Item> GetItemAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Item>> GetMerchantStorageAsync(ProfessionRestriction professionRestriction)
    {
        throw new NotImplementedException();
    }
}