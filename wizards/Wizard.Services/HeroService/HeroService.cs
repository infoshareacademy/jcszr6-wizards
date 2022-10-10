using System.Security.Claims;
using Wizards.Core.Interfaces;
using Wizards.Core.Interfaces.UserModelInterfaces;
using Wizards.Core.Model;
using Wizards.Core.Model.UserModels;
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
    private readonly INewHeroFactory _newHeroFactory;


    public HeroService(IHeroValidator heroValidator, IHeroRepository heroRepository, IPlayerService playerService, INewHeroFactory newHeroFactory)
    {
        _heroValidator = heroValidator;
        _heroRepository = heroRepository;
        _playerService = playerService;
        _newHeroFactory = newHeroFactory;
    }

    public async Task Add(ClaimsPrincipal user, Hero hero)
    {
        await _heroValidator.Validate(hero);
        var heroToCreate = await _newHeroFactory.GetNewHero(hero.Profession);

        heroToCreate.AvatarImageNumber = hero.AvatarImageNumber;
        heroToCreate.NickName = hero.NickName;
        
        var player = await _playerService.Get(user);
        
        await _heroRepository.Add(player, heroToCreate);

        hero.Id = heroToCreate.Id;
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

    public async Task<Hero> Get(ClaimsPrincipal user)
    {
        var ownerPlayer = await _playerService.Get(user);
        var id = ownerPlayer.ActiveHeroId;

        return await Get(id);
    }

    private async Task<Hero> Get(int id)
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

    public async Task SpendGold(Hero hero, int goldToSpend)
    {
        if (goldToSpend < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(goldToSpend), message: "Gold cannot be less than zero!");
        }

        if (hero == null)
        {
            throw new NullReferenceException("Invalid Hero!");
        }

        if (hero.Gold - goldToSpend < 0)
        {
            var message = new Dictionary<string, string>();
            message.Add("", "You have not enough gold!");
            throw new InvalidModelException(message);
        }

        hero.Gold -= goldToSpend;
        await _heroRepository.Update(hero);
    }

    public async Task ClaimGold(Hero hero, int goldToClaim)
    {
        if (goldToClaim < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(goldToClaim), message:"Gold cannot be less than zero!");
        }

        if (hero == null)
        {
            throw new NullReferenceException("Invalid Hero!");
        }

        hero.Gold += goldToClaim;
        await _heroRepository.Update(hero);
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
            message.Add("AvatarImageNumber", "You don't have enough gold!");
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