namespace Wizards.Repository.InitialData;

public interface IInitialDataInjector
{
    public Task InjectDevelopmentDataAsync();
    public Task InjectProductionDataAsync();
}