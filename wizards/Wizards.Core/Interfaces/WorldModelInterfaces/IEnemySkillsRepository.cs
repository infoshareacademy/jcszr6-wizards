using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Properties;

namespace Wizards.Core.Interfaces.WorldModelInterfaces;

public interface IEnemySkillsRepository
{
    Task<List<EnemySkill>> GetAllAsync();
    Task<EnemySkill?> GetAsync(int id);
    Task AddAsync(Enemy enemy, EnemySkill enemySkill);
    Task UpdateAsync(EnemySkill enemySkill);
    Task RemoveAsync(EnemySkill enemySkill);
}