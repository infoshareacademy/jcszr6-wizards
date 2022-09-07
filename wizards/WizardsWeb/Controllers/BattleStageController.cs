using Microsoft.AspNetCore.Mvc;
using WizardsWeb.ModelViews.ExplorationModelViews;

namespace WizardsWeb.Controllers
{
    public class BattleStageController : Controller
    {
        public IActionResult Index()
        {
            BattleStageModelView battleStage = new BattleStageModelView();

            return View("BattleStage", battleStage);
        }

        public IActionResult CreateNewMatch(int enemyId)
        {
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CommitRound(BattleStageModelView battleStage)
        {

            return RedirectToAction("Index");
        }

        public IActionResult FinishMatch()
        {

            return RedirectToAction("Details", "Hero");
        }
    }
}
