using Microsoft.EntityFrameworkCore;
using Wizards.Core.Interfaces;
using Wizards.Core.Model;
using System.Linq;

namespace Wizards.Repository.Repository;

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
            .Where(p => p.UserName.Contains(userName, StringComparison.OrdinalIgnoreCase))
            .ToListAsync();
    }

    public async Task<List<Player>> GetByEmailAddress(string addressEmail)
    {
        return await _wizardsContext.Players
            .Where(p => p.Email.Contains(addressEmail, StringComparison.OrdinalIgnoreCase))
            .ToListAsync();
    }

    public async Task<List<Player>> GetByYearRange(int startYear, int endYear)
    {
        return await _wizardsContext.Players.Where(p =>
            p.DateOfBirth.Year >= startYear &&
            p.DateOfBirth.Year <= endYear).ToListAsync();
    }

    public async Task<List<Player>> GetByRankPointsRange(int lowRankPoints, int highRankPoints)
    {
        return await _wizardsContext.Players.Where(p =>
            p.Heroes.Select(h => h.Statistics.RankPoints).Sum() >= lowRankPoints &&
            p.Heroes.Select(h => h.Statistics.RankPoints).Sum() <= highRankPoints).ToListAsync();
    }
}