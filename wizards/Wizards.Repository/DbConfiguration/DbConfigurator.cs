using Microsoft.EntityFrameworkCore;
using Wizards.Core.Model;
using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.UserModels.Properties;
using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Properties;
using Wizards.Repository.InitialData.SeedFactories.Implementations;

namespace Wizards.Repository.DbConfiguration;

public static class DbConfigurator
{
    public static void ConfigureEntities(this ModelBuilder modelBuilder)
    {
        SetPlayerConfiguration(modelBuilder);

        SetHeroConfiguration(modelBuilder);
        SetHeroAttributesConfiguration(modelBuilder);
        SetHeroStatisticsConfiguration(modelBuilder);

        SetItemConfiguration(modelBuilder);
        SetItemAttributesConfiguration(modelBuilder);

        SetHeroItemConfiguration(modelBuilder);

        SetEnemyConfiguration(modelBuilder);

        SetEnemyAttributesConfiguration(modelBuilder);

        SetEnemySkillConfiguration(modelBuilder);

        SetEnemyBehaviorPatternConfiguration(modelBuilder);



    }

    private static void SetEnemyBehaviorPatternConfiguration(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BehaviorPattern>()
            .HasKey(bp => bp.Id);

        modelBuilder.Entity<BehaviorPattern>()
            .HasOne(bp => bp.Enemy)
            .WithMany(e => e.BehaviorPatterns)
            .HasForeignKey(bp => bp.EnemyId);

        modelBuilder.Entity<BehaviorPattern>()
            .Property(bp => bp.TriggerHealthIntervalMin)
            .IsRequired();

        modelBuilder.Entity<BehaviorPattern>()
            .Property(bp => bp.TriggerHealthIntervalMax)
            .IsRequired();

        modelBuilder.Entity<BehaviorPattern>()
            .Property(bp => bp.EnemySkillId)
            .HasConversion(
            i => string.Join(';', i),
            s => string.IsNullOrWhiteSpace(s) ? 
                new List<int>() : 
                s.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(v => int.Parse(v)).ToList());
    }

    private static void SetEnemySkillConfiguration(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EnemySkill>()
            .HasKey(es => es.Id);

        modelBuilder.Entity<EnemySkill>()
            .HasOne(es => es.Enemy)
            .WithMany(e => e.Skills)
            .HasForeignKey(es => es.EnemyId);

        modelBuilder.Entity<EnemySkill>()
            .Property(es => es.SkillName)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<EnemySkill>()
            .Property(es => es.SkillType)
            .IsRequired();

        modelBuilder.Entity<EnemySkill>()
            .Property(es => es.DamageFactor)
            .IsRequired()
            .HasDefaultValue(0d);

        modelBuilder.Entity<EnemySkill>()
            .Property(es => es.BaseHitChange)
            .IsRequired()
            .HasDefaultValue(80);

        modelBuilder.Entity<EnemySkill>()
            .Property(es => es.ArmorPenetrationPercent)
            .IsRequired()
            .HasDefaultValue(0);

        modelBuilder.Entity<EnemySkill>()
            .Property(es => es.HealingFactor)
            .IsRequired()
            .HasDefaultValue(0.01d);

        modelBuilder.Entity<EnemySkill>()
             .Property(es => es.Stunning)
             .IsRequired();
    }

    private static void SetEnemyAttributesConfiguration(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EnemyAttributes>()
            .HasKey(ea => ea.Id);

        modelBuilder.Entity<EnemyAttributes>()
            .HasOne(ea => ea.Enemy)
            .WithOne(e => e.EnemyAttributes)
            .HasForeignKey<Enemy>(e => e.AttributesId)
            .IsRequired();

        modelBuilder.Entity<EnemyAttributes>()
            .Property(ea => ea.Damage)
            .IsRequired()
            .HasDefaultValue(0);

        modelBuilder.Entity<EnemyAttributes>()
            .Property(ea => ea.Precision)
            .IsRequired()
            .HasDefaultValue(0);

        modelBuilder.Entity<EnemyAttributes>()
            .Property(ea => ea.Specialization)
            .IsRequired()
            .HasDefaultValue(0);

        modelBuilder.Entity<EnemyAttributes>()
            .Property(ea => ea.MaxHealth)
            .IsRequired()
            .HasDefaultValue(0);

        modelBuilder.Entity<EnemyAttributes>()
            .Property(ea => ea.CurrentHealth)
            .IsRequired()
            .HasDefaultValue(0);

        modelBuilder.Entity<EnemyAttributes>()
            .Property(ea => ea.Reflex)
            .IsRequired()
            .HasDefaultValue(0);

        modelBuilder.Entity<EnemyAttributes>()
            .Property(ea => ea.Defense)
            .IsRequired()
            .HasDefaultValue(0);
    }

