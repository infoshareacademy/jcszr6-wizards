using Wizards.Core.Model;

namespace Wizards.Services.Validation;
public interface IItemValidator
{
    Task Validate(Item item);
}