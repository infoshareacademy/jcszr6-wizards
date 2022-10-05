namespace Wizards.Repository.InitialData.SeedFactories.Interfaces;

public interface IGameDataUpdater
{
    public Task UpdateSkillsAsync();
    public Task UpdateItems();
    public Task UpdateEnemies();
}