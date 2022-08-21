using Wizards.Core.Model;

namespace Wizards.Services.SearchService;

public interface ISearchService
{

    Task<List<Player>> GetAll();
    Task<List<Player>> ByUsername(string username);

    Task<List<Player>> ByRankPoints(int fromRankPoints, int toRankPoints);
    Task<List<Player>> ByEmail(string email);

}