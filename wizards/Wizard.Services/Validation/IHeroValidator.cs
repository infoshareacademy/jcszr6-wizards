using Wizards.Core.Model;

namespace Wizards.Services.Validation;

public interface IHeroValidator
{
    Task Validate(Hero hero);
}