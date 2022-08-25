using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizards.Core.Model.UserModels;

namespace Wizards.Core.Interfaces
{
    public interface IHeroSkillsRepository
    {
        Task<List<HeroSkill>> GetAll();
        Task<HeroSkill?> Get(int id);
        Task Add(HeroSkill heroSkill);
        Task Update(HeroSkill heroSkill);
        Task Remove(HeroSkill heroSkill);
    }
}
