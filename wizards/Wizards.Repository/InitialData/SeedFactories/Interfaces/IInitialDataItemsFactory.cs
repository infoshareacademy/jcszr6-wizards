using Wizards.Core.Model;
using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.UserModels.Properties;

namespace Wizards.Repository.InitialData.SeedFactories.Interfaces;

public interface IInitialDataItemsFactory
{
    List<Item> GetItems();
    List<ItemAttributes> GetAttributes();
}