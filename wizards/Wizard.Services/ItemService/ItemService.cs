﻿using Wizards.Core.Interfaces.UserModelInterfaces;
using Wizards.Core.Model.UserModels;
using Wizards.Services.Validation;

namespace Wizards.Services.ItemService;
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

    public async Task Update(Item item)
    {
        await _itemValidator.Validate(item);

        var itemToUpdate = await Get(item.Id);

        itemToUpdate.Name = item.Name;
        itemToUpdate.Tier = item.Tier;
        itemToUpdate.BuyPrice = item.BuyPrice;
        itemToUpdate.SellPrice = item.SellPrice;
        itemToUpdate.Attributes.Damage = item.Attributes.Damage;
        itemToUpdate.Attributes.Precision = item.Attributes.Precision;
        itemToUpdate.Attributes.Specialization = item.Attributes.Specialization;
        itemToUpdate.Attributes.MaxHealth = item.Attributes.MaxHealth;
        itemToUpdate.Attributes.Reflex = item.Attributes.Reflex;
        itemToUpdate.Attributes.Defense = item.Attributes.Defense;

        await _itemRepository.Update(itemToUpdate);
    }
}