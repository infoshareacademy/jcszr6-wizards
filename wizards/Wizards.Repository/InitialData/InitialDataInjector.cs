using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Wizards.Core.Model;
using Wizards.Core.Model.Enums;
using Wizards.Repository.InitialData.SeedFactories.Interfaces;

namespace Wizards.Repository.InitialData;

public class InitialDataInjector : IInitialDataInjector
{
    private readonly IInitialDataUsersFactory _usersFactory;
    private readonly IInitialDataRolesFactory _rolesFactory;
    private readonly RoleManager<IdentityRole<int>> _roleManager;
    private readonly UserManager<Player> _userManager;
    

    public InitialDataInjector(
        IInitialDataRolesFactory rolesFactory, IInitialDataUsersFactory usersFactory, 
        RoleManager<IdentityRole<int>> roleManager, UserManager<Player> userManager) 
    {
        _rolesFactory = rolesFactory;
        _usersFactory = usersFactory;
        _roleManager = roleManager;
        _userManager = userManager;
        
    }
    public async Task InjectRolesAndUsersAsync()
    {
        var roles = _rolesFactory.GetRolesAsync();
        var adminUsers = _usersFactory.GetAdminUsersAsync();
        var moderatorUsers = _usersFactory.GetModeratorUsersAsync();

        foreach (var identityRole in roles)
        {
            await _roleManager.CreateAsync(identityRole);
        }

        foreach (var adminUser in adminUsers)
        {
            if (await _userManager.FindByNameAsync(adminUser.Key.UserName) == null)
            {
                var user = adminUser.Key;
                var password = adminUser.Value;
                var role = UserRoles.Admin.ToString();

                await _userManager.CreateAsync(user, password);
                await _userManager.AddToRoleAsync(user, role);
            }
        }

        foreach (var moderatorUser in moderatorUsers)
        {
            if (await _userManager.FindByNameAsync(moderatorUser.Key.UserName) == null)
            {
                var user = moderatorUser.Key;
                var password = moderatorUser.Value;

                await _userManager.CreateAsync(user, password);
                await _userManager.AddToRoleAsync(user, UserRoles.Moderator.ToString());
            }
        }
    }

}