using System.Security.Claims;
using Wizards.Core.Model;
using Wizards.Core.Model.ManyToManyTables;

namespace Wizards.Services.PermissionService;

public interface IPermissionService
{
    PermissionResult HasPermission(ClaimsPrincipal user, Hero hero);
    bool IsLoggedIn(ClaimsPrincipal user);
    Task<PermissionResult> HasPermission(ClaimsPrincipal user, HeroItem item);
}