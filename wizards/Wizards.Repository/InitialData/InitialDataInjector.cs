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
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<Player> _userManager;
    private readonly IInitialDataItemsFactory _itemsFactory;

    public InitialDataInjector(
        IInitialDataRolesFactory rolesFactory, IInitialDataUsersFactory usersFactory, 
        RoleManager<IdentityRole> roleManager, UserManager<Player> userManager,
        IInitialDataItemsFactory itemsFactory) 
    {
        _rolesFactory = rolesFactory;
        _usersFactory = usersFactory;
        _roleManager = roleManager;
        _userManager = userManager;
        _itemsFactory = itemsFactory;
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
            if (await _userManager.FindByNameAsync(adminUser.Key.UserName) != null)
            {
                var user = adminUser.Key;
                var password = adminUser.Value;

                await _userManager.CreateAsync(user, password);
                await _userManager.AddToRoleAsync(user, UserRoles.Admin.ToString());
            }
        }

        foreach (var moderatorUser in moderatorUsers)
        {
            if (await _userManager.FindByNameAsync(moderatorUser.Key.UserName) != null)
            {
                var user = moderatorUser.Key;
                var password = moderatorUser.Value;

                await _userManager.CreateAsync(user, password);
                await _userManager.AddToRoleAsync(user, UserRoles.Moderator.ToString());
            }
        }
    }

    public void InjectGameDataAsync(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemAttributes>().HasData(_itemsFactory.GetAttributes());
        modelBuilder.Entity<Item>().HasData(_itemsFactory.GetItems());

        
    }
}