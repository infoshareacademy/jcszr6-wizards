using Wizards.Core.Model.WorldModels;

namespace Wizards.GamePlay.EnemiesAI
{
    public interface IEnemyAI
    {
        public int GetEnemySelectedSkillId(CombatStage stage);
    }
}
