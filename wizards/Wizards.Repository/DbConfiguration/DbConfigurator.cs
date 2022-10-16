using Microsoft.EntityFrameworkCore;

namespace Wizards.Repository.DbConfiguration;

internal static class DbConfigurator
{
    internal static void ConfigureEntities(this ModelBuilder modelBuilder)
    {
        modelBuilder.SetPlayerConfiguration();

        modelBuilder.SetHeroConfiguration();
        modelBuilder.SetHeroAttributesConfiguration();
        modelBuilder.SetHeroStatisticsConfiguration();

        modelBuilder.SetItemConfiguration();
        modelBuilder.SetItemAttributesConfiguration();
        modelBuilder.SetHeroItemConfiguration();

        modelBuilder.SetSkillConfiguration();
        modelBuilder.SetHeroSkillConfiguration();

        modelBuilder.SetEnemyConfiguration();
        modelBuilder.SetEnemyAttributesConfiguration();
        modelBuilder.SetEnemySkillConfiguration();
        modelBuilder.SetEnemyBehaviorPatternConfiguration();
    }
}