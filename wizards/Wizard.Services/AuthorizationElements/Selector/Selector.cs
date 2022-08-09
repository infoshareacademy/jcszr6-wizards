using System.Security.Claims;
using Wizards.Core.Interfaces;
using Wizards.Core.Model;
using Wizards.Core.Model.ManyToManyTables;
using Wizards.Services.Helpers;

namespace Wizards.Services.Selector;

public class Selector : ISelector
{
    private readonly IHeroRepository _heroRepository;
    private readonly IPlayerRepository _playerRepository;

    public Selector(IPlayerRepository playerRepository, IHeroRepository heroRepository)
    {
        _playerRepository = playerRepository;
        _heroRepository = heroRepository;
        // TODO: Add injection of IHeroItemRepository
    }
    public async Task<Player> GetPlayerAsync(ClaimsPrincipal user)
    {
        var result = await _playerRepository.Get(user.GetId());

        if (result == null)
        {
            throw new NullReferenceException();
        }

        return result;
    }

    public async Task<Hero> GetHeroAsync(int id)
    {
        var result = await _heroRepository.Get(id);

        if (result == null)
        {
            throw new NullReferenceException();
        }

        return result;
    }

    public async Task<HeroItem> GetHeroItemAsync(int id)
    {
        //TODO: implement this method after creating HeroItemRepository;
        throw new NotImplementedException();
    }

    public async Task SelectHero(Player player, int heroId)
    {
        if (player.Heroes.Any(h => h.Id == heroId))
        {
            await _playerRepository.SetActiveHero(player, heroId);
        }
    }

    public async Task SelectItem(Player player, int itemId)
    {
        if (player.Heroes.SelectMany(h => h.Inventory).Any(i => i.ItemId == itemId))
        {
            await _playerRepository.SetActiveItem(player, itemId);
        }
    }
}