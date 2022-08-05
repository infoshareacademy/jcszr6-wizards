using System.Security.Claims;
using Wizards.Core.Interfaces;
using Wizards.Core.Model;
using Wizards.Services.Factories;
using Wizards.Services.PlayerService;
using Wizards.Services.Validation;

namespace Wizards.Services.HeroService;

public class HeroService : IHeroService
{
    private readonly IHeroValidator _heroValidator;
    private readonly IHeroRepository _heroRepository;
    private readonly IPlayerService _playerService;
    private readonly IHeroPropertiesFactory _propertiesFactory;

    public HeroService(IHeroValidator heroValidator, IHeroRepository heroRepository, IPlayerService playerService, IHeroPropertiesFactory propertiesFactory)
    {
        _heroValidator = heroValidator;
        _heroRepository = heroRepository;
        _playerService = playerService;
        _propertiesFactory = propertiesFactory;
    }


    public async Task Add(int playerId, Hero hero)
    {
        await _heroValidator.Validate(hero);
        
        hero.Gold = 0;
        hero.Attributes = _propertiesFactory.GetHeroAttributes(hero.Profession);
        hero.Statistics = _propertiesFactory.GetStatistics();

        var player = await _playerService.Get(playerId);
        
        await _heroRepository.Add(player, hero);
    }

    public async Task Delete(int id)
    {
        var hero = await Get(id);
        await _heroRepository.Remove(hero);
    }

    public async Task Update(int id, Hero hero)
    {
        await _heroValidator.Validate(hero);
        
        var heroToUpdate = await Get(id);

        if (heroToUpdate.NickName != hero.NickName && await CanChangeNickName(heroToUpdate.Id))
        {
            heroToUpdate.NickName = hero.NickName;
            heroToUpdate.Gold -= GetChangeNickNameCost();
        }

        if (heroToUpdate.AvatarImageNumber != hero.AvatarImageNumber && await CanChangeAvatar(heroToUpdate.Id))
        {
            heroToUpdate.AvatarImageNumber = hero.AvatarImageNumber;
            heroToUpdate.Gold -= GetChangeAvatarCost();
        }

        await _heroRepository.Update(heroToUpdate);
    }

    public async Task<Hero> Get(int id)
    {
        var hero = await _heroRepository.Get(id);

        if (hero != null)
        {
            return hero;
        }

        throw new NullReferenceException($"There is no Hero with id: {id}!");
    }

    public async Task<bool> HasPlayerHero(ClaimsPrincipal user, int heroId)
    {
        var playerId = _playerService.GetId(user);
        var player = await _playerService.Get(playerId);

        var result = player.Heroes.Any(h => h.Id == heroId);
        
        return result;
    }

    public async Task<bool> CanChangeNickName(int id)
    {
        var hero = await Get(id);
        return (hero.Gold >= GetChangeNickNameCost());
    }

    public async Task<bool> CanChangeAvatar(int id)
    {
        var hero = await Get(id);
        return (hero.Gold >= GetChangeAvatarCost());
    }

    public int GetChangeNickNameCost()
    {
        return 2500;
    }

    public int GetChangeAvatarCost()
    {
        return 2500;
    }
}