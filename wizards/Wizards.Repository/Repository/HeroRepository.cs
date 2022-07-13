using Microsoft.EntityFrameworkCore;
using Wizards.Core.Interfaces;
using Wizards.Core.Model;

namespace Wizards.Repository.Repository;

public class HeroRepository : IHeroRepository
{
    private readonly WizardsContext _wizardsContext;

    public HeroRepository(WizardsContext wizardsContext)
    {
        _wizardsContext = wizardsContext;
    }

    public async Task<List<Hero>> GetAll()
    {
        return await _wizardsContext.Heroes.ToListAsync();
    }

    public async Task<Hero?> Get(int id)
    {
        return await _wizardsContext.Heroes.FindAsync(id);
    }

    public async Task Add(Player player, Hero hero)
    {
        player.Heroes.Add(hero);
        await _wizardsContext.SaveChangesAsync();
    }

    public async Task Update(Hero hero)
    {
        _wizardsContext.Heroes.Update(hero);
        await _wizardsContext.SaveChangesAsync();
    }

    public async Task Remove(Hero hero)
    {
        _wizardsContext.Heroes.Remove(hero);
        await _wizardsContext.SaveChangesAsync();
    }

    public Task<List<string>> GetAllNickNames()
    {
        return _wizardsContext.Heroes.Select(h => h.NickName).ToListAsync();
    }
}