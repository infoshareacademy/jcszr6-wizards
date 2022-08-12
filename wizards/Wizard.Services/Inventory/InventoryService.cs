using System.Security.Claims;
using Wizards.Core.Interfaces;
using Wizards.Core.Model;
using Wizards.Core.Model.ManyToManyTables;
using Wizards.Services.HeroService;
using Wizards.Services.PlayerService;
using Wizards.Services.Validation.Elements;

namespace Wizards.Services.Inventory;

public class InventoryService : IInventoryService
{
    private readonly IHeroItemRepository _heroItemRepository;
    private readonly IHeroService _heroService;
    private readonly IPlayerService _playerService;

    public InventoryService(IHeroItemRepository heroItemRepository, IHeroService heroService, IPlayerService playerService)
    {
        _heroItemRepository = heroItemRepository;
        _heroService = heroService;
        _playerService = playerService;
    }
    public async Task<List<HeroItem>> GetHeroInventory(ClaimsPrincipal user)
    {
        var inventory = (await _heroService.Get(user)).Inventory;
        return inventory;
    }

    public async Task<HeroItem> GetHeroItem(ClaimsPrincipal user)
    {
        var player = await _playerService.Get(user);
        var itemId = player.ActiveItemId;
        var heroItem = await _heroItemRepository.GetAsync(itemId);

        if (heroItem == null)
        {
            throw new NullReferenceException($"There is no item with id: {itemId}");
        }

        return heroItem;
    }

    public async Task RepairItem(ClaimsPrincipal user)
    {
        var heroItem = await GetHeroItem(user);
        var hero = await _heroService.Get(user);

        var repairCost = (int)Math.Round(heroItem.Item.BuyPrice * ((100d - heroItem.ItemEndurance) / 100), 0);

        if (!CanRepair(hero, repairCost))
        {
            var message = new Dictionary<string, string>();
            message.Add("Gold", "You have not enough gold!");
            throw new InvalidModelException(message);
        }

        heroItem.ItemEndurance = 100.00d;
        await _heroItemRepository.UpdateAsync(heroItem);
        await _heroService.SpendGold(hero, repairCost);
    }

    public async Task Equip(ClaimsPrincipal user)
    {
        var hero = await _heroService.Get(user);
        var heroItem = await GetHeroItem(user);

        if (heroItem.InUse)
        {
            return;
        }

        var usedItems = hero.Inventory.Where(hi => hi.InUse).ToList();
        var itemToUnequip = usedItems.SingleOrDefault(hi => hi.Item.Type == heroItem.Item.Type);
        
        if (itemToUnequip != null)
        {
            itemToUnequip.InUse = false;
            await _heroItemRepository.UpdateAsync(itemToUnequip);
        }

        heroItem.InUse = true;
        await _heroItemRepository.UpdateAsync(heroItem);
    }

    public async Task Unequip(ClaimsPrincipal user)
    {
        var heroItem = await GetHeroItem(user);

        if (!heroItem.InUse)
        {
            return;
        }

        heroItem.InUse = false;
        
        await _heroItemRepository.UpdateAsync(heroItem);
    }

    private bool CanRepair(Hero hero, int cost)
    {
        if (hero == null || cost < 0)
        {
            return false;
        }

        if (hero.Gold >= cost)
        {
            return true;
        }

        return false;
    }
}