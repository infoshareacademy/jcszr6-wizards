using Wizards.Core.Model;
using Wizards.Core.Model.Enums;

namespace Wizards.Core.Interfaces
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAll();
        Task<List<Item>> GetAll(ProfessionRestriction professionRestriction);
        Task<Item?> Get(int id);
        Task Add(Item item);
        Task Update(Item item);
        Task Remove(Item item);
        Task<List<string>> GetAllNames();
        Task<bool> Exists(int id, string name);
    }
}
