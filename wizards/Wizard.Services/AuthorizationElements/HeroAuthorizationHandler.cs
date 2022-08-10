﻿using Microsoft.AspNetCore.Authorization;
using Wizards.Core.Model;
using Wizards.Services.Helpers;
using Wizards.Services.PlayerService;

namespace Wizards.Services.AuthorizationElements;

public class HeroAuthorizationHandler : AuthorizationHandler<HeroOwnerRequirement, Hero>
{
    private readonly IPlayerService _playerService;

    public HeroAuthorizationHandler(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HeroOwnerRequirement requirement, Hero resource)
    {
        var playerId = context.User.GetId();
        
        if (playerId == resource.PlayerId)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}

public class HeroOwnerRequirement : IAuthorizationRequirement { }