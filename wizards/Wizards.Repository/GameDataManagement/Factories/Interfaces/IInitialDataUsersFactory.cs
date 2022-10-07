using Wizards.Core.Model.UserModels;

namespace Wizards.Repository.GameDataManagement.Factories.Interfaces;

public interface IInitialDataUsersFactory
{
    Dictionary<Player, string> GetAdminUsers();
    Dictionary<Player, string> GetModeratorUsers();
    public Dictionary<Player, string> GetTesterUsers();
    Dictionary<Player, string> GetRandomUsersForTests();
}