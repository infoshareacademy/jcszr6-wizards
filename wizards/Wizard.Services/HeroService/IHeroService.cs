using System.Security.Claims;
using Wizards.Core.Model;
using Wizards.Core.Model.UserModels;

namespace Wizards.Services.HeroService;

public interface IHeroService
{
    Task Add(ClaimsPrincipal user, Hero hero);
    Task Delete(int id, string confirmNickName);
    Task Update(int id, Hero hero);
    Task<Hero> Get(ClaimsPrincipal user);
    int GetChangeNickNameCost();
    int GetChangeAvatarCost();
    Task SpendGold(Hero hero, int goldToSpend);
    Task ClaimGold(Hero hero, int goldToClaim);
}