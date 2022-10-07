using Wizards.Core.Model.UserModels;

namespace Wizards.Repository.GameDataManagement.Factories.Interfaces;

public interface IInitialDataHeroesFactory
{
    Dictionary<Hero, string> GetRandomTestHeroesWithEquipment();
    Dictionary<Hero, string> GetAdminHeroesWithEquipment();
    Dictionary<Hero, string> GetModeratorHeroesWithEquipment();
}