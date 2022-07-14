using Wizards.Core.Interfaces;
using Wizards.Core.Model;
using Wizards.Services.PlayerService;
using Wizards.Services.Validation;

namespace Wizards.Services.HeroService;

public class HeroService : IHeroService
{
    private readonly IHeroValidator _heroValidator;
    private readonly IHeroRepository _heroRepository;
    private readonly IPlayerService _playerService;

    public HeroService(IHeroValidator heroValidator, IHeroRepository heroRepository, IPlayerService playerService)
    {
        _heroValidator = heroValidator;
        _heroRepository = heroRepository;
        _playerService = playerService;
    }


    public async Task Add(int playerId, Hero hero)
    {
        await _heroValidator.ValidateForCreate(hero);
        hero.Gold = 0;
        hero.Attributes = new HeroAttributes()
        {
            Damage = 10,
            Precision = 5,
            Specialization = 0,
            DailyRewardEnergy = 10,
            MaxHealth = 25,
            Defense = 0,
            Reflex = 0
        };

        hero.Statistics = new Statistics()
        {
            RankPoints = 0,
            TotalMatchPlayed = 0,
            TotalMatchLoose = 0,
            TotalMatchWin = 0
        };

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