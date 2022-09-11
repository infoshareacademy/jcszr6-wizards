using Microsoft.EntityFrameworkCore;
using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.UserModels.Properties;
using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Properties;
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
    }
    
    internal static void DataSeed(this ModelBuilder modelBuilder)
    {
        var itemsFactory = new InitialDataItemsFactory();
        modelBuilder.Entity<ItemAttributes>().HasData(itemsFactory.GetAttributes());
        modelBuilder.Entity<Item>().HasData(itemsFactory.GetItems());

        var skillsFactory = new InitialDataSkillsFactory();
        modelBuilder.Entity<Skill>().HasData(skillsFactory.GetSkills());

        var enemiesFactory = new InitialDataEnemiesFactory();
        modelBuilder.Entity<EnemyAttributes>().HasData(enemiesFactory.GetEnemiesAttributes());
        modelBuilder.Entity<Enemy>().HasData(enemiesFactory.GetEnemies());
        modelBuilder.Entity<EnemySkill>().HasData(enemiesFactory.GetEnemiesSkills());
        modelBuilder.Entity<BehaviorPattern>().HasData(enemiesFactory.GetEnemiesBehaviorPatterns());
    }
}