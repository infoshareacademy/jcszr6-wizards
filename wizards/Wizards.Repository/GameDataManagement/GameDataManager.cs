using Microsoft.EntityFrameworkCore;
using Wizards.Repository.GameDataManagement.Updaters;
using Wizards.Repository.InitialData;

namespace Wizards.Repository.GameDataManagement;

public class GameDataManager : IGameDataManager
{
    private readonly WizardsContext _context;
    private readonly IGameDataUploader _gameDataUploader;
    private readonly IDefaultAccountsUploader _dataInjector;

    public GameDataManager(WizardsContext context, IGameDataUploader gameDataUploader, IDefaultAccountsUploader dataInjector)
    {
        _context = context;
        _gameDataUploader = gameDataUploader;
        _dataInjector = dataInjector;
    }

    public async Task ApplicationStartupScheduleAsync(bool isDevelopment)
    {
        if (isDevelopment)
        {
            try
            {
                await _context.Database.MigrateAsync();
            }
            catch (Exception)
            {
                await _context.Database.CloseConnectionAsync();
                await _context.Database.EnsureDeletedAsync();
                await _context.Database.MigrateAsync();
            }

            await _gameDataUploader.AddOrUpdateSkillsFromFileAsync(true);
            await _gameDataUploader.AddOrUpdateItemsFromFileAsync(true);
            await _gameDataUploader.AddOrUpdateEnemiesFromFileAsync(true);
            await _gameDataUploader.UpdateHeroAttributes(true, false);

            await _dataInjector.InjectDevelopmentDataAsync();
        }
        else
        {
            await _context.Database.MigrateAsync();

            await _gameDataUploader.AddOrUpdateSkillsFromFileAsync(true);
            await _gameDataUploader.AddOrUpdateItemsFromFileAsync(true);
            await _gameDataUploader.AddOrUpdateEnemiesFromFileAsync(true);

            await _dataInjector.InjectProductionDataAsync();
        }
    }

    public async Task DailyResetScheduleAsync()
    {
        await _gameDataUploader.UpdateHeroAttributes(false);
    }

    public async Task WeeklyGameUpdateAsync()
    {
        await _gameDataUploader.AddOrUpdateSkillsFromFileAsync();
        await _gameDataUploader.AddOrUpdateItemsFromFileAsync();
        await _gameDataUploader.AddOrUpdateEnemiesFromFileAsync();
        await _gameDataUploader.UpdateHeroAttributes(true, false);
    }

    public async Task FixingUpdateAsync()
    {
        await _context.Database.MigrateAsync();
        await WeeklyGameUpdateAsync();
    }
}