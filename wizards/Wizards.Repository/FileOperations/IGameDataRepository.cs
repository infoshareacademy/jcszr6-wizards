using System.Collections.Generic;

namespace Wizards.BusinessLogic.Services.FileOperations
{
    public interface IGameDataRepository
    {
        void Update(List<Player> players);
        List<Player> Get();
    }
}