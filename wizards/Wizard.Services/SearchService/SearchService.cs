using Wizards.Core.Interfaces;
using Wizards.Core.Interfaces.UserModelInterfaces;
using Wizards.Core.Model;
using Wizards.Core.Model.UserModels;

namespace Wizards.Services.SearchService;

public class SearchService : ISearchService
{
    private readonly IPlayerRepository _playerRepository;

    private readonly IHeroRepository _heroRepository;

    public SearchService(IPlayerRepository playerRepository, IHeroRepository heroRepository)
    {
        _playerRepository = playerRepository;
        _heroRepository = heroRepository;
    }

    public async Task<List<PlayerForRankingDto>> GetAll()
    {
        var players = await _playerRepository.GetAll();
        var orderPlayers = players.OrderByDescending(n => n.Heroes.Sum(h => h.Statistics.RankPoints)).ToList();
        var result = new List<PlayerForRankingDto>();
        int counter = 1;
        foreach (var player in orderPlayers)
        {
            var playerDto = new PlayerForRankingDto();
            playerDto.Player = player;
            playerDto.RankingNumber = counter;
            result.Add(playerDto);
            counter++;
        }
        return result;
    }

    public async Task<List<PlayerForRankingDto>> ByUserName(string userName)
    {
        var orderPlayers = await GetAll();
        var result = orderPlayers
            .Where(p => p.Player.UserName
                .ToLower()
                .Contains(userName.ToLower())).ToList();

        return result;
    }

    public async Task<List<PlayerForRankingDto>> ByHeroName(string heroName)
    {
        var orderPlayers = await GetAll();
        var result = orderPlayers
            .Where(p => p.Player.Heroes
                .Any(h => h.NickName
                    .ToLower()
                    .Contains(heroName.ToLower()))).ToList();

        return result;
    }

    public async Task<List<PlayerForRankingDto>> ByRankPoints(int fromRankPoints, int toRankPoints)
    {
        var orderPlayers = await GetAll();
        var result = orderPlayers
            .Where(p =>
                p.Player.Heroes.Select(h => h.Statistics.RankPoints)
                    .Sum() >= fromRankPoints &&
                p.Player.Heroes.Select(h => h.Statistics.RankPoints)
                    .Sum() <= toRankPoints).ToList();

        return result;
    }

    public async Task<List<PlayerForRankingDto>> ByEmail(string email)
    {
        var orderPlayers = await GetAll();
        var result = orderPlayers
            .Where(p => p.Player.Email
                .ToLower()
                .Contains(email.ToLower())).ToList();

        return result;
    }

    public async Task<List<PlayerForRankingDto>> FilteringForApi(string? userName, string? heroName, int? fromRankingPoints, int? toRankingPoints)
    {
        var allPlayers = await GetAll();
        var filtering = allPlayers;

        if (!String.IsNullOrEmpty(userName))
        {
            filtering = filtering.Where(u => u.Player.UserName.Contains(userName, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}