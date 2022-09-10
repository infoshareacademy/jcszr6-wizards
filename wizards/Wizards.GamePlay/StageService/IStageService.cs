using Wizards.Core.Model.WorldModels;
using Wizards.GamePlay.CombatService;

namespace Wizards.GamePlay.StageService
{
    public interface IStageService
    {
        public Task CreateNewMatchAsync(int playerId, int enemyId, bool isTraining);
        public Task CommitRoundAsync(int playerId, int selectedSkillId);
        public Task FinishMatchAsync(int playerId);
    }
}
