using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wizards.Core.Model.Enums;
using Wizards.Services.Helpers;
using Wizards.Services.HeroService;
using Wizards.Services.Inventory;
using Wizards.Services.Validation.Elements;
using WizardsWeb.ModelViews.HeroModelViews.Properties;
using WizardsWeb.ModelViews.Inventory;

namespace WizardsWeb.Controllers;
[Authorize]
public class InventoryController : Controller
{
    private readonly IInventoryService _inventoryService;
    private readonly IMapper _mapper;
    private readonly IHeroService _heroService;

    public InventoryController(IInventoryService inventoryService, IMapper mapper, IHeroService heroService)
    {
        _inventoryService = inventoryService;
        _mapper = mapper;
        _heroService = heroService;
    }

    // /Inventory/Index/
    public async Task<IActionResult> Index()
    {
        var inventoryModelView = await InventoryModelView();

        return View(inventoryModelView);
    }

    public async Task<ActionResult> Equip()
    {
        try
        {
            await _inventoryService.Equip(User);
        }
        catch (Exception exception)
        {

        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<ActionResult> Unequip()
    {
        try
        {
            await _inventoryService.Unequip(User);
        }
        catch (Exception exception)
        {

        }

        return RedirectToAction(nameof(Index));
    }


    public async Task<ActionResult> Repair()
    {
        try
        {
            await _inventoryService.RepairItem(User);
            return RedirectToAction(nameof(Index));
        }
        catch (InvalidModelException exception)
        {
            var inventoryModelView = await InventoryModelView();
            ModelState.AddModelErrorByException(exception);
            return View(nameof(Index), inventoryModelView);
        }
    }

    public async Task<ActionResult> RepairAll()
    {
        try
        {
            await _inventoryService.RepairAllItems(User);
        }
        catch (InvalidModelException exception)
        {
            var inventoryModelView = await InventoryModelView();
            ModelState.AddModelErrorByException(exception);
            return View(nameof(Index), inventoryModelView);
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<ActionResult> RepairEquipped()
    {
        try
        {
            await _inventoryService.RepairAllItems(User, true);
        }
        catch (InvalidModelException exception)
        {
            var inventoryModelView = await InventoryModelView();
            ModelState.AddModelErrorByException(exception);
            return View(nameof(Index), inventoryModelView);
        }

        return RedirectToAction(nameof(Index));
    }


    private async Task<InventoryModelView> InventoryModelView()
    {
        var inventoryModelView = new InventoryModelView();

        var hero = await _heroService.Get(User);
        var attributes = hero.GetCalculatedAttributes();

        inventoryModelView.Attributes = _mapper.Map<HeroAttributesModelView>(attributes);
        inventoryModelView.Gold = hero.Gold;
        inventoryModelView.HerosAvargeItemTier = hero.GetAvargeItemTier();

        var heroInventory = await _inventoryService.GetHeroInventory(User);
        var mappedItems = _mapper.Map<List<HeroItemDetailsModelView>>(heroInventory);

        inventoryModelView.Equipped.AddRange(mappedItems
            .Where(hi => hi.IsEquipped)
            .OrderBy(hi => hi.Type));

        inventoryModelView.Weapons.AddRange(mappedItems
            .Where(hi => hi.Type == ItemType.Weapon && !hi.IsEquipped)
            .OrderByDescending(hi => hi.Tier)
            .ThenBy(hi => hi.Name));

        inventoryModelView.Armors.AddRange(mappedItems
            .Where(hi => hi.Type == ItemType.Armor && !hi.IsEquipped)
            .OrderByDescending(hi => hi.Tier)
            .ThenBy(hi => hi.Name));

        inventoryModelView.Miscellaneous.AddRange(mappedItems
            .Where(hi => hi.Type != ItemType.Armor && hi.Type != ItemType.Weapon)
            .OrderByDescending(hi => hi.Tier)
            .ThenBy(hi => hi.Name));
        return inventoryModelView;
    }
}