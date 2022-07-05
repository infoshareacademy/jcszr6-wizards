using Wizards.Core.Model;

namespace Wizards.Repository.FileOperations
{
    public interface IWizardsRepository
    {
        void Update(List<Player> players);
        List<Player> GetAll();
    }
}