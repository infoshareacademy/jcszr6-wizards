using Wizards.Core.Model.WorldModels;
using Wizards.GamePlay.CombatService;

namespace Wizards.GamePlay.StageService
{
    public interface IStageService
    {
        public Task<CombatStage> CreateNewMatchAsync(int playerId, int enemyId);

        public Task<RoundResult> CommitRoundAsync(CombatStage stage, int selectedSkillId);

        public Task FinishMatchAsync(CombatStage stage);
    }
}
