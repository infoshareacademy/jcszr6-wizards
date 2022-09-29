using Microsoft.Extensions.DependencyInjection;
using Wizards.GamePlay.CombatService;
using Wizards.GamePlay.EnemyAI;
using Wizards.GamePlay.Factories;
using Wizards.GamePlay.Mapping;
using Wizards.GamePlay.RandomNumberProvider;
using Wizards.GamePlay.ResultLogService;
using Wizards.GamePlay.StageService;

namespace Wizards.GamePlay.ServicesRegistration;

public static class ServiceRegistration
{
    public static void AddGamePlayServices(this IServiceCollection services)
    {
        services.AddSingleton<IRandomNumberProvider, RandomNumberProvider.RandomNumberProvider>();
        services.AddTransient<ICombatService, CombatService.CombatService>();
        services.AddTransient<IEnemyAI, EnemyAI.EnemyAI>();
        services.AddTransient<IResultLogService, ResultLogService.ResultLogService>();
        services.AddTransient<IStageService, StageService.StageService>();
        services.AddTransient<ICombatStageFactory, CombatStageFactory>();
        services.AddAutoMapper(typeof(EnemyProfile).Assembly);
        services.AddAutoMapper(typeof(HeroProfile).Assembly);
    }
}