using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizards.Core.Interfaces;
using Wizards.Core.Model;

namespace Wizards.Services.ItemService
{
    internal class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public async Task Add(Item item)
        {
            await _itemRepository.Add(item);
        }

        public async Task<Item> Get(int id)
        {
            var result = await _itemRepository.Get(id);
            if (result == null)
            {
                throw new NullReferenceException($"There is no Item with Id:{id}");
            }
            return result;
        }

        public async Task<List<Item>> GetAll()
        {
            return await _itemRepository.GetAll();
        }

        public async Task Remove(Item item)
        {
            await _itemRepository.Remove(item);
        }

        public async Task Update(Item item)
        {
            await _itemRepository.Update(item);
        }
    }
}
