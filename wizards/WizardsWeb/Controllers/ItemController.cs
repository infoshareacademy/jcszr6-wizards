using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Wizards.Core.Model.UserModels;
using Wizards.Services.ItemService;
using Wizards.Services.Validation.Elements;
using WizardsWeb.ModelViews.ItemModelViews;
using Microsoft.Extensions.Logging;
using System;

namespace WizardsWeb.Controllers;

[Authorize(Roles = "Admin, Moderator")]
public class ItemController : Controller
{
    private readonly IItemService _itemService;
    private readonly IMapper _mapper;
    private readonly ILogger<ItemController> _logger;

    public ItemController(IItemService itemService, IMapper mapper, ILogger<ItemController> logger)
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
            _logger.LogInformation($"{itemCreate.Name} item create failed", ModelState);
            return View(itemCreate);
        }

        var item = _mapper.Map<Item>(itemCreate);

        try
        {
            await _itemService.Add(item);
            _logger.LogInformation($"{itemCreate.Name} item create successful");
            return RedirectToAction("Index", "Merchant");
        }
        catch (InvalidModelException exception)
        {
            foreach (var data in exception.ModelStatesData)
            {
                ModelState.AddModelError(data.Key, data.Value);
            }

            _logger.LogInformation($"Item {itemCreate.Name} create failed {exception.GetType()}", ModelState);
            return View(itemCreate);

        }
        catch (Exception exception)
        {
            _logger.LogError($"Item {itemCreate.Name} create failed {exception.GetType()}", exception);
            return RedirectToAction("Home", "Error500");
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
            _logger.LogInformation($"Item {itemEdit.Name} edit failed");
            return View(itemEdit);
        }

        var item = _mapper.Map<Item>(itemEdit);

        try
        {
            await _itemService.Update(item);
            _logger.LogInformation($"Item {itemEdit.Name} edit successful");
            return RedirectToAction("Index", "Merchant");
        }
        catch (InvalidModelException exception)
        {
            foreach (var data in exception.ModelStatesData)
            {
                ModelState.AddModelError(data.Key, data.Value);
            }
            _logger.LogInformation($"Item {item.Name} edit failed {exception.GetType()}", ModelState);
            return View(itemEdit);
        }
        catch (Exception exception)
        {
            _logger.LogError($"Item {item.Name} edit failed {exception.GetType()}", exception);
            return RedirectToAction("Home", "Error500");
        }
    }
}