using Wizards.Core.Model;

namespace Wizards.Services.Validation
{
    public interface IPlayerValidator
    {
        Task Validate(Player player);
    }
}