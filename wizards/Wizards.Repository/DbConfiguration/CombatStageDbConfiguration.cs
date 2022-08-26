using Microsoft.EntityFrameworkCore;
using Wizards.Core.Model.WorldModels;

namespace Wizards.Repository.DbConfiguration;

internal static class CombatStageDbConfiguration
{
    internal static void SetCobatStageConfiguration(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CombatStage>()
            .HasKey(cs => cs.Id);

        modelBuilder.Entity<CombatStage>()
            .Property(cs => cs.StageName)
            .IsRequired(false)
            .HasMaxLength(50);

        modelBuilder.Entity<CombatStage>()
            .Property(cs => cs.InUse);

        modelBuilder.Entity<CombatStage>()
            .HasOne(cs => cs.Player)
            .WithOne(p => p.CombatStage)
            .HasForeignKey<CombatStage>(cs => cs.PlayerId);

        modelBuilder.Entity<CombatStage>()
            .Property(cs => cs.HeroId)
            .IsRequired()
            .HasDefaultValue(0);

        modelBuilder.Entity<CombatStage>()
            .Ignore(cs => cs.Hero);

        modelBuilder.Entity<CombatStage>()
            .Property(cs => cs.IsHeroStunned);

        modelBuilder.Entity<CombatStage>()
            .Property(cs => cs.CurrentHeroHealth)
            .IsRequired()
            .HasDefaultValue(0);

        modelBuilder.Entity<CombatStage>()
            .Property(cs => cs.HeroSelectedSkillId)
            .IsRequired()
            .HasDefaultValue(0);

        modelBuilder.Entity<CombatStage>()
            .Property(cs => cs.EnemyId)
            .IsRequired()
            .HasDefaultValue(0);

        modelBuilder.Entity<CombatStage>()
            .Ignore(cs => cs.Enemy);

        modelBuilder.Entity<CombatStage>()
            .Property(cs => cs.IsEnemyStunned);

        modelBuilder.Entity<CombatStage>()
            .Property(cs => cs.CurrentEnemyHealth)
            .IsRequired()
            .HasDefaultValue(0);

        modelBuilder.Entity<CombatStage>()
            .Property(cs => cs.EnemySelectedSkillId)
            .IsRequired()
            .HasDefaultValue(0);

        modelBuilder.Entity<CombatStage>()
            .Property(cs => cs.RoundLogs)
            .HasConversion(
                s => string.Join("<NextLog>", s),
                v => v.Split("<NextLog>", StringSplitOptions.RemoveEmptyEntries).ToList())
            .HasMaxLength(30_000);
    }
}