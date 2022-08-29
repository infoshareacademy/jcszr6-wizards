using Wizards.Core.Model.WorldModels;

namespace Wizards.GamePlay.StageService
{
    public interface IStageService
    {
        public Task CreateNewMatchAsync(CombatStage stage, int enemyId, int heroId);

        public Task CommitRoundAsync(CombatStage stage);  

        public Task FinishMatchAsync(CombatStage stage);
    }
}
