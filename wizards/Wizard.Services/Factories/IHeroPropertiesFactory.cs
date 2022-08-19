using Wizards.Core.Model;
using Wizards.Core.Model.Enums;
using Wizards.Core.Model.Properties;

namespace Wizards.Services.Factories;

public interface IHeroPropertiesFactory
{
    Statistics GetStatistics();
    HeroAttributes GetHeroAttributes(HeroProfession profession);
    List<HeroItem> GetStartupEquipment(HeroProfession profession);
}