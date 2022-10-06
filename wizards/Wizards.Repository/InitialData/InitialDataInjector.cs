using Microsoft.AspNetCore.Identity;
using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.UserModels.Enums;
using Wizards.Repository.InitialData.SeedFactories.Interfaces;

namespace Wizards.Repository.InitialData;

public class InitialDataInjector : IInitialDataInjector
{
    private readonly IInitialDataRolesFactory _rolesFactory;
    private readonly IInitialDataUsersFactory _usersFactory;
    private readonly IInitialDataHeroesFactory _heroesFactory;
    private readonly RoleManager<IdentityRole<int>> _roleManager;
    private readonly UserManager<Player> _userManager;
    private readonly WizardsContext _context;

    public InitialDataInjector(
        IInitialDataRolesFactory rolesFactory, IInitialDataUsersFactory usersFactory,
        RoleManager<IdentityRole<int>> roleManager, UserManager<Player> userManager,
        IInitialDataHeroesFactory heroesFactory, WizardsContext context)
    {
        _rolesFactory = rolesFactory;
        _usersFactory = usersFactory;
        _roleManager = roleManager;
        _userManager = userManager;
        _heroesFactory = heroesFactory;
        _context = context;
    }
    public async Task InjectDevelopmentDataAsync()
    {
        await AddRoles();

        await InjectProductionDataAsync();

        if (_context.Players.Count() < 90)
        {
            var randomUsers = _usersFactory.GetRandomUsersForTests();
            var randomHeroes = _heroesFactory.GetRandomTestHeroesWithEquipment();
            await AddUsers(randomUsers, UserRoles.RegularUser, randomHeroes);
        }

        var testerPlayers = _usersFactory.GetTesterUsers();
        await AddUsers(testerPlayers, UserRoles.RegularUser);
    }

    public async Task InjectProductionDataAsync()
    {
        var adminUsers = _usersFactory.GetAdminUsers();
        var adminHeroes = _heroesFactory.GetAdminHeroesWithEquipment();
        await AddUsers(adminUsers, UserRoles.Admin, adminHeroes);

        var moderatorUsers = _usersFactory.GetModeratorUsers();
        var moderatorHeroes = _heroesFactory.GetModeratorHeroesWithEquipment();
        await AddUsers(moderatorUsers, UserRoles.Moderator, moderatorHeroes);
    }

    private async Task AddRoles()
    {
        var roles = _rolesFactory.GetRolesAsync();

        foreach (var identityRole in roles)
        {
            if (await _roleManager.FindByNameAsync(identityRole.Name) == null)
            {
                await _roleManager.CreateAsync(identityRole);
            }
        }
    }

    private async Task AddUsers(Dictionary<Player, string> usersData, UserRoles role)
    {
        foreach (var userData in usersData)
        {
            if (await _userManager.FindByNameAsync(userData.Key.UserName) == null)
            {
                var user = userData.Key;
                var password = userData.Value;

                await _userManager.CreateAsync(user, password);
                await _userManager.AddToRoleAsync(user, role.ToString());
            }
        }
    }

    private async Task AddUsers(Dictionary<Player, string> usersData, UserRoles role, Dictionary<Hero, string> heroes)
    {
        foreach (var userData in usersData)
        {
            if (await _userManager.FindByNameAsync(userData.Key.UserName) == null)
            {
                var user = userData.Key;
                var password = userData.Value;
                var heroesToAdd = heroes
                    .Where(h=>h.Value == user.UserName)
                    .Select(h => h.Key)
                    .ToList();
                user.Heroes=heroesToAdd;

                await _userManager.CreateAsync(user, password);
                await _userManager.AddToRoleAsync(user, role.ToString());
            }
        }
    }
}