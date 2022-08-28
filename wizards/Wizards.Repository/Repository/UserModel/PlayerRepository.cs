using Microsoft.EntityFrameworkCore;
using Wizards.Core.Interfaces;
using Wizards.Core.Model;
using Wizards.Core.Model.UserModels;

namespace Wizards.Repository.Repository.UserModel;

public class PlayerRepository : IPlayerRepository
{
    private readonly WizardsContext _wizardsContext;

    public PlayerRepository(WizardsContext wizardsContext)
    {
        _wizardsContext = wizardsContext;
    }

    public async Task<List<Player>> GetAll()
    {
        return await _wizardsContext.Players
            .Include(p => p.Heroes)
                .ThenInclude(x => x.Statistics)
            .Include(p => p.CombatStage)
            .ToListAsync();
    }

    public async Task<Player?> Get(int id)
    {
        return await _wizardsContext.Players
            .Include(p => p.Heroes)
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task Add(Player player)
    {
        await _wizardsContext.Players.AddAsync(player);
        await _wizardsContext.SaveChangesAsync();
    }

    public async Task Remove(Player player)
    {
        foreach (var hero in player.Heroes)
        {
            var statistics = await _wizardsContext.Statistics.SingleOrDefaultAsync(s => s.Id == hero.StatisticsId);

            if (statistics != null)
            {
                _wizardsContext.Statistics.Remove(statistics);
            }

            var attributes = await _wizardsContext.HeroAttributes.SingleOrDefaultAsync(ha => ha.Id == hero.AttributesId);

            if (attributes != null)
            {
                _wizardsContext.HeroAttributes.Remove(attributes);
            }
        }

        _wizardsContext.Players.Remove(player);

        await _wizardsContext.SaveChangesAsync();
    }

    public async Task Update(Player player)
    {
        _wizardsContext.Players.Update(player);
        await _wizardsContext.SaveChangesAsync();
    }

    public async Task<List<string>> GetAllUserNames()
    {
        return await _wizardsContext.Players.Select(p => p.UserName).ToListAsync();
    }

    public async Task<List<string>> GetAllEmails()
    {
        return await _wizardsContext.Players.Select(p => p.Email).ToListAsync();
    }

    public async Task<bool> Exist(int id)
    {
        return await _wizardsContext.Players.AnyAsync(p => p.Id == id);
    }

    public async Task<bool> Exist(int id, string email)
    {
        return await _wizardsContext.Players.AnyAsync(p => p.Id == id && p.Email == email);
    }

    public async Task<List<Player>> GetByUserName(string userName)
    {
        return await _wizardsContext.Players
            .Where(p => p.UserName.ToLower().Contains(userName.ToLower()))
            .Include(p => p.Heroes)
            .ThenInclude(x => x.Statistics)
            .ToListAsync();
    }

    public async Task<List<Player>> GetByEmailAddress(string addressEmail)
    {
        return await _wizardsContext.Players
            .Where(p => p.Email.ToLower().Contains(addressEmail.ToLower()))
            .Include(p => p.Heroes)
            .ThenInclude(x => x.Statistics)
            .ToListAsync();
    }

    public async Task<List<Player>> GetByRankPointsRange(int lowRankPoints, int highRankPoints)
    {
        return await _wizardsContext.Players.Where(p =>
            p.Heroes.Select(h => h.Statistics.RankPoints).Sum() >= lowRankPoints &&
            p.Heroes.Select(h => h.Statistics.RankPoints).Sum() <= highRankPoints)
            .Include(p => p.Heroes)
            .ThenInclude(x => x.Statistics)
            .ToListAsync();
    }

    public async Task SetActiveHero(Player player, int heroId)
    {
        player.ActiveHeroId = heroId;
        await _wizardsContext.SaveChangesAsync();
    }

    public async Task SetActiveItem(Player player, int itemId)
    {
        player.ActiveItemId = itemId;
        await _wizardsContext.SaveChangesAsync();
    }
}