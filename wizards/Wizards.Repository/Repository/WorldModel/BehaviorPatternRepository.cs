using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizards.Core.Interfaces;
using Wizards.Core.Interfaces.WorldModelInterfaces;
using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Properties;

namespace Wizards.Repository.Repository.WorldModel
{
    public class BehaviorPatternRepository : IBehaviorPatternRepository
    {
        private readonly WizardsContext _wizardsContext;

        public BehaviorPatternRepository(WizardsContext wizardsContext)
        {
            _wizardsContext = wizardsContext;
        }

        public async Task AddAsync(Enemy enemy, BehaviorPattern behaviorPattern)
        {
            await _wizardsContext.BehaviorPatterns.AddAsync(behaviorPattern);
            await _wizardsContext.SaveChangesAsync();
        }

        public async Task<BehaviorPattern?> GetAsync(int id)
        {
            return await _wizardsContext.BehaviorPatterns
            .SingleOrDefaultAsync(bp => bp.Id == id);
        }

        public async Task<List<BehaviorPattern>> GetAllAsync()
        {
            return await _wizardsContext.BehaviorPatterns.ToListAsync();
        }

        public async Task RemoveAsync(BehaviorPattern behaviorPattern)
        {
            _wizardsContext.BehaviorPatterns.Remove(behaviorPattern);
            await _wizardsContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(BehaviorPattern behaviorPattern)
        {
            _wizardsContext.BehaviorPatterns.Update(behaviorPattern);
            await _wizardsContext.SaveChangesAsync();
        }
    }
}
