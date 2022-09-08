using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Properties;
using Wizards.GamePlay.CombatService;

namespace Wizards.GamePlay.StageService
{
    public interface IStageService
    {
        public Task<CombatStage> CreateNewMatchAsync(int playerId, int enemyId);
        public Task<RoundResult> CommitRoundAsync(int playerId, int selectedSkillId);
        public Task FinishMatchAsync(int playerId);
    }
}
