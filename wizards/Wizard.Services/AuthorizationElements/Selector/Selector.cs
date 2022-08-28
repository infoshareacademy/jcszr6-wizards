using System.Security.Claims;
using Wizards.Core.Interfaces;
using Wizards.Core.Model;
using Wizards.Core.Model.UserModels;
using Wizards.Services.Extentions;

namespace Wizards.Services.AuthorizationElements.Selector;

public class Selector : ISelector
{
    private readonly IHeroRepository _heroRepository;
    private readonly IHeroItemRepository _heroItemRepository;
    private readonly IPlayerRepository _playerRepository;

    public Selector(IPlayerRepository playerRepository, IHeroRepository heroRepository, IHeroItemRepository heroItemRepository)
    {
        _playerRepository = playerRepository;
        _heroRepository = heroRepository;
        _heroItemRepository = heroItemRepository;
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
        var result = await _heroItemRepository.GetAsync(id);

        if (result == null)
        {
            throw new NullReferenceException();
        }

        return result;
    }

    public async Task SelectHero(Player player, int heroId)
    {
        if (player == null)
        {
            return;
        }

        if (player.Heroes.Any(h => h.Id == heroId))
        {
            await _playerRepository.SetActiveHero(player, heroId);
        }
    }

    public async Task SelectItem(Player player, int itemId)
    {
        if (player == null)
        {
            return;
        }

        var hero = await _heroRepository.Get(player.ActiveHeroId);

        if (hero == null)
        {
            return;
        }

        if (hero.Inventory.Any(i => i.Id == itemId))
        {
            await _playerRepository.SetActiveItem(player, itemId);
        }
    }
}