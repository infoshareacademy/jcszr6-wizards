using Wizards.Core.Model;
using Wizards.Core.Model.ManyToManyTables;

namespace Wizards.Repository.InitialData.SeedFactories.Interfaces;

public interface IInitialDataHeroesFactory
{
    List<Hero> GetHeroes();
    List<List<HeroItem>> GetInventories();
}