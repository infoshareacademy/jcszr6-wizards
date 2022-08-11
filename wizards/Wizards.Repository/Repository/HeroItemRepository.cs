using Wizards.Core.Interfaces;
using Wizards.Core.Model;
using Wizards.Core.Model.ManyToManyTables;

namespace Wizards.Repository.Repository;

public class HeroItemRepository : IHeroItemRepository
{
    private readonly WizardsContext _wizardsContext;

    public HeroItemRepository(WizardsContext wizardsContext)
    {
        _wizardsContext = wizardsContext;
    }
    public Task<HeroItem> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<HeroItem>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddItemToHeroAsync(Hero hero, HeroItem heroItem)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(HeroItem heroItem)
    {
        await _wizardsContext.HeroItems.AddAsync(heroItem);
        await _wizardsContext.SaveChangesAsync();
    }

    public Task Update(HeroItem heroItem)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}