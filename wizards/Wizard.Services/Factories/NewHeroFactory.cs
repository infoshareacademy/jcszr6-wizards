using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.UserModels.Enums;

namespace Wizards.Services.Factories;

public class NewHeroFactory : INewHeroFactory
{
    private readonly IHeroPropertiesFactory _propertiesFactory;

    public NewHeroFactory(IHeroPropertiesFactory propertiesFactory)
    {
        _propertiesFactory = propertiesFactory;
    }

    public Task<Hero> GetNewHero(HeroProfession profession)
    {
        var hero = new Hero();

        hero.Profession = profession;
        hero.Gold = 100;

        hero.Statistics = _propertiesFactory.GetStatistics();
        hero.Attributes = _propertiesFactory.GetHeroAttributes(profession);
        hero.Inventory = _propertiesFactory.GetStartupEquipment(profession);
        hero.Skills = _propertiesFactory.GetSkills(profession);

        return Task.FromResult(hero);
    }
}