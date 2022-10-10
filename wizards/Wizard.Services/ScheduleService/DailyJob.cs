using Quartz;
using Wizards.Repository.GameDataManagement;

namespace Wizards.Services.ScheduleService;

public class DailyJob : IJob
{
    private readonly IGameDataManager _gameDataManager;

    public DailyJob(IGameDataManager gameDataManager)
    {
        _gameDataManager = gameDataManager;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        await _gameDataManager.DailyResetScheduleAsync();
    }
}