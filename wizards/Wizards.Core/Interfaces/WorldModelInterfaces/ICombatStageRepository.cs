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
        Task<List<CombatStage>> GetAll();
        Task<CombatStage?> Get(int id);
        Task Add(CombatStage combatStage);
        Task Update(CombatStage combatStage);
        Task Remove(CombatStage combatStage);
    }
}
