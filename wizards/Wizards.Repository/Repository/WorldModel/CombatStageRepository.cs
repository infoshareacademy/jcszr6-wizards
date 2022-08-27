using Microsoft.EntityFrameworkCore;
using Wizards.Core.Interfaces;
using Wizards.Core.Model.WorldModels;

namespace Wizards.Repository.Repository.WorldModel
{
    public class CombatStageRepository : ICombatStageRepository
    {
        private readonly WizardsContext _wizardsContext;
        public CombatStageRepository(WizardsContext wizardsContext)
        {
            _wizardsContext = wizardsContext;
        }

        public async Task AddAsync(CombatStage combatStage)
        {
            await _wizardsContext.CombatStages.AddAsync(combatStage);
            await _wizardsContext.SaveChangesAsync();
        }

        public async Task<CombatStage?> GetAsync(int id)
        {
            return await _wizardsContext.CombatStages
            .SingleOrDefaultAsync(cs => cs.Id == id);
        }

        public async Task<List<CombatStage>> GetAllAsync()
        {
            return await _wizardsContext.CombatStages.ToListAsync();
        }

        public async Task RemoveAsync(CombatStage combatStage)
        {
            _wizardsContext.CombatStages.Remove(combatStage);
            await _wizardsContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(CombatStage combatStage)
        {
            _wizardsContext.CombatStages.Update(combatStage);
            await _wizardsContext.SaveChangesAsync();
        }
    }
}
