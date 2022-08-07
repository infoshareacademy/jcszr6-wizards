using System.Security.Claims;
using Wizards.Core.Interfaces;
using Wizards.Core.Model;
using Wizards.Services.Factories;
using Wizards.Services.PlayerService;
using Wizards.Services.Validation;
using Wizards.Services.Validation.Elements;

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

    public async Task Delete(int id, string confirmNickName)
    {
        var hero = await Get(id);

        if (hero.NickName != confirmNickName)
        {
            var message = new Dictionary<string, string>();
            message.Add("ConfirmNickName", "Invalid Nick Name!");
            throw new InvalidModelException(message);
        }

        await _heroRepository.Remove(hero);
    }

    public async Task Update(int id, Hero hero)
    {
        var heroToUpdate = await Get(id);
        hero.Profession = heroToUpdate.Profession;
        
        await _heroValidator.Validate(hero);
        
        ChangeNickName(heroToUpdate, hero.NickName);
        ChangeAvatar(heroToUpdate, hero.AvatarImageNumber);

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

    public int GetChangeNickNameCost()
    {
        return 2500;
    }

    public int GetChangeAvatarCost()
    {
        return 2500;
    }

    private void ChangeNickName(Hero heroToUpdate, string nickName)
    {
        if (heroToUpdate.NickName == nickName)
        {
            return;
        }

        if (!CanChangeNickName(heroToUpdate))
        {
            var message = new Dictionary<string, string>();
            message.Add("NickName", "You don't have enough gold!");
            throw new InvalidModelException(message);
        }

        heroToUpdate.NickName = nickName;
        heroToUpdate.Gold -= GetChangeNickNameCost();
    }

    private void ChangeAvatar(Hero heroToUpdate, int avatarNumber)
    {
        if (heroToUpdate.AvatarImageNumber == avatarNumber)
        {
            return;
        }

        if (!CanChangeAvatar(heroToUpdate))
        {
            var message = new Dictionary<string, string>();
            message.Add("NickName", "You don't have enough gold!");
            throw new InvalidModelException(message);
        }

        heroToUpdate.AvatarImageNumber = avatarNumber;
        heroToUpdate.Gold -= GetChangeNickNameCost();
    }

    private bool CanChangeNickName(Hero hero)
    {
        return (hero.Gold >= GetChangeNickNameCost());
    }

    private bool CanChangeAvatar(Hero hero)
    {
        return (hero.Gold >= GetChangeAvatarCost());
    }
}