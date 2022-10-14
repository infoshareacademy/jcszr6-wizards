using Wizards.Core.Model.WorldModels;

namespace Wizards.GamePlay.Factories;

public interface ICombatStageFactory
{
    public Task<CombatStage> CreateCombatStageAsync(int heroId, int enemyId);
}