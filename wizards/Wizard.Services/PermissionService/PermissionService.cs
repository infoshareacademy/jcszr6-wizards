using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Wizards.Core.Model;
using Wizards.Core.Model.ManyToManyTables;
using Wizards.Services.HeroService;
using Wizards.Services.PlayerService;

namespace Wizards.Services.PermissionService;

public class PermissionService : IPermissionService
{
    private readonly IPlayerService _playerService;
    private readonly IHeroService _heroService;
    private readonly SignInManager<Player> _signInManager;

    public PermissionService(
        IPlayerService playerService, IHeroService heroService, 
        SignInManager<Player> signInManager)
    {
        _playerService = playerService;
        _heroService = heroService;
        _signInManager = signInManager;
    }

    public PermissionResult HasPermission(ClaimsPrincipal user, Hero hero)
    {
        if (!_signInManager.IsSignedIn(user))
        {
            return PermissionResult.UserNotLoggedIn;
        }

        var playerId = _playerService.GetId(user);

        if (playerId == hero.PlayerId)
        {
            return PermissionResult.PermissionGranted;
        }

        return PermissionResult.PermissionDenied;
    }

    public PermissionResult HasPermission(ClaimsPrincipal user)
    {
        if (!_signInManager.IsSignedIn(user))
        {
            return PermissionResult.UserNotLoggedIn;
        }

        return PermissionResult.PermissionGranted;
    }

    public PermissionResult HasPermission(ClaimsPrincipal user, HeroItem item)
    {
        //TODO: Next step: implement this method after adding Inventory and merchant feature
        throw new NotImplementedException();
    }
}