    private static void SetEnemyConfiguration(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Enemy>()
            .HasKey(e => e.Id);

        modelBuilder.Entity<Enemy>()
            .Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<Enemy>()
            .Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(256);

        modelBuilder.Entity<Enemy>()
            .Property(e => e.AvatarImageEnemy)
            .IsRequired();

        modelBuilder.Entity<Enemy>()
            .Property(e => e.EnemyType)
            .IsRequired();

        modelBuilder.Entity<Enemy>()
            .Property(e => e.Tier)
            .IsRequired();

        modelBuilder.Entity<Enemy>()
            .HasOne(e => e.EnemyAttributes)
            .WithOne(ea => ea.Enemy)
            .HasForeignKey<Enemy>(e => e.AttributesId)
            .IsRequired();

        modelBuilder.Entity<Enemy>()
            .HasMany(e => e.Skills)
            .WithOne(s => s.Enemy)
            .HasForeignKey(s => s.EnemyId);

        modelBuilder.Entity<Enemy>()
            .HasMany(e => e.BehaviorPatterns)
            .WithOne(bp => bp.Enemy)
            .HasForeignKey(bp => bp.EnemyId);

        modelBuilder.Entity<Enemy>()
            .Property(e => e.GoldReward)
            .IsRequired();

    }

    public static void DataSeed(this ModelBuilder modelBuilder)
    {
        var itemsFactory = new InitialDataItemsFactory();
        modelBuilder.Entity<ItemAttributes>().HasData(itemsFactory.GetAttributes());
        modelBuilder.Entity<Item>().HasData(itemsFactory.GetItems());
    }

