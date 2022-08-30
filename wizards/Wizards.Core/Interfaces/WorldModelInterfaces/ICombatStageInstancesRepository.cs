using Wizards.Core.Model.WorldModels;

namespace Wizards.Core.Interfaces;

public interface ICombatStageInstancesRepository
{
    Task<CombatStage> GetAsync(int playerId);
    Task AddAsync(CombatStage stage, int playerId);
    Task RemoveAsync(int playerId);
    Task<int> GetCountAsync();
}