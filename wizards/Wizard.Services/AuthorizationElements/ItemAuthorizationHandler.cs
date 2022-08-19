using Microsoft.AspNetCore.Authorization;
using Wizards.Core.Model;
using Wizards.Services.PlayerService;

namespace Wizards.Services.AuthorizationElements;

public class ItemAuthorizationHandler : AuthorizationHandler<ItemOwnerRequirement, HeroItem>
{
    private readonly IPlayerService _playerService;

    public ItemAuthorizationHandler(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, ItemOwnerRequirement requirement, HeroItem resource)
    {
        var heroId = resource.HeroId;
        var activeHeroId = (await _playerService.Get(context.User)).ActiveHeroId;

        if (heroId == activeHeroId)
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }
    }
}

public class ItemOwnerRequirement : IAuthorizationRequirement { }