namespace Wizards.Repository.InitialData.SeedFactories.Interfaces;

public interface IGameDataUpdater
{
    public Task UpdateSkillsAsync();
    public Task UpdateItemsAsync();
    public Task UpdateEnemiesAsync();
}