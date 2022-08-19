namespace Wizards.Repository.InitialData;

public interface IInitialDataInjector
{
    Task InjectDevelopmentDataAsync();
}