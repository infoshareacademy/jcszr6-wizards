using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Wizards.Core.Model;
using Wizards.Core.Model.UserModels;
using Wizards.Services.ItemService;
using Wizards.Services.Validation.Elements;
using WizardsWeb.ModelViews.ItemModelViews;
using Microsoft.Extensions.Logging;
using System;
using Wizards.Core.Interfaces.LoggerInterface;

namespace WizardsWeb.Controllers;

[Authorize(Roles = "Admin, Moderator")]
public class ItemController : Controller
{
    private readonly IItemService _itemService;
    private readonly IMapper _mapper;
    private readonly IWizardsLogger _logger;

    public ItemController(IItemService itemService, IMapper mapper, IWizardsLogger logger)
    {
        _itemService = itemService;
        _mapper = mapper;
        _logger = logger;
    }

    // GET: ItemController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: ItemController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(ItemCreateModelView itemCreate)
    {
        if (!ModelState.IsValid)
        {
            await _logger.SendLogAsync<ItemController>(LogLevel.Information,$"{itemCreate.Name} item create failed (incorrect validation state)", ModelState);
            return View(itemCreate);
        }

        var item = _mapper.Map<Item>(itemCreate);

        try
        {
            await _itemService.Add(item);
            await _logger.SendLogAsync<ItemController>(LogLevel.Information, $"{itemCreate.Name} item create successful");
            return RedirectToAction("Index", "Merchant");
        }
        catch (InvalidModelException exception)
        {
            foreach (var data in exception.ModelStatesData)
            {
                ModelState.AddModelError(data.Key, data.Value);
            }

            await _logger.SendLogAsync<ItemController>(LogLevel.Information, $"Item {itemCreate.Name} create failed {exception.GetType()}", ModelState, exception);
            return View(itemCreate);

        }
        catch (Exception exception)
        {
            await _logger.SendLogAsync<ItemController>(LogLevel.Error, $"Item {itemCreate.Name} create failed {exception.GetType()}", exception);
            return RedirectToAction("Error500", "Home");
        }
    }
    // GET: ItemController/Edit/5
    public async Task<ActionResult> Edit(int id)
    {
        var item = await _itemService.Get(id);
        var itemEdit = _mapper.Map<ItemEditModelView>(item);
        return View(itemEdit);
    }

    // POST: ItemController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(ItemEditModelView itemEdit)
    {
        if (!ModelState.IsValid)
        {
            await _logger.SendLogAsync<ItemController>(LogLevel.Information, $"Item {itemEdit.Name} edit failed", ModelState);
            return View(itemEdit);
        }

        var item = _mapper.Map<Item>(itemEdit);

        try
        {
            await _itemService.Update(item);
            await _logger.SendLogAsync<ItemController>(LogLevel.Information, $"Item {itemEdit.Name} edit successful");
            return RedirectToAction("Index", "Merchant");
        }
        catch (InvalidModelException exception)
        {
            foreach (var data in exception.ModelStatesData)
            {
                ModelState.AddModelError(data.Key, data.Value);
            }
            await _logger.SendLogAsync<ItemController>(LogLevel.Information, $"Item {item.Name} edit failed {exception.GetType()}", ModelState, exception);
            return View(itemEdit);
        }
        catch (Exception exception)
        {
            await _logger.SendLogAsync<ItemController>(LogLevel.Error, $"Item {item.Name} edit failed {exception.GetType()}", exception);
            return RedirectToAction("Error500", "Home");
        }
    }
}