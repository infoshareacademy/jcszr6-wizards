using System.Security.Claims;
using Wizards.Core.Model;
using Wizards.Core.Model.UserModels;

namespace Wizards.Services.PlayerService
{
    public interface IPlayerService
    {
        Task Create(Player newPlayer, string password);
        Task Delete(ClaimsPrincipal user, string passwordConfirm);
        Task Update(Player player);
        Task ChangePassword(ClaimsPrincipal user, string currentPassword, string newPassword);
        Task<Player> Get(ClaimsPrincipal user);
        Task SetMusicVolume(ClaimsPrincipal user, int volumeValue);
        Task<int> GetMusicVolume(ClaimsPrincipal user);
    }
}