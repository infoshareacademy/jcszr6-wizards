using Wizards.Core.Model;

namespace Wizards.Services.Factories.Seed.Interfaces;

public interface IInitialDataUsersFactory
{
    Dictionary<Player, string> GetAdminUsersAsync();
    Dictionary<Player, string> GetModeratorUsersAsync();
    Dictionary<Player, string> GetRandomUsersForTestsAsync();
}