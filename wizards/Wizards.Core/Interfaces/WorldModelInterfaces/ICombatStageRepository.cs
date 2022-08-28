using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizards.Core.Model.WorldModels;

namespace Wizards.Core.Interfaces
{
    public interface ICombatStageRepository
    {
        Task<List<CombatStage>> GetAllAsync();
        Task<CombatStage?> GetAsync(int id);
        Task AddAsync(CombatStage combatStage);
        Task UpdateAsync(CombatStage combatStage);
        Task RemoveAsync(CombatStage combatStage);
    }
}
