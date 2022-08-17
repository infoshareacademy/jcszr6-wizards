using System.Security.Claims;
using Wizards.Core.Interfaces;
using Wizards.Core.Model;
using Wizards.Services.Helpers;
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

        var repairCost = heroItem.GetCalculatedRepairCost();
        if (repairCost <= 0)
        {
            var message = new Dictionary<string, string>();
            message.Add("", "This item cannot be repaired now!");
            throw new InvalidModelException(message);
        }

        if (!CanRepair(hero, repairCost))
        {
            var message = new Dictionary<string, string>();
            message.Add("", "You have not enough gold to repair this item!");
            throw new InvalidModelException(message);
        }

        heroItem.ItemEndurance = 100.00d;
        await _heroItemRepository.UpdateAsync(heroItem);
        await _heroService.SpendGold(hero, repairCost);
    }

    public async Task RepairAllItems(ClaimsPrincipal user, bool equippedOnly = false)
    {
        var inventory = await GetHeroInventory(user);
        var hero = await _heroService.Get(user);

        var itemsToRepair = new List<HeroItem>();

        if (!equippedOnly)
        {
            itemsToRepair = inventory.Where(hi => hi.ItemEndurance < 99d && hi.GetCalculatedRepairCost() >= 1).ToList();
        }
        else
        {
            itemsToRepair = inventory.Where(hi => hi.ItemEndurance < 99d && hi.GetCalculatedRepairCost() >= 1 && hi.InUse).ToList();
        }

        var repairCost = itemsToRepair.Sum(hi => hi.GetCalculatedRepairCost());
        
        if (repairCost <= 0)
        {
            var message = new Dictionary<string, string>();
            message.Add("", "All items are already repaired!");
            throw new InvalidModelException(message);
        }

        if (!CanRepair(hero, repairCost))
        {
            var message = new Dictionary<string, string>();
            message.Add("", "You have not enough gold to repair this item!");
            throw new InvalidModelException(message);
        }

        foreach (var heroItem in itemsToRepair)
        {
            var cost = heroItem.GetCalculatedRepairCost();
            heroItem.ItemEndurance = 100.00d;
            await _heroItemRepository.UpdateAsync(heroItem);
            await _heroService.SpendGold(hero, cost);
        }
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