using Wizards.Core.Model;

namespace Wizards.Repository.InitialData.SeedFactories.Interfaces;

public interface IInitialDataItemsFactory
{
    List<Item> GetItems();
    List<ItemAttributes> GetAttributes();
}