using System.Security.Claims;
using Wizards.Core.Model;
using Wizards.Core.Model.ManyToManyTables;

namespace Wizards.Services.PermissionService;

public interface IPermissionService
{
    PermissionResult HasPermission(ClaimsPrincipal user, Hero hero);
    PermissionResult HasPermission(ClaimsPrincipal user);
    PermissionResult HasPermission(ClaimsPrincipal user, HeroItem item);
}