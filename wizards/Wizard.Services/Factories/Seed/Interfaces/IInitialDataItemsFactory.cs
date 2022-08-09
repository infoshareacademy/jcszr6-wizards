using Wizards.Core.Model;

namespace Wizards.Services.Factories.Seed.Interfaces;

public interface IInitialDataItemsFactory
{
    List<Item> GetItems();
    List<ItemAttributes> GetAttributes();
}