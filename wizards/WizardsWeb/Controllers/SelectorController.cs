using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wizards.Services.HeroService;
using Wizards.Services.PlayerService;
using Wizards.Services.Selector;

namespace WizardsWeb.Controllers;

public class SelectorController : Controller
{
    private readonly IAuthorizationService _authorizationService;
    private readonly ISelector _selector;

    public SelectorController(IAuthorizationService authorizationService, ISelector selector)
    {
        _authorizationService = authorizationService;
        _selector = selector;
    }

    public async Task<ActionResult> SelectHero(int id, string actionName)
    {
        var hero = await _selector.GetHeroAsync(id);
        var authorizationResult = await _authorizationService.AuthorizeAsync(User, hero, "HeroOwnerPolicy");

        if (authorizationResult.Succeeded)
        {
            var player = await _selector.GetPlayerAsync(User);
            await _selector.SelectHero(player, id);
            return RedirectToAction(actionName, "Hero");
        }
        
        if (!User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Login", "Player");
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