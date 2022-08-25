using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizards.Core.Model.WorldModels;

namespace Wizards.Core.Interfaces
{
    public interface IEnemyRepository
    {
        Task<List<Enemy>> GetAll();
        Task<Enemy?> Get(int id);
        Task Add(Enemy enemy);
        Task Update(Enemy enemy);
        Task Remove(Enemy enemy);
    }
}
