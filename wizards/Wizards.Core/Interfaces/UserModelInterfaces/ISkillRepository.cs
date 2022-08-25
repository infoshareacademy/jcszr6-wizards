using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizards.Core.Model.UserModels;

namespace Wizards.Core.Interfaces
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetAll();
        Task<Skill?> Get(int id);
        Task Add(Skill skill);
        Task Update(Skill skill);
        Task Remove(Skill skill);
    }
}
