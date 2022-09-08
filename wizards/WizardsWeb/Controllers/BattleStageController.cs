using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wizards.Core.Interfaces.WorldModelInterfaces;
using Wizards.GamePlay.StageService;
using Wizards.Services.Extentions;
using WizardsWeb.ModelViews.CombatModelViews;

namespace WizardsWeb.Controllers
{
    public class BattleStageController : Controller
    {
        private readonly IStageService _stageService;
        private readonly ICombatStageInstancesRepository _stageRepository;
        private readonly IMapper _mapper;

        public BattleStageController(IStageService stageService, ICombatStageInstancesRepository stageRepository, IMapper mapper)
        {
            _stageService = stageService;
            _stageRepository = stageRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var combatStage = await _stageRepository.GetAsync(User.GetId());
            var battleStage = _mapper.Map<CombatStageModelView>(combatStage); 

            return View("BattleStage", battleStage);
        }

        public IActionResult CreateNewMatch(int enemyId)
        {
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CommitRound(CombatStageModelView battleStage)
        {

            return RedirectToAction("Index");
        }

        public IActionResult FinishMatch()
        {

            return RedirectToAction("Details", "Hero");
        }
    }
}
