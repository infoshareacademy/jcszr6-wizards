using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Wizards.Core.Interfaces.WorldModelInterfaces;
using Wizards.Core.Model.WorldModels.Enums;
using Wizards.Core.ModelExtensions;
using Wizards.Services.HeroService;
using WizardsWeb.ModelViews.ExplorationModelViews;
using WizardsWeb.ModelViews.HeroModelViews.Properties;

namespace WizardsWeb.Controllers;

[Authorize]
public class ExplorationController : Controller
{
    private readonly IEnemyRepository _enemyRepository;
    private readonly IHeroService _heroService;
    private readonly IMapper _mapper;

    public ExplorationController(IEnemyRepository enemyRepository, IHeroService heroService, IMapper mapper)
    {
        _enemyRepository = enemyRepository;
        _heroService = heroService;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> TitanRaids()
    {
        var enemies = await _enemyRepository.GetAllAsync();
        var hero = await _heroService.Get(User);

        var indexEnemies = _mapper.Map<List<EnemyIndexModelView>>(enemies);

        //var indexEnemies = GetDummyData();

        indexEnemies.ForEach(e => e.CanPlayerConquer = e.Tier <= hero.GetAverageItemTier());

        var groupedEnemies = indexEnemies.GroupBy(e => e.Tier);

        var explorationCenter = new ExplorationCenterModelView();

        explorationCenter.TierOneEnemies = groupedEnemies
            .Where(ge => ge.Key == 1)
            .SelectMany(ge => ge)
            .ToList();

        explorationCenter.TierTwoEnemies = groupedEnemies
            .Where(ge => ge.Key == 2)
            .SelectMany(ge => ge)
            .ToList();

        explorationCenter.TierThreeEnemies = groupedEnemies
            .Where(ge => ge.Key == 3)
            .SelectMany(ge => ge)
            .ToList();

        explorationCenter.TierFourEnemies = groupedEnemies
            .Where(ge => ge.Key == 4)
            .SelectMany(ge => ge)
            .ToList();

        explorationCenter.TierFiveEnemies = groupedEnemies
            .Where(ge => ge.Key == 5)
            .SelectMany(ge => ge)
            .ToList();

        explorationCenter.HeroSummary = _mapper.Map<HeroSummaryModelView>(hero);

        return View(explorationCenter);
    }

    private List<EnemyIndexModelView> GetDummyData()
    {
        var result = new List<EnemyIndexModelView>();

        var counter = 0;

        for (int i = 1; i <= 5; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                counter++;
                
                var enemy = new EnemyIndexModelView();
                
                enemy.Id = counter;
                enemy.Name = $"Enemy-T{i}-NR{j}";
                enemy.Description =
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
                    "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in " +
                    "reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in " +
                    "culpa qui officia deserunt mollit anim id est laborum. ";
                enemy.AvatarImageNumber = 1;
                enemy.EnemyStageName = $"Lair of {enemy.Name}";
                enemy.GoldReward = 500 * i + j;
                enemy.RankPointsReward = 20 * i;
                enemy.Tier = i;
                enemy.Type = EnemyType.Boss;

                result.Add(enemy);
            }
        }
        
        return result;
    }
}