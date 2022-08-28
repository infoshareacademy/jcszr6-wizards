using Microsoft.Extensions.DependencyInjection;
using Wizards.GamePlay.CombatService;
using Wizards.GamePlay.RandomNumberProvider;

namespace Wizards.GamePlay.ServicesRegistration;

public static class ServiceRegistration
{
    public static void AddGamePlayServices(this IServiceCollection services)
    {
        services.AddSingleton<IRandomNumberProvider, RandomNumberProvider.RandomNumberProvider>();
        services.AddTransient<ICombatService, CombatService.CombatService>();
    }
}