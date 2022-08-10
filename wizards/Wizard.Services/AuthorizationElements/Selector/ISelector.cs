using System.Security.Claims;
using Wizards.Core.Model;
using Wizards.Core.Model.ManyToManyTables;

namespace Wizards.Services.Selector;

public interface ISelector
{
    Task<Player> GetPlayerAsync(ClaimsPrincipal user);
    Task<Hero> GetHeroAsync(int id);
    Task<HeroItem> GetHeroItemAsync(int id);
    Task SelectHero(Player player, int heroId);
    Task SelectItem(Player player, int itemId);
}