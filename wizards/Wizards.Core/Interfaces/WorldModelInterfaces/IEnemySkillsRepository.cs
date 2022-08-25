using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Properties;

namespace Wizards.Core.Interfaces
{
    public interface IEnemySkillsRepository
    {
        Task<List<EnemySkill>> GetAll();
        Task<EnemySkill?> Get(int id);
        Task Add(Enemy enemy,EnemySkill enemySkill);
        Task Update(EnemySkill enemySkill);
        Task Remove(EnemySkill enemySkill);
    }
}

