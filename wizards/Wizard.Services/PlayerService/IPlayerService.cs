namespace Wizards.Services.PlayerService
{
    public interface IPlayerService
    {
        Task Add(Core.Model.Player player);
        Task Delete(int id);
        Task Update(int id, Core.Model.Player player);
        Task UpdatePassword(int id, Core.Model.Player player);
        Task<Core.Model.Player> Get(int id);
    }
}