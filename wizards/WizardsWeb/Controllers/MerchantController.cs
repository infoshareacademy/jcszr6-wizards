using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wizards.Core.Interfaces.LoggerInterface;
using Wizards.Core.Model.UserModels.Enums;
using Wizards.Services.Extensions;
using Wizards.Services.HeroService;
using Wizards.Services.Inventory;
using Wizards.Services.ItemService;
using Wizards.Services.MerchantService;
using Wizards.Services.Validation.Elements;
using WizardsWeb.ModelViews.ItemModelViews;
using WizardsWeb.ModelViews.Merchant;

namespace WizardsWeb.Controllers;

public class MerchantController : Controller
{
    private readonly IMapper _mapper;
    private readonly IMerchantService _merchantService;
    private readonly IHeroService _heroService;
    private readonly IItemService _itemService;
    private readonly IInventoryService _inventoryService;
    private readonly IWizardsLogger _logger;


    public MerchantController(IMapper mapper,
                              IMerchantService merchantService,
                              IHeroService heroService,
                              IItemService itemService,
                              IInventoryService inventoryService,
                              IWizardsLogger logger)
    {
        _mapper = mapper;
        _merchantService = merchantService;
        _heroService = heroService;
        _itemService = itemService;
        _inventoryService = inventoryService;
        _logger = logger;
    }

    public async Task<ActionResult> Index()
    {
        try
        {
            var merchantModel = await MerchantModelView();
            return View(merchantModel);
        }
        catch (Exception e)
        {
            return RedirectToAction("Details", "Hero");
        }
    }

    public async Task<ActionResult> BuyItem(int id)
    {
        var hero = await _heroService.Get(User);
        var item = await _itemService.Get(id);
        try
        {
            await _merchantService.BuyItemAsync(id, User);
            await _logger.SendLogAsync<MerchantController>(LogLevel.Information, $"{hero.NickName} bought a {item.Name}", hero, item);
            return RedirectToAction(nameof(Index));
        }
        catch (InvalidModelException exception)
        {
            var merchantModel = await MerchantModelView();
            ModelState.AddModelErrorByException(exception);
            if (exception is InvalidModelException)
            {
                await _logger.SendLogAsync<MerchantController>(LogLevel.Information, $"{hero.NickName} failed to buy an item {exception.GetType()}", ModelState, exception);
            }

            return View(nameof(Index), merchantModel);
        }
        catch (Exception exception)
        {
            await _logger.SendLogAsync<MerchantController>(LogLevel.Error, $"{hero.NickName} failed to buy an item {exception.GetType()}", exception);
            return RedirectToAction("Error500", "Home");
        }
    }

    public async Task<ActionResult> SellItem()
    {
        var hero = await _heroService.Get(User);
        var heroItem = await _inventoryService.GetHeroItem(User);
        try
        {
            await _merchantService.SellItemAsync(User);
            await _logger.SendLogAsync<MerchantController>(LogLevel.Information, $"{hero.NickName} sold item {heroItem.Item.Name} successful");
            return RedirectToAction(nameof(Index));
        }
        catch (InvalidModelException exception)
        {
            var merchantModel = await MerchantModelView();
            ModelState.AddModelErrorByException(exception);
            if (exception is InvalidModelException)
            {
                await _logger.SendLogAsync<MerchantController>(LogLevel.Information, $"{hero.NickName} sell item failed {exception.GetType()}", ModelState, exception);
            }
            return View(nameof(Index), merchantModel);
        }
        catch (Exception exception)
        {
            await _logger.SendLogAsync<MerchantController>(LogLevel.Error, $"{hero.NickName} failed to buy an item  {exception.GetType()}", exception);
            return RedirectToAction("Error500", "Home");
        }
    }

    private async Task<MerchantModelView> MerchantModelView()
    {
        var merchantModel = new MerchantModelView();
        var hero = await _heroService.Get(User);

        merchantModel.HeroStorage.Gold = hero.Gold;
        merchantModel.HeroStorage.HeroNickName = hero.NickName;

        var items = await _merchantService.GetMerchantStorageAsync(User);
        var merchantItems = _mapper.Map<List<ItemDetailsModelView>>(items);

        merchantModel.MerchantStorage.Weapons = merchantItems
            .Where(i => i.Type == ItemType.Weapon)
            .OrderByDescending(i => i.Tier)
            .ThenBy(i => i.Name)
            .ToList();

        merchantModel.MerchantStorage.Armors = merchantItems
            .Where(i => i.Type == ItemType.Armor)
            .OrderByDescending(i => i.Tier)
            .ThenBy(i => i.Name)
            .ToList();

        merchantModel.MerchantStorage.Miscellaneous = merchantItems
            .Where(i => i.Type != ItemType.Weapon && i.Type != ItemType.Armor)
            .OrderByDescending(i => i.Tier)
            .ThenBy(i => i.Name)
            .ToList();

        var inventoryItems = _mapper.Map<List<ItemDetailsModelView>>(hero.Inventory);
        inventoryItems.ForEach(i => i.IsInMerchantMode = true);

        merchantModel.HeroStorage.Weapons = inventoryItems
            .Where(hi => hi.Type == ItemType.Weapon && !hi.IsEquipped)
            .OrderByDescending(hi => hi.Tier)
            .ThenBy(hi => hi.Name)
            .ToList();

        merchantModel.HeroStorage.Armors = inventoryItems
            .Where(hi => hi.Type == ItemType.Armor && !hi.IsEquipped)
            .OrderByDescending(hi => hi.Tier)
            .ThenBy(hi => hi.Name)
            .ToList();

        merchantModel.HeroStorage.Miscellaneous = inventoryItems
            .Where(hi => hi.Type != ItemType.Weapon && hi.Type != ItemType.Armor)
            .OrderByDescending(hi => hi.Tier)
            .ThenBy(hi => hi.Name)
            .ToList();

        return merchantModel;
    }
}