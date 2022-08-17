using System.Security.Claims;
using Wizards.Core.Interfaces;
using Wizards.Core.Model;
using Wizards.Core.Model.Enums;
using Wizards.Services.Helpers;
using Wizards.Services.HeroService;
using Wizards.Services.Inventory;
using Wizards.Services.Validation.Elements;

namespace Wizards.Services.MerchantService;

public class MerchantService : IMerchantService
{
    private readonly IHeroItemRepository _heroItemRepository;
    private readonly IItemRepository _itemRepository;
    private readonly IHeroService _heroService;
    private readonly IInventoryService _inventoryService;

    public MerchantService(IHeroItemRepository heroItemRepository, IItemRepository itemRepository, IHeroService heroService, IInventoryService inventoryService)
    {
        _heroItemRepository = heroItemRepository;
        _itemRepository = itemRepository;
        _heroService = heroService;
        _inventoryService = inventoryService;
    }

    public async Task BuyItemAsync(int itemId, ClaimsPrincipal user)
    {
        var hero = await _heroService.Get(user);
        var item = await _itemRepository.Get(itemId);

        if (!CanBuy(hero, item))
        {
            var message = new Dictionary<string, string>();
            message.Add("Gold", "You have not enough gold!");
            throw new InvalidModelException(message);
        }

        var heroItem = new HeroItem() { HeroId = hero.Id, ItemId = itemId, InUse = false, ItemEndurance = 100d };

        await _heroItemRepository.AddAsync(heroItem);
        await _heroService.SpendGold(hero, item.BuyPrice);
    }

    public async Task SellItemAsync(ClaimsPrincipal user)
    {
        var hero = await _heroService.Get(user);
        var heroItem = await _inventoryService.GetHeroItem(user);
        var calculatedSellPrice = heroItem.GetCalculatedSellPrice();

        await _heroItemRepository.DeleteAsync(heroItem);
        await _heroService.ClaimGold(hero, calculatedSellPrice);
    }

    public async Task<List<Item>> GetMerchantStorageAsync(ClaimsPrincipal user)
    {
        var hero = await _heroService.Get(user);
        var professionRestriction = Enum.Parse<ProfessionRestriction>(hero.Profession.ToString());
        
        var result = await _itemRepository.GetAll(professionRestriction);
        result.AddRange(await _itemRepository.GetAll(ProfessionRestriction.All));

        return result;
    }

    private bool CanBuy(Hero hero, Item item)
    {
        if (hero == null || item == null)
        {
            return false;
        }

        if (hero.Gold >= item.BuyPrice)
        {
            return true;
        }

        return false;
    }
}