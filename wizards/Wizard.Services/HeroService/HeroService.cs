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
        await _heroValidator.ValidateForCreate(hero);
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
        _heroValidator.ValidateForEdit(hero);
        
        var heroToUpdate = await Get(id);

        heroToUpdate.AvatarImageNumber = hero.AvatarImageNumber;
        heroToUpdate.NickName = hero.NickName;

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
}