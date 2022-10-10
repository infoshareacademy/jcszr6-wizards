using Quartz;
using Wizards.Repository.GameDataManagement;

namespace Wizards.Services.ScheduleService;

public class WeeklyJob :IJob
{
    private readonly IGameDataManager _gameDataManager;

    public WeeklyJob(IGameDataManager gameDataManager)
    {
        _gameDataManager = gameDataManager;
    }
    public async Task Execute(IJobExecutionContext context)
    {
        await _gameDataManager.WeeklyGameUpdateAsync();
    }
}