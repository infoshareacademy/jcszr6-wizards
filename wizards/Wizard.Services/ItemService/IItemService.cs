using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizards.Core.Model;

namespace Wizards.Services.ItemService
{
    public interface IItemService
    {
        Task<List<Item>> GetAll();
        Task<Item> Get(int id);
        Task Add(Item item);
        Task Update(Item item);
        Task Remove(Item item);
    }
}
