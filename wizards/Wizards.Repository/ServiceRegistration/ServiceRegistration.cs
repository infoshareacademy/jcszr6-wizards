using Microsoft.Extensions.DependencyInjection;
using Wizards.Core.Interfaces;
using Wizards.Repository.InitialData;
using Wizards.Repository.InitialData.SeedFactories.Implementations;
using Wizards.Repository.InitialData.SeedFactories.Interfaces;
using Wizards.Repository.Repository.UserModel;
using Wizards.Repository.Repository.WorldModel;

namespace Wizards.Repository.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<IHeroRepository, HeroRepository>();
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IHeroItemRepository, HeroItemRepository>();
            services.AddTransient<ISkillRepository, SkillRepository>();
            services.AddTransient<IHeroSkillsRepository, HeroSkillsRepository>();

            services.AddTransient<IEnemyRepository, EnemyRepository>();
            services.AddTransient<IEnemySkillsRepository, EnemySkillsRepository>();
            services.AddTransient<IBehaviorPatternRepository, BehaviorPatternRepository>();
            services.AddTransient<ICombatStageInstancesRepository, CombatStageInstancesRepository>();
        }

        public static void AddDataInitializer(this IServiceCollection services)
        {
            services.AddTransient<IInitialDataRolesFactory, InitialDataRolesFactory>();
            services.AddTransient<IInitialDataUsersFactory, InitialDataUsersFactory>();
            services.AddTransient<IInitialDataHeroesFactory, InitialDataHeroesFactory>();
            services.AddTransient<IInitialDataItemsFactory, InitialDataItemsFactory>();

            services.AddTransient<IInitialDataInjector, InitialDataInjector>();
        }
    }
}
