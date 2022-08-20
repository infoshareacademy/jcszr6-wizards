using Microsoft.Extensions.DependencyInjection;
using Wizards.Repository.InitialData.SeedFactories.Implementations;
using Wizards.Repository.InitialData.SeedFactories.Interfaces;

namespace Wizards.Repository.InitialData;

public static class ServiceRegistration
{
    public static void AddDataInitializer(this IServiceCollection services)
    {
        services.AddTransient<IInitialDataRolesFactory, InitialDataRolesFactory>();
        services.AddTransient<IInitialDataUsersFactory, InitialDataUsersFactory>();
        services.AddTransient<IInitialDataHeroesFactory, InitialDataHeroesFactory>();
        services.AddTransient<IInitialDataItemsFactory, InitialDataItemsFactory>();

        services.AddTransient<IInitialDataInjector, InitialDataInjector>();
    }
}