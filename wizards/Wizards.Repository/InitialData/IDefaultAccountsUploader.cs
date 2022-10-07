namespace Wizards.Repository.InitialData;

public interface IDefaultAccountsUploader
{
    public Task InjectDevelopmentDataAsync();
    public Task InjectProductionDataAsync();
}