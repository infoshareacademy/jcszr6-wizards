using Wizards.Core.Model;
using Wizards.Core.Model.UserModels;

namespace Wizards.Services.SearchService;

public interface ISearchService
{
    Task<List<PlayerForRankingDto>> GetAll();

    Task<List<PlayerForRankingDto>> ByUserName(string userName);

    Task<List<PlayerForRankingDto>> ByHeroName(string heroName);

    Task<List<PlayerForRankingDto>> ByRankPoints(int fromRankPoints, int toRankPoints);

    Task<List<PlayerForRankingDto>> ByEmail(string email);

    Task<List<PlayerForRankingDto>> FilteringForApi(string? userName, string? heroName, int? fromRankingPoints, int? toRankingPoints);
}