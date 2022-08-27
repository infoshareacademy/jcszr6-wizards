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
        Task<List<HeroSkill>> GetAllAsync();
        Task<HeroSkill?> GetAsync(int id);
        Task AddAsync(HeroSkill heroSkill);
        Task UpdateAsync(HeroSkill heroSkill);
        Task RemoveAsync(HeroSkill heroSkill);
    }
}
