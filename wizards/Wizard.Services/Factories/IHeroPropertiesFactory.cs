using Wizards.Core.Model;
using Wizards.Core.Model.Enums;

namespace Wizards.Services.Factories;

public interface IHeroPropertiesFactory
{
    Statistics GetStatistics();
    HeroAttributes GetHeroAttributes(HeroProfession profession);
}