using Wizards.Core.Interfaces;
using Wizards.Core.Model.WorldModels;
using Wizards.Repository.WorldInstancesRepository;

namespace Wizards.Repository.Repository.WorldModel;

public class CombatStageInstancesRepository : ICombatStageInstancesRepository
{
    public async Task<CombatStage> GetAsync(int playerId)
    {
        return await CombatStageInstancesContainer.Get(playerId);
    }

    public async Task AddAsync(CombatStage stage, int playerId)
    {
        await CombatStageInstancesContainer.Add(playerId, stage);
    }

    public async Task RemoveAsync(int playerId)
    {
        await CombatStageInstancesContainer.Remove(playerId);
    }

    public async Task<int> GetCountAsync()
    {
        return await CombatStageInstancesContainer.GetCurrentInstancesCount();
    }
}