using Microsoft.EntityFrameworkCore;
using Wizards.Core.Model.UserModels;

namespace Wizards.Repository.DbConfiguration;

internal static class PlayerDbConfiguration
{
    internal static void SetPlayerConfiguration(this ModelBuilder modelBuilder)
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

        modelBuilder.Entity<Player>()
            .Property(p => p.MusicVolume)
            .IsRequired()
            .HasDefaultValue(100);
    }
}