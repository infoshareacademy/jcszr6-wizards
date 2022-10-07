namespace Wizards.Repository.GameDataManagement;

public interface IGameDataManager
{
    public Task ApplicationStartupScheduleAsync(bool isDevelopment);
    public Task DailyResetScheduleAsync();
    public Task WeeklyGameUpdateAsync();
    public Task FixingUpdateAsync();
}