    private static void SetPlayerConfiguration(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>()
            .Property(p => p.UserName)
            .HasMaxLength(maxLength: 30)
            .IsRequired();
        modelBuilder.Entity<Player>()
            .HasIndex(p => p.UserName)
            .IsUnique();
        modelBuilder.Entity<Player>()
            .Property(p => p.Email)
            .HasMaxLength(50)
            .IsRequired();
        modelBuilder.Entity<Player>()
            .HasIndex(p => p.Email)
            .IsUnique();
        modelBuilder.Entity<Player>()
            .Property(p => p.DateOfBirth)
            .HasColumnType("date")
            .IsRequired();
        modelBuilder.Entity<Player>()
            .HasMany(p => p.Heroes)
            .WithOne(h => h.Player)
            .HasForeignKey(h => h.PlayerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Player>()
            .Property(p => p.ActiveHeroId)
            .IsRequired()
            .HasDefaultValue(0);
        modelBuilder.Entity<Player>()
            .Property(p => p.ActiveItemId)
            .IsRequired()
            .HasDefaultValue(0);
    }

    private static void SetHeroConfiguration(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hero>()
            .Property(h => h.Id);
        modelBuilder.Entity<Hero>()
            .Property(h => h.NickName)
            .HasMaxLength(maxLength: 20)
            .IsRequired();
        modelBuilder.Entity<Hero>()
            .HasIndex(h => h.NickName)
            .IsUnique();
        modelBuilder.Entity<Hero>()
            .Property(h => h.Profession)
            .IsRequired();
        modelBuilder.Entity<Hero>()
            .Property(h => h.AvatarImageNumber)
            .IsRequired();
        modelBuilder.Entity<Hero>()
            .Property(h => h.Gold)
            .IsRequired()
            .HasDefaultValue(0);
        modelBuilder.Entity<Hero>()
            .HasOne(h => h.Attributes)
            .WithOne(ha => ha.Hero)
            .HasForeignKey<Hero>(ha => ha.AttributesId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Hero>()
            .HasOne(h => h.Statistics)
            .WithOne(s => s.Hero)
            .HasForeignKey<Hero>(s => s.StatisticsId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
    private static void SetHeroAttributesConfiguration(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HeroAttributes>()
            .HasKey(ha => ha.Id);
        modelBuilder.Entity<HeroAttributes>()
            .Property(ha => ha.DailyRewardEnergy)
            .IsRequired();
        modelBuilder.Entity<HeroAttributes>()
            .Property(ha => ha.Damage)
            .IsRequired();
        modelBuilder.Entity<HeroAttributes>()
            .Property(ha => ha.Precision)
            .IsRequired();
        modelBuilder.Entity<HeroAttributes>()
            .Property(ha => ha.Specialization)
            .IsRequired();
        modelBuilder.Entity<HeroAttributes>()
            .Property(ha => ha.MaxHealth)
            .IsRequired();
        modelBuilder.Entity<HeroAttributes>()
            .Property(ha => ha.CurrentHealth)
            .IsRequired();
        modelBuilder.Entity<HeroAttributes>()
            .Property(ha => ha.Reflex)
            .IsRequired();
        modelBuilder.Entity<HeroAttributes>()
            .Property(ha => ha.Defense)
            .IsRequired();
    }
    private static void SetHeroStatisticsConfiguration(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Statistics>()
            .HasKey(s => s.Id);
        modelBuilder.Entity<Statistics>()
            .Property(s => s.RankPoints)
            .IsRequired()
            .HasDefaultValue(0);
        modelBuilder.Entity<Statistics>()
            .Property(s => s.TotalMatchPlayed)
            .IsRequired()
            .HasDefaultValue(0);
        modelBuilder.Entity<Statistics>()
            .Property(s => s.TotalMatchWin)
            .IsRequired()
            .HasDefaultValue(0);
        modelBuilder.Entity<Statistics>()
            .Property(s => s.TotalMatchLoose)
            .IsRequired()
            .HasDefaultValue(0);
    }


    private static void SetItemConfiguration(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>()
            .Property(i => i.Id);
        modelBuilder.Entity<Item>()
            .Property(i => i.Name)
            .HasMaxLength(maxLength: 50)
            .IsRequired();
        modelBuilder.Entity<Item>()
            .Property(i => i.Type)
            .IsRequired();
        modelBuilder.Entity<Item>()
            .Property(i => i.Restriction)
            .IsRequired();
        modelBuilder.Entity<Item>()
            .Property(i => i.Tier)
            .IsRequired();
        modelBuilder.Entity<Item>()
            .Property(i => i.BuyPrice)
            .IsRequired();
        modelBuilder.Entity<Item>()
            .Property(i => i.SellPrice)
            .IsRequired();
        modelBuilder.Entity<Item>()
            .HasOne(i => i.Attributes)
            .WithOne(ia => ia.Item)
            .HasForeignKey<Item>(i => i.AttributesId);
    }
    private static void SetItemAttributesConfiguration(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemAttributes>()
            .HasKey(ia => ia.Id);
        modelBuilder.Entity<ItemAttributes>()
            .Property(ia => ia.Damage)
            .IsRequired();
        modelBuilder.Entity<ItemAttributes>()
            .Property(ia => ia.Precision)
            .IsRequired();
        modelBuilder.Entity<ItemAttributes>()
            .Property(ia => ia.Specialization)
            .IsRequired();
        modelBuilder.Entity<ItemAttributes>()
            .Property(ia => ia.MaxHealth)
            .IsRequired();
        modelBuilder.Entity<ItemAttributes>()
            .Property(ia => ia.Reflex)
            .IsRequired();
        modelBuilder.Entity<ItemAttributes>()
            .Property(ia => ia.Defense)
            .IsRequired();
    }


    private static void SetHeroItemConfiguration(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HeroItem>()
            .HasKey(hi => hi.Id);
        modelBuilder.Entity<Hero>()
            .HasMany(h => h.Inventory)
            .WithOne(hi => hi.Hero)
            .HasForeignKey(hi => hi.HeroId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Item>()
            .HasMany(i => i.Heroes)
            .WithOne(hi => hi.Item)
            .HasForeignKey(hi => hi.ItemId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<HeroItem>()
            .Property(hi => hi.ItemEndurance)
            .IsRequired()
            .HasDefaultValue(100.00d);
        modelBuilder.Entity<HeroItem>()
            .Property(hi => hi.InUse)
            .IsRequired()
            .HasDefaultValue(false);
    }
}