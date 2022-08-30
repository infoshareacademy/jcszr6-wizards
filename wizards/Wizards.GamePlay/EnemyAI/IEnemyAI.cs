using Wizards.Core.Model.WorldModels;

namespace Wizards.GamePlay.EnemiesAI
{
    public interface IEnemyAI
    {
        public Task GetEnemySelectedSkillIdAsync(CombatStage stage);
    }
}
