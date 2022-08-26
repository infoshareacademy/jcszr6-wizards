using Microsoft.EntityFrameworkCore;
using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.UserModels.Properties;
using Wizards.Repository.InitialData.SeedFactories.Implementations;

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

        modelBuilder.SetCobatStageConfiguration();
    }
    
    internal static void DataSeed(this ModelBuilder modelBuilder)
    {
        var itemsFactory = new InitialDataItemsFactory();
        modelBuilder.Entity<ItemAttributes>().HasData(itemsFactory.GetAttributes());
        modelBuilder.Entity<Item>().HasData(itemsFactory.GetItems());
    }
}