﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wizards.Core.Model.UserModels.Enums;
using Wizards.Core.ModelExtensions;
using Wizards.Services.Extensions;
using Wizards.Services.HeroService;
using Wizards.Services.Inventory;
using Wizards.Services.Validation.Elements;
using WizardsWeb.ModelViews.HeroModelViews.Properties;
using WizardsWeb.ModelViews.Inventory;
using WizardsWeb.ModelViews.ItemModelViews;

namespace WizardsWeb.Controllers;
[Authorize]
public class InventoryController : Controller
{
    private readonly IInventoryService _inventoryService;
    private readonly IMapper _mapper;
    private readonly IHeroService _heroService;
    private readonly ILogger<InventoryController> _logger;


    public InventoryController(IInventoryService inventoryService, IMapper mapper, IHeroService heroService, ILogger<InventoryController> logger)
    {
        _inventoryService = inventoryService;
        _mapper = mapper;
        _heroService = heroService;
        _logger = logger;
    }

    // /Inventory/Index/
    public async Task<IActionResult> Index()
    {
        try
        {
            var inventoryModelView = await InventoryModelView();
            return View(inventoryModelView);
        }
        catch (Exception exception)
        {
            return RedirectToAction("Details", "Hero");
        }
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
            _logger.LogInformation($"{User} repaired item");
            return RedirectToAction(nameof(Index));
        }
        catch (InvalidModelException exception)
        {
            var inventoryModelView = await InventoryModelView();
            ModelState.AddModelErrorByException(exception);
            _logger.LogInformation($"{User} failed to repair item {exception.GetType()}", ModelState);
            return View(nameof(Index), inventoryModelView);
        }
    }

    public async Task<ActionResult> RepairAll()
    {
        try
        {
            _logger.LogInformation($"{User} repaired all items");
            await _inventoryService.RepairAllItems(User);
        }
        catch (InvalidModelException exception)
        {
            var inventoryModelView = await InventoryModelView();
            ModelState.AddModelErrorByException(exception);
            _logger.LogInformation($"{User} failed to repair all items {exception.GetType()}", ModelState);
            return View(nameof(Index), inventoryModelView);
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<ActionResult> RepairEquipped()
    {
        try
        {
            _logger.LogInformation($"{User} repaired equipment items");
            await _inventoryService.RepairAllItems(User, true);
        }
        catch (InvalidModelException exception)
        {
            var inventoryModelView = await InventoryModelView();
            ModelState.AddModelErrorByException(exception);
            _logger.LogInformation($"{User} failed to repair equipment items {exception.GetType()}", ModelState);
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
        inventoryModelView.HeroSummary = _mapper.Map<HeroSummaryModelView>(hero);
        inventoryModelView.HeroNickName = hero.NickName;

        var mappedItems = _mapper.Map<List<ItemDetailsModelView>>(hero.Inventory);

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