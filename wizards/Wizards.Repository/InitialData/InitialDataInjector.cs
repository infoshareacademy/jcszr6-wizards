using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Wizards.Core.Interfaces;
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
    private readonly IInitialDataHeroesFactory _heroesFactory;
    private readonly IHeroRepository _heroRepository;
    private readonly WizardsContext _context;

    public InitialDataInjector(
        IInitialDataRolesFactory rolesFactory, IInitialDataUsersFactory usersFactory, 
        RoleManager<IdentityRole<int>> roleManager, UserManager<Player> userManager,
        IInitialDataHeroesFactory heroesFactory, IHeroRepository heroRepository, WizardsContext context) 
    {
        _rolesFactory = rolesFactory;
        _usersFactory = usersFactory;
        _roleManager = roleManager;
        _userManager = userManager;
        _heroesFactory = heroesFactory;
        _heroRepository = heroRepository;
        _context = context;
    }
    public async Task InjectDevelopmentDataAsync()
    {
        if (_roleManager.Roles.Count() != 3)
        {
            var roles = _rolesFactory.GetRolesAsync();
            await AddRoles(roles);
        }
        
        var adminUsers = _usersFactory.GetAdminUsersAsync();
        await AddUsers(adminUsers, UserRoles.Admin);

        var moderatorUsers = _usersFactory.GetModeratorUsersAsync();
        await AddUsers(moderatorUsers, UserRoles.Moderator);

        if (_context.Players.Count() < 105)
        {
            var randomUsers = _usersFactory.GetRandomUsersForTestsAsync();
            await AddUsers(randomUsers, UserRoles.RegularUser);
        }

        if (_context.Heroes.Count() < 240)
        {
            var adminsHeroes = _heroesFactory.GetAdminModeratorsHeroesWithEquipment();
            await AddHeroes(adminsHeroes);

            var heroes = _heroesFactory.GetRandomTestHeroesWithEquipment();
            await AddHeroes(heroes);
        }
    }

    private async Task AddRoles(List<IdentityRole<int>> roles)
    {
        foreach (var identityRole in roles)
        {
            await _roleManager.CreateAsync(identityRole);
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

    private async Task AddHeroes(List<Hero> heroes)
    {
        var existingHeroesNames = await _heroRepository.GetAllNickNames();

        foreach (var hero in heroes)
        {
            if (!existingHeroesNames.Contains(hero.NickName))
            {
                await _context.Heroes.AddAsync(hero);
            }
        }

        await _context.SaveChangesAsync();
    }
}