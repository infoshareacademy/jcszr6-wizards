using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wizards.Core.Interfaces.WorldModelInterfaces;
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

        indexEnemies.ForEach(e =>
        {
            e.CanPlayerConquer = e.Tier <= hero.GetAverageItemTier();
            e.CanClaimReward = hero.Attributes.DailyRewardEnergy > 0;
        });

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
}