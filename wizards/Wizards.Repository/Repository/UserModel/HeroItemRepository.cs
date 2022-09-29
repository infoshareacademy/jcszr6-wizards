using Microsoft.EntityFrameworkCore;
using Wizards.Core.Interfaces;
using Wizards.Core.Interfaces.UserModelInterfaces;
using Wizards.Core.Model;
using Wizards.Core.Model.UserModels;

namespace Wizards.Repository.Repository.UserModel;

public class HeroItemRepository : IHeroItemRepository
{
    private readonly WizardsContext _wizardsContext;

    public HeroItemRepository(WizardsContext wizardsContext)
    {
        _wizardsContext = wizardsContext;
    }
    public Task<HeroItem?> GetAsync(int id)
    {
        return _wizardsContext.HeroItems
            .Include(hi => hi.Item)
            .ThenInclude(i => i.Attributes)
            .SingleOrDefaultAsync(hi => hi.Id == id);
    }

    public async Task<List<HeroItem>> GetAllAsync()
    {
        return await _wizardsContext.HeroItems.ToListAsync();
    }

    public async Task AddAsync(HeroItem heroItem)
    {
        await _wizardsContext.HeroItems.AddAsync(heroItem);
        await _wizardsContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(HeroItem heroItem)
    {
        _wizardsContext.HeroItems.Update(heroItem);
        await _wizardsContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(HeroItem heroItem)
    {
        _wizardsContext.HeroItems.Remove(heroItem);
        await _wizardsContext.SaveChangesAsync();
    }
}