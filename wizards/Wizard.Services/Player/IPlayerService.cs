namespace Wizards.Services.Player
{
    public interface IPlayerService
    {
        void Add(Core.Model.Player player);
        void Delete(int id);
        void Update(int id, Core.Model.Player player);
        void UpdatePassword(int id, Core.Model.Player player);
        IEnumerable<Core.Model.Player> GetAll();
        Core.Model.Player Get(int id);
    }
}