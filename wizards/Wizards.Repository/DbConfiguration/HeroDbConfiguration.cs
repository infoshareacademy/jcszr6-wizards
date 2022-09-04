using Microsoft.EntityFrameworkCore;
using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.UserModels.Enums;
using Wizards.Core.Model.UserModels.Properties;

namespace Wizards.Repository.DbConfiguration;

internal static class HeroDbConfiguration
{
    internal static void SetHeroConfiguration(this ModelBuilder modelBuilder)
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

    internal static void SetHeroAttributesConfiguration(this ModelBuilder modelBuilder)
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
            .Property(ha => ha.Reflex)
            .IsRequired();

        modelBuilder.Entity<HeroAttributes>()
            .Property(ha => ha.Defense)
            .IsRequired();
    }

    internal static void SetHeroStatisticsConfiguration(this ModelBuilder modelBuilder)
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

    internal static void SetSkillConfiguration(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Skill>()
            .HasKey(s => s.Id);

        modelBuilder.Entity<Skill>()
            .Property(s => s.Name)
            .HasMaxLength(50)
            .IsRequired();

        modelBuilder.Entity<Skill>()
            .HasIndex(s => s.Name)
            .IsUnique();

        modelBuilder.Entity<Skill>()
            .Property(s => s.Type)
            .IsRequired();

        modelBuilder.Entity<Skill>()
            .Property(s => s.ProfessionRestriction)
            .IsRequired();

        modelBuilder.Entity<Skill>()
            .Property(s => s.DamageFactor)
            .HasDefaultValue(1d);

        modelBuilder.Entity<Skill>()
            .Property(s => s.BaseHitChance)
            .HasDefaultValue(80);

        modelBuilder.Entity<Skill>()
            .Property(s => s.ArmorPenetrationPercent)
            .HasDefaultValue(0);

        modelBuilder.Entity<Skill>()
            .Property(s => s.HealingFactor)
            .HasDefaultValue(0.01d);
    }

    internal static void SetHeroSkillConfiguration(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HeroSkill>()
            .HasKey(hs => hs.Id);

        modelBuilder.Entity<HeroSkill>()
            .HasIndex(hs => new { HeroId = hs.HeroId, SkillId = hs.SkillId })
            .IsUnique();

        modelBuilder.Entity<Hero>()
            .HasMany(h => h.Skills)
            .WithOne(hs => hs.Hero)
            .HasForeignKey(hs => hs.HeroId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Skill>()
            .HasMany(s => s.Hero)
            .WithOne(hs => hs.Skill)
            .HasForeignKey(hs => hs.SkillId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<HeroSkill>()
            .Property(hs => hs.InUse)
            .IsRequired()
            .HasDefaultValue(false);

        modelBuilder.Entity<HeroSkill>()
            .Property(hs => hs.SlotNumber)
            .IsRequired()
            .HasDefaultValue(SkillSlotNumber.None);
    }
}