using Microsoft.EntityFrameworkCore;
using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.UserModels.Properties;

namespace Wizards.Repository.DbConfiguration;

internal static class ItemDbConfiguration
{
    internal static void SetItemConfiguration(this ModelBuilder modelBuilder)
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

    internal static void SetItemAttributesConfiguration(this ModelBuilder modelBuilder)
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

    internal static void SetHeroItemConfiguration(this ModelBuilder modelBuilder)
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