using Wizards.Core.Model;

namespace Wizards.Repository.InitialData.SeedFactories.Interfaces;

public interface IInitialDataHeroesFactory
{
    List<Hero> GetHeroes();
    List<List<HeroItem>> GetInventories();
}