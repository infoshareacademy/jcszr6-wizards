using Wizards.Core.Model;

namespace Wizards.Services.Validation;

public interface IHeroValidator
{
    Task ValidateForCreate(Hero hero);
    public void ValidateForEdit(Hero hero);
}