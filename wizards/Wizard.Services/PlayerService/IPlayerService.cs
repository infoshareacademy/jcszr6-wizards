using System.Security.Claims;
using Wizards.Core.Model;

namespace Wizards.Services.PlayerService
{
    public interface IPlayerService
    {
        Task Create(Player player, string password);
        Task Delete(int id, string passwordConfirm);
        Task Update(Player player);
        Task ChangePassword(int id, string currentPassword, string newPassword);
        Task<Player> Get(int id);
        Task<Player> Get(ClaimsPrincipal user);
        Task SetActiveHero(Player player, int heroId);
        int GetId(ClaimsPrincipal user);
    }
}