using System.Collections.Generic;


namespace Wizards.BusinessLogic.Services
{
    public interface IPlayerService
    {
        void Add(Player player);
        void Delete(int id);
        void Update(int id, Player player);
        void UpdatePassword(int id, Player player);
        IEnumerable<Player> GetAll();
        Player Get(int id);
    }
}