using Wizards.Core.Model.WorldModels;

namespace Wizards.GamePlay.EnemyAI;
public interface IEnemyAI
{
    public Task SelectNextEnemyActionAsync(CombatStage stage);
}
