using Wizards.Core.Model.WorldModels;

namespace Wizards.GamePlay.StageService;

public class StageService : IStageService
{
    public Task CreateNewMatchAsync(CombatStage stage, int enemyId, int heroId)
    {
        throw new NotImplementedException();
    }

    public Task CommitRoundAsync(CombatStage stage)
    {
        throw new NotImplementedException();
    }

    public Task FinishMatchAsync(CombatStage stage)
    {
        throw new NotImplementedException();
    }
}