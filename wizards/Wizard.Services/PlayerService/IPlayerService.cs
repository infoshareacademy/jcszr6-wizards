using Wizards.Core.Model;

namespace Wizards.Services.PlayerService
{
    public interface IPlayerService
    {
        Task Add(Player player);
        Task Delete(int id);
        Task Update(int id, Player player);
        Task UpdatePassword(int id, Player player);
        Task<Player> Get(int id);
    }
}