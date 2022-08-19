using Microsoft.AspNetCore.Identity;
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
        var roles = _rolesFactory.GetRolesAsync();
        var adminUsers = _usersFactory.GetAdminUsersAsync();
        var moderatorUsers = _usersFactory.GetModeratorUsersAsync();
        var randomUsers = _usersFactory.GetRandomUsersForTestsAsync();
        var heroes = _heroesFactory.GetHeroes();
        var heroesNames = await _heroRepository.GetAllNickNames();


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
        
        foreach (var randomUser in randomUsers)
        {
            if (await _userManager.FindByNameAsync(randomUser.Key.UserName) == null)
            {
                var user = randomUser.Key;
                var password = randomUser.Value;

                await _userManager.CreateAsync(user, password);
                await _userManager.AddToRoleAsync(user, UserRoles.RegularUser.ToString());
            }
        }

        foreach (var hero in heroes)
        {
            if (!heroesNames.Contains(hero.NickName))
            {
                await _context.Heroes.AddAsync(hero);
                await _context.SaveChangesAsync();
            }
        }
    }
}