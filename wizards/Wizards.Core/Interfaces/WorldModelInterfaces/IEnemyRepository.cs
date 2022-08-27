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
        Task<List<Enemy>> GetAllAsync();
        Task<Enemy?> GetAsync(int id);
        Task AddAsync(Enemy enemy);
        Task UpdateAsync(Enemy enemy);
        Task RemoveAsync(Enemy enemy);
    }
}
