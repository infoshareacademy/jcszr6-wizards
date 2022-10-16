using Wizards.Core.Model.WorldModels;

namespace Wizards.Core.Interfaces.WorldModelInterfaces;

public interface ICombatStageInstancesRepository
{
    Task<CombatStage> GetAsync(int playerId);
    Task AddAsync(CombatStage stage, int playerId);
    Task RemoveAsync(int playerId);
    Task<bool> HasPlayerMatchOpened(int playerId);
}