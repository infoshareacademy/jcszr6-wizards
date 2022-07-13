using Wizards.Core.Model;

namespace Wizards.Services.Validation
{
    public interface IPlayerValidator
    {
        Task ValidateForCreate(Player player);
        Task ValidateForUpdate(Player player);
        void ValidateForPasswordUpdate(Player player);
    }
}