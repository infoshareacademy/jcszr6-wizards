using Wizards.Core.Model;
using Wizards.Services.Factories.Seed.Interfaces;

namespace Wizards.Services.Factories.Seed.Implementations;

public class InitialDataUsersFactory : IInitialDataUsersFactory
{
    public Dictionary<Player, string> GetAdminUsersAsync()
    {
        var result = new Dictionary<Player, string>();

        // TODO: This content should be loaded from JSON file:
        result.Add(new Player() { UserName = "Pawel-Dawicki", Email = "pawel.dawicki@wizard.com", DateOfBirth = new DateTime(1900,01,01) }, "Pa$$word2022");
        result.Add(new Player() { UserName = "Pawel-Grajnert", Email = "pawel.grajnert@wizard.com", DateOfBirth = new DateTime(1900,01,01) }, "Pa$$word2022");
        result.Add(new Player() { UserName = "Jakub-Oczko", Email = "jakub.oczko@wizard.com", DateOfBirth = new DateTime(1900,01,01) }, "Pa$$word2022");
        result.Add(new Player() { UserName = "Adrian-Zamyslowski", Email = "adrian.zamyslowski@wizard.com", DateOfBirth = new DateTime(1900, 01, 01) }, "Pa$$word2022");
        
        return result;
    }

    public Dictionary<Player, string> GetModeratorUsersAsync()
    {
        var result = new Dictionary<Player, string>();

        // TODO: This content should be loaded from JSON file:
        result.Add(new Player() { UserName = "Moderator", Email = "moderator@wizard.com", DateOfBirth = new DateTime(1900, 01, 01) }, "Pa$$word2022");

        return result;
    }

    public Dictionary<Player, string> GetRandomUsersForTestsAsync()
    {
        var result = new Dictionary<Player, string>();

        //TODO: Implement logic that fill dictionary with data (data loaded from JSON)

        return result;
    }
}