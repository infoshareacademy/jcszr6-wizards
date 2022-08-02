using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizards.Core.Interfaces;
using Wizards.Core.Model;
using Wizards.Services.Validation;

namespace Wizards.Services.ItemService
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IItemValidator _itemValidator;

        public ItemService(IItemRepository itemRepository, IItemValidator itemValidator)
        {
            _itemRepository = itemRepository;
            _itemValidator = itemValidator;
        }
        public async Task Add(Item item)
        {
            await _itemValidator.Validate(item);
            item.Attributes.CurrentHealth = item.Attributes.MaxHealth;
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
            await _itemValidator.Validate(item);

            var itemToUpdate = await Get(item.Id);
            itemToUpdate.Name = item.Name;
            itemToUpdate.Tier = item.Tier;
            itemToUpdate.BuyPrice = item.BuyPrice;
            itemToUpdate.SellPrice = item.SellPrice;
            itemToUpdate.Attributes = item.Attributes;
            //w atrybutach są przekazane referencje (może będzie trzeba zminić)
            await _itemRepository.Update(itemToUpdate);
        }
    }
}
