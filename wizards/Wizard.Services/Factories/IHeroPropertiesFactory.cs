using Wizards.Core.Model.Enums;
using Wizards.Core.Model.Properties;

namespace Wizards.Services.Factories;

public interface IHeroPropertiesFactory
{
    Statistics GetStatistics();
    HeroAttributes GetHeroAttributes(HeroProfession profession);
}