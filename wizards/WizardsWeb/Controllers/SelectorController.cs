using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wizards.Core.Interfaces.LoggerInterface;
using Wizards.Core.Model;
using Wizards.Core.Model.UserModels;
using Wizards.Services.AuthorizationElements.Selector;

namespace WizardsWeb.Controllers;

public class SelectorController : Controller
{
    private readonly IAuthorizationService _authorizationService;
    private readonly ISelector _selector;
    private readonly IWizardsLogger _logger;
    private readonly List<string> _allowedHeroActions;
    private readonly List<string> _allowedInventoryActions;
    private readonly List<string> _allowedMerchantActions;

    public SelectorController(IAuthorizationService authorizationService, ISelector selector, IWizardsLogger logger)
    {
        _authorizationService = authorizationService;
        _selector = selector;
        _logger = logger;

        _allowedHeroActions = GetAllowedActions(typeof(HeroController));
        _allowedMerchantActions = GetAllowedActions(typeof(MerchantController));
        _allowedInventoryActions = GetAllowedActions(typeof(InventoryController)); 
    }

    public async Task<ActionResult> SelectHero(int id, string actionName)
    {
        if (actionName == null || !_allowedHeroActions.Contains(actionName))
        {
            await _logger.SendLogAsync<PlayerController>(LogLevel.Error, $"{actionName} is not correct");
            return RedirectToAction("Details", "Player");
        }

        var hero = new Hero();

        try
        {
            hero = await _selector.GetHeroAsync(id);
        }
        catch
        {
            await _logger.SendLogAsync<PlayerController>(LogLevel.Error, $"There is no hero with id: {id}");
            return RedirectToAction("Error404", "Home");
        }

        var authorizationResult = await _authorizationService.AuthorizeAsync(User, hero, "HeroOwnerPolicy");
        var player = await _selector.GetPlayerAsync(User);

        if (authorizationResult.Succeeded)
        {
            await _selector.SelectHero(player, id);
            await _logger.SendLogAsync<PlayerController>(LogLevel.Information, $"Access to hero: {hero.NickName} granted to player {player.UserName}");
            return RedirectToAction(actionName, "Hero");
        }

        if (!authorizationResult.Succeeded)
        {
            await _logger.SendLogAsync<PlayerController>(LogLevel.Information, $"Access to hero: {hero.NickName} denied to player {player.UserName}");
            return RedirectToAction("Details", "Player");
        }

        await _logger.SendLogAsync<PlayerController>(LogLevel.Error, "Unexpected permission result occurs. User redirected to Home/Index page");
        return RedirectToAction("Index", "Home");
    }

    public async Task<ActionResult> SelectItem(int id, string actionName, string controllerName = "Inventory")
    {
        var allowedActions = _allowedInventoryActions;
        
        if (controllerName == "Merchant")
        {
            allowedActions = _allowedMerchantActions;
        }

        if (actionName == null || !allowedActions.Contains(actionName))
        {
            await _logger.SendLogAsync<PlayerController>(LogLevel.Error, $"{actionName} is not correct");
            return RedirectToAction("Index", controllerName);
        }

        var heroItem = new HeroItem();

        try
        {
            heroItem = await _selector.GetHeroItemAsync(id);
        }
        catch
        {
            await _logger.SendLogAsync<PlayerController>(LogLevel.Error, $"There is no heroItem with id: {id}");
            return RedirectToAction("Index", controllerName);
        }

        var authorizationResult = await _authorizationService.AuthorizeAsync(User, heroItem, "ItemOwnerPolicy");
        var player = await _selector.GetPlayerAsync(User);

        if (authorizationResult.Succeeded)
        {
            await _selector.SelectItem(player, id);
            await _logger.SendLogAsync<PlayerController>(LogLevel.Information, $"Access to hero: {heroItem.Item.Name} granted to player {player.UserName}");
            return RedirectToAction(actionName, controllerName);
        }

        if (!authorizationResult.Succeeded)
        {
            await _logger.SendLogAsync<PlayerController>(LogLevel.Information, $"Access to hero: {heroItem.Item.Name} denied to player {player.UserName}");
            return RedirectToAction("Details", "Hero");
        }

        await _logger.SendLogAsync<PlayerController>(LogLevel.Error, "Unexpected permission result occurs. User redirected to Home/Index page");
        return RedirectToAction("Index", "Home");
    }


    private List<string> GetAllowedActions(Type controllerType)
    {
        if (controllerType == null || controllerType.BaseType != typeof(Controller))
        {
            return new List<string>();
        }

        var returnedTypes = new List<Type>()
        {
            typeof(ActionResult), typeof(IActionResult), typeof(Task<IActionResult>), typeof(Task<ActionResult>)
        };

        var methodsNames = controllerType.GetMethods()
            .Where(m => returnedTypes.Contains(m.ReturnType))
            .Select(m => m.Name)
            .ToList();

        return methodsNames;
    }
}