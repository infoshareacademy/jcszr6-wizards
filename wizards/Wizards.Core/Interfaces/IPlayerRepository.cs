using Wizards.Core.Model;

namespace Wizards.Core.Interfaces;

public interface IPlayerRepository
{
    Task<List<Player>> GetAll();
    Task<Player?> Get(int id);
    Task Add(Player player);
    Task Remove(Player player);
    Task Update(Player player);

    Task<List<string>> GetAllUserNames();
    Task<List<string>> GetAllEmails();
    Task<bool> Exist(int id);
    Task<bool> Exist(int id, string email);

    Task<List<Player>> GetByUserName(string userName);
    Task<List<Player>> GetByEmailAddress(string addressEmail);
    Task<List<Player>> GetByYearRange(int startYear, int endYear);
    Task<List<Player>> GetByRankPointsRange(int lowRankPoints, int highRankPoints);

    Task SetActiveHero(Player player, int heroId);
    Task SetActiveItem(Player player, int itemId);
}