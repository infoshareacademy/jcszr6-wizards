using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.UserModels.Enums;

namespace Wizards.Services.Factories;

public interface INewHeroFactory
{
    public Task<Hero> GetNewHero(HeroProfession profession);
}