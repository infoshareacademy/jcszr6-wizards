using System.Collections.Generic;


namespace Wizards.BusinessLogic.Services
{
    public interface IPlayerService
    {

        void Add(Player player);
        void DeleteById(int id);
        void Update(int id, Player player);
        IEnumerable<Player> GetAll();
        Player GetById(int id);
    }
}