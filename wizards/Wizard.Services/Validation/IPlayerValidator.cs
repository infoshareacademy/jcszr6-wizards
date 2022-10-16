using Wizards.Core.Model.UserModels;

namespace Wizards.Services.Validation;
public interface IPlayerValidator
{
    Task Validate(Player player);
    Task Validate(Player player, string password);
    Task Validate(Player player, string currentPassword, string newPassword);
}