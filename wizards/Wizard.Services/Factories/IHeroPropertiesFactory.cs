using Wizards.Core.Model;
using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.UserModels.Enums;
using Wizards.Core.Model.UserModels.Properties;

namespace Wizards.Services.Factories;

public interface IHeroPropertiesFactory
{
    Statistics GetStatistics();
    HeroAttributes GetHeroAttributes(HeroProfession profession);
    List<HeroItem> GetStartupEquipment(HeroProfession profession);
}