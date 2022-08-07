using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wizards.Services.HeroService;
using Wizards.Services.PlayerService;

namespace WizardsWeb.Controllers;

public class SelectorController : Controller
{
    private readonly IAuthorizationService _authorizationService;
    private readonly IHeroService _heroService;
    private readonly IPlayerService _playerService;

    public SelectorController(IHeroService heroService, IAuthorizationService authorizationService, IPlayerService playerService)
    {
        _authorizationService = authorizationService;
        _heroService = heroService;
        _playerService = playerService;
    }

    public async Task<ActionResult> SelectHero(int id, string actionName)
    {
        var hero = await _heroService.Get(id);
        var authorizationResult = await _authorizationService.AuthorizeAsync(User, hero, "HeroOwnerPolicy");

        if (authorizationResult.Succeeded)
        {
            var player = await _playerService.Get(User);
            await _playerService.SetActiveHero(player, id);
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
}