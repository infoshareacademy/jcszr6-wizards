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
        Task<List<BehaviorPattern>> GetAll();
        Task<BehaviorPattern?> Get(int id);
        Task Add(Enemy enemy, BehaviorPattern behaviorPattern);
        Task Update(BehaviorPattern behaviorPattern);
        Task Remove(BehaviorPattern behaviorPattern);
    }
}
