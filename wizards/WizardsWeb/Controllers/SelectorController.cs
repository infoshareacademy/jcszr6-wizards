using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wizards.Core.Model;
using Wizards.Services.Selector;

namespace WizardsWeb.Controllers;

public class SelectorController : Controller
{
    private readonly IAuthorizationService _authorizationService;
    private readonly ISelector _selector;
    private readonly List<string> _allowedHeroActions;

    public SelectorController(IAuthorizationService authorizationService, ISelector selector)
    {
        _authorizationService = authorizationService;
        _selector = selector;
        _allowedHeroActions = new List<string>() { "Details", "Delete" };
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

    public async Task<ActionResult> SelectItem(int id, string actionName)
    {
        return RedirectToAction("Index", "Home");
    }
}