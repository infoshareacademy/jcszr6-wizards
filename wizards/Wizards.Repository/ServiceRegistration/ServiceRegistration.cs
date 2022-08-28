using Microsoft.Extensions.DependencyInjection;
using Wizards.Core.Interfaces;
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
            services.AddTransient<ICombatStageRepository, CombatStageRepository>();
            services.AddTransient<IEnemySkillsRepository, EnemySkillsRepository>();
            services.AddTransient<IBehaviorPatternRepository, BehaviorPatternRepository>();

        }               
    }
}
