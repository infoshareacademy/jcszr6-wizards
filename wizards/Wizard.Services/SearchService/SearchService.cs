using Wizards.Core.Interfaces;
using Wizards.Core.Model;

namespace Wizards.Services.SearchService;

public class SearchService : ISearchService
{

    private readonly IPlayerRepository _playerRepository;



    public SearchService(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public Task<List<Player>> GetAll()
    {
        return _playerRepository.GetAll();

    }


    public async Task<List<Player>> ByUsername(string username)
    {
        return await _playerRepository.GetByUserName(username);
    }



    public async Task<List<Player>> ByRankPoints(int fromRankPoints, int toRankPoints)
    {
        return await _playerRepository.GetByRankPointsRange(fromRankPoints, toRankPoints);
    }



    public async Task<List<Player>> ByEmail(string email)
    {
        return await _playerRepository.GetByEmailAddress(email);
    }




}