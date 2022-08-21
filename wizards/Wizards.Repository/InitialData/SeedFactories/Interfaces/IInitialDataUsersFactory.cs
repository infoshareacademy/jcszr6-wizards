using Wizards.Core.Model;

namespace Wizards.Repository.InitialData.SeedFactories.Interfaces;

public interface IInitialDataUsersFactory
{
    Dictionary<Player, string> GetAdminUsers();
    Dictionary<Player, string> GetModeratorUsers();
    public Dictionary<Player, string> GetTesterUsers();
    Dictionary<Player, string> GetRandomUsersForTests();
}