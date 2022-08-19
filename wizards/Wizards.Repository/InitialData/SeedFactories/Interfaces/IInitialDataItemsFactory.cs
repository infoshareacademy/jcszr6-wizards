using Wizards.Core.Model;
using Wizards.Core.Model.Properties;

namespace Wizards.Repository.InitialData.SeedFactories.Interfaces;

public interface IInitialDataItemsFactory
{
    List<Item> GetItems();
    List<ItemAttributes> GetAttributes();
}