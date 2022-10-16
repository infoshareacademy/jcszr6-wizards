using Wizards.Core.Model.UserModels;

namespace Wizards.Services.Validation;
public interface IItemValidator
{
    Task Validate(Item item);
}