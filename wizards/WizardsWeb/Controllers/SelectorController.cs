using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wizards.Core.Model;
using Wizards.Core.Model.UserModels;
using Wizards.Services.AuthorizationElements.Selector;

namespace WizardsWeb.Controllers;

public class SelectorController : Controller
{
    private readonly IAuthorizationService _authorizationService;
    private readonly ISelector _selector;
    private readonly List<string> _allowedHeroActions;
    private readonly List<string> _allowedInventoryActions;
    private readonly List<string> _allowedMerchantActions;

    public SelectorController(IAuthorizationService authorizationService, ISelector selector)
    {
        _authorizationService = authorizationService;
        _selector = selector;
        
        _allowedHeroActions = GetAllowedActions(typeof(HeroController));
        _allowedMerchantActions = GetAllowedActions(typeof(MerchantController));
        _allowedInventoryActions = GetAllowedActions(typeof(InventoryController)); 
    }

    public async Task<ActionResult> SelectHero(int id, string actionName)
    {
        if (actionName == null || !_allowedHeroActions.Contains(actionName))
        {
            return RedirectToAction("Details", "Player");
        }

        var hero = new Hero();

        try
        {
            hero = await _selector.GetHeroAsync(id);
        }
        catch
        {
            return RedirectToAction("Details", "Player");
        }

        var authorizationResult = await _authorizationService.AuthorizeAsync(User, hero, "HeroOwnerPolicy");

        if (authorizationResult.Succeeded)
        {
            var player = await _selector.GetPlayerAsync(User);
            await _selector.SelectHero(player, id);
            return RedirectToAction(actionName, "Hero");
        }

        if (!authorizationResult.Succeeded)
        {
            return RedirectToAction("Details", "Player");
        }

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
            return RedirectToAction("Index", controllerName);
        }

        var heroItem = new HeroItem();

        try
        {
            heroItem = await _selector.GetHeroItemAsync(id);
        }
        catch
        {
            return RedirectToAction("Index", controllerName);
        }

        var authorizationResult = await _authorizationService.AuthorizeAsync(User, heroItem, "ItemOwnerPolicy");

        if (authorizationResult.Succeeded)
        {
            var player = await _selector.GetPlayerAsync(User);
            await _selector.SelectItem(player, id);
            return RedirectToAction(actionName, controllerName);
        }

        if (!authorizationResult.Succeeded)
        {
            return RedirectToAction("Details", "Hero");
        }

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