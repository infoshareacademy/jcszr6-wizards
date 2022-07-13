using Wizards.Core.Model;

namespace Wizards.Services.HeroService;

public interface IHeroService
{
    Task Add(int playerId, Hero hero);
    Task Delete(int id);
    Task Update(int id, Hero hero);
    Task<Hero> Get(int id);

}