using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizards.Core.Interfaces;
using Wizards.Core.Interfaces.UserModelInterfaces;
using Wizards.Core.Model.UserModels;

namespace Wizards.Repository.Repository.UserModel
{

    public class HeroSkillsRepository : IHeroSkillsRepository
    {
        private readonly WizardsContext _wizardsContext;
        public HeroSkillsRepository(WizardsContext wizardsContext)
        {
            _wizardsContext = wizardsContext;
        }

        public async Task AddAsync(HeroSkill heroSkill)
        {
            await _wizardsContext.HeroSkills.AddAsync(heroSkill);
            await _wizardsContext.SaveChangesAsync();
        }

        public async Task<HeroSkill?> GetAsync(int id)
        {
            return await _wizardsContext.HeroSkills
            .Include(hs => hs.Skill)
            .SingleOrDefaultAsync(hs => hs.Id == id);
        }

        public async Task<List<HeroSkill>> GetAllAsync()
        {
            return await _wizardsContext.HeroSkills.ToListAsync();
        }

        public async Task RemoveAsync(HeroSkill heroSkill)
        {
            _wizardsContext.HeroSkills.Remove(heroSkill);
            await _wizardsContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(HeroSkill heroSkill)
        {
            _wizardsContext.HeroSkills.Update(heroSkill);
            await _wizardsContext.SaveChangesAsync();
        }
    }
}
