using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wizards.Core.Interfaces.LoggerInterface;
using Wizards.Core.Interfaces.WorldModelInterfaces;
using Wizards.GamePlay.StageService;
using Wizards.Services.Extensions;
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
        if (await _stageRepository.HasPlayerMatchOpened(User.GetId()))
        {
            var combatStage = await _stageRepository.GetAsync(User.GetId());

            var battleStage = _mapper.Map<CombatStageModelView>(combatStage);
            combatStage.LastRoundResult = null;

            return View("CombatStage", battleStage);
        }

        return RedirectToAction("Index", "Exploration");
    }

    public async Task<IActionResult> CreateNewMatch(int enemyId)
    {
        if (!await _stageRepository.HasPlayerMatchOpened(User.GetId()))
        {
            await _stageService.CreateNewMatchAsync(User.GetId(), enemyId);
            var stage = await _stageRepository.GetAsync(User.GetId());
            await _logger.SendLogAsync<CombatController>(LogLevel.Information, $"{stage.CombatHero.NickName} created new match with {stage.CombatEnemy.Name}", stage);
        }
        
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> CommitRound(CombatStageModelView battleStage)
    {
        if (await _stageRepository.HasPlayerMatchOpened(User.GetId()))
        {

            var nextHeroSkillId = battleStage.HeroSelectedSkillId;

            await _stageService.CommitRoundAsync(User.GetId(), nextHeroSkillId);

            return RedirectToAction("Index");
        }

        return RedirectToAction("Index", "Exploration");
    }

    [HttpGet]
    public async Task<IActionResult> CommitRoundPartially(int id)
    {
        await _stageService.CommitRoundAsync(User.GetId(), id);

        return RedirectToAction("IndexPartial");
    }

    public async Task<IActionResult> IndexPartial()
    {
        var combatStage = await _stageRepository.GetAsync(User.GetId());

        var battleStage = _mapper.Map<CombatStageModelView>(combatStage);
        combatStage.LastRoundResult = null;

        return PartialView("_CombatContent", battleStage);
    }

    public async Task<IActionResult> FinishMatch()
    {
        if (await _stageRepository.HasPlayerMatchOpened(User.GetId()))
        {
            var stage = await _stageRepository.GetAsync(User.GetId());
            await _stageService.FinishMatchAsync(User.GetId());
            await _logger.SendLogAsync<CombatController>(LogLevel.Information, $"{stage.CombatHero.NickName} finished match in state {stage.Status}", stage);
        }

        return RedirectToAction("Index", "Exploration");
    }

    public async Task<IActionResult> AbortMatch()
    {
        if (await _stageRepository.HasPlayerMatchOpened(User.GetId()))
        {
            var stage = await _stageRepository.GetAsync(User.GetId());
            await _stageService.AbortMatchAsync(User.GetId());
            await _logger.SendLogAsync<CombatController>(LogLevel.Information, $"{stage.CombatHero.NickName} aborted match in during combat state {stage.Status}", stage);

            return RedirectToAction("Index");
        }

        return RedirectToAction("Index", "Exploration");
    }
}