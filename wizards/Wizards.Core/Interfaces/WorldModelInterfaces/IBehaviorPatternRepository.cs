using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Properties;

namespace Wizards.Core.Interfaces
{
    public interface IBehaviorPatternRepository
    {
        Task<List<BehaviorPattern>> GetAllAsync();
        Task<BehaviorPattern?> GetAsync(int id);
        Task AddAsync(Enemy enemy, BehaviorPattern behaviorPattern);
        Task UpdateAsync(BehaviorPattern behaviorPattern);
        Task RemoveAsync(BehaviorPattern behaviorPattern);
    }
}
