using Microsoft.EntityFrameworkCore;
using Wizards.Core.Interfaces.UserModelInterfaces;
using Wizards.Core.Model.UserModels;

namespace Wizards.Repository.Repository.UserModel;

public class SkillRepository : ISkillRepository
{
    private readonly WizardsContext _wizardsContext;

    public SkillRepository(WizardsContext wizardsContext)
    {
        _wizardsContext = wizardsContext;
    }

    public async Task AddAsync(Skill skill)
    {
        await _wizardsContext.Skills.AddAsync(skill);
        await _wizardsContext.SaveChangesAsync();
    }

    public async Task<Skill?> GetAsync(int id)
    {
        return await _wizardsContext.Skills
            .SingleOrDefaultAsync(s => s.Id == id);
    }

    public async Task<List<Skill>> GetAllAsync()
    {
        return await _wizardsContext.Skills.ToListAsync();
    }

    public async Task RemoveAsync(Skill skill)
    {
        _wizardsContext.Skills.Remove(skill);
        await _wizardsContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Skill skill)
    {
        _wizardsContext.Skills.Update(skill);
        await _wizardsContext.SaveChangesAsync();
    }
}