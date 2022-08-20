using Microsoft.AspNetCore.Authorization;
using Wizards.Core.Model;
using Wizards.Services.Helpers;

namespace Wizards.Services.AuthorizationElements;

public class HeroAuthorizationHandler : AuthorizationHandler<HeroOwnerRequirement, Hero>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HeroOwnerRequirement requirement, Hero resource)
    {
        var playerId = context.User.GetId();
        
        if (playerId == resource.PlayerId)
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }

        return Task.CompletedTask;
    }
}

public class HeroOwnerRequirement : IAuthorizationRequirement { }