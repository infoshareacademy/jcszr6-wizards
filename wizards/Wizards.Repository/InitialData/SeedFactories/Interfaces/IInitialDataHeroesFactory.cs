using Wizards.Core.Model;
using Wizards.Core.Model.UserModels;

namespace Wizards.Repository.InitialData.SeedFactories.Interfaces;

public interface IInitialDataHeroesFactory
{
    Dictionary<Hero, string> GetRandomTestHeroesWithEquipment();
    Dictionary<Hero, string> GetAdminHeroesWithEquipment();
    Dictionary<Hero, string> GetModeratorHeroesWithEquipment();
}