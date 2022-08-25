using Wizards.Core.Model;
using Wizards.Core.Model.UserModels;

namespace Wizards.Services.Validation;

public interface IHeroValidator
{
    Task Validate(Hero hero);
}