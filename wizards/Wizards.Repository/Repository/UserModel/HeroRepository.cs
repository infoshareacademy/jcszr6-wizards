using Microsoft.EntityFrameworkCore;
using Wizards.Core.Interfaces;
using Wizards.Core.Interfaces.UserModelInterfaces;
using Wizards.Core.Model;
using Wizards.Core.Model.UserModels;

namespace Wizards.Repository.Repository.UserModel;

public class HeroRepository : IHeroRepository
{
    private readonly WizardsContext _wizardsContext;

    public HeroRepository(WizardsContext wizardsContext)
    {
        _wizardsContext = wizardsContext;
    }

    public async Task<List<Hero>> GetAll()
    {
        return await _wizardsContext.Heroes
            .Include(h => h.Skills)
            .Include(h => h.Statistics)
            .Include(h => h.Attributes)
            .Include(h => h.Inventory)
                .ThenInclude(hi =>hi.Item)
                    .ThenInclude(i =>i.Attributes)
            .ToListAsync();
    }

    public async Task<Hero?> Get(int id)
    {
        return await _wizardsContext.Heroes
            .Include(h => h.Attributes)
            .Include(h => h.Statistics)
            .Include(h => h.Inventory)
                .ThenInclude(hi => hi.Item)
                    .ThenInclude(i => i.Attributes)
            .Include(h => h.Skills)
                .ThenInclude(hs => hs.Skill)
            .SingleOrDefaultAsync(h => h.Id == id);
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
        _wizardsContext.HeroAttributes.Remove(hero.Attributes);
        _wizardsContext.Statistics.Remove(hero.Statistics);
        await _wizardsContext.SaveChangesAsync();
    }

    public Task<List<string>> GetAllNickNames()
    {
        return _wizardsContext.Heroes.Select(h => h.NickName).ToListAsync();
    }

    public async Task<bool> Exist(int id, string nickName)
    {
        return await _wizardsContext.Heroes.AnyAsync(h => h.Id == id && h.NickName == nickName);
    }
}