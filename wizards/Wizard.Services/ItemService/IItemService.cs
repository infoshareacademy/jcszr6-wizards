using Wizards.Core.Model;
using Wizards.Core.Model.UserModels;

namespace Wizards.Services.ItemService
{
    public interface IItemService
    {
        Task<List<Item>> GetAll();
        Task<Item> Get(int id);
        Task Add(Item item);
        Task Update(Item item);
    }
}
