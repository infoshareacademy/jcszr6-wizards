using Wizards.Core.Model;

namespace Wizards.Repository.InitialData.SeedFactories.Interfaces;

public interface IInitialDataUsersFactory
{
    Dictionary<Player, string> GetAdminUsersAsync();
    Dictionary<Player, string> GetModeratorUsersAsync();
    Dictionary<Player, string> GetRandomUsersForTestsAsync();
}