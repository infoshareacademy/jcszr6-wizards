using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wizards.Core.Interfaces.LoggerInterface;
using Wizards.Core.Interfaces.WorldModelInterfaces;
using Wizards.GamePlay.StageService;
using Wizards.Services.Extentions;
using WizardsWeb.ModelViews.CombatModelViews;

namespace WizardsWeb.Controllers;

[Authorize]
public class CombatController : Controller
{
    private readonly IStageService _stageService;
    private readonly ICombatStageInstancesRepository _stageRepository;
    private readonly IMapper _mapper;
    private readonly IWizardsLogger _logger;


    public CombatController(IStageService stageService, ICombatStageInstancesRepository stageRepository, IMapper mapper, IWizardsLogger logger)
    {
        _stageService = stageService;
        _stageRepository = stageRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var combatStage = await _stageRepository.GetAsync(User.GetId());

        var battleStage = _mapper.Map<CombatStageModelView>(combatStage);
        combatStage.LastRoundResult = null;

        return View("CombatStage", battleStage);
    }
    public async Task<IActionResult> CreateNewMatch(int enemyId)
    {
        await _stageService.CreateNewMatchAsync(User.GetId(), enemyId, false);
        var stage = await _stageRepository.GetAsync(User.GetId());
        await _logger.SendLogAsync<CombatController>(LogLevel.Information, $"{stage.CombatHero.NickName} created new match with {stage.CombatEnemy.Name}", stage);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> CommitRound(CombatStageModelView battleStage)
    {
        var nextHeroSkillId = battleStage.HeroSelectedSkillId;

        await _stageService.CommitRoundAsync(User.GetId(), nextHeroSkillId);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> FinishMatch()
    {
        var stage = await _stageRepository.GetAsync(User.GetId());
        await _stageService.FinishMatchAsync(User.GetId());
        await _logger.SendLogAsync<CombatController>(LogLevel.Information, $"{stage.CombatHero.NickName} finished match in state {stage.Status}", stage);
        return RedirectToAction("Index", "Exploration");
    }

    public async Task<IActionResult> AbortMatch()
    {
        var stage = await _stageRepository.GetAsync(User.GetId());
        await _logger.SendLogAsync<CombatController>(LogLevel.Information, $"{stage.CombatHero.NickName} aborted match in during combat state {stage.Status}", stage);
        await _stageService.AbortMatchAsync(User.GetId());
        return RedirectToAction("Index");
    }
}