using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;
using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Properties;

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
            .Property(cs => cs.Status)
            .IsRequired();

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
            .Ignore(cs => cs.HeroSelectedSkill);

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
            .Ignore(cs => cs.EnemySelectedSkill);
        
        modelBuilder.Entity<CombatStage>()
            .Property(cs => cs.EnemyBehaviorPatternId)
            .IsRequired()
            .HasDefaultValue(0);

        modelBuilder.Entity<CombatStage>()
            .Property(cs => cs.EnemyPatternStepId)
            .IsRequired()
            .HasDefaultValue(0);

        modelBuilder.Entity<CombatStage>()
            .Property(cs => cs.RoundLogs)
            .HasConversion(
                rl => rl.RoundLogsToXml(),
                v => v.XmlToRoundLogs())
            .HasMaxLength(30_000);
    }
    private static string RoundLogsToXml(this List<RoundLog> roundLogs)
    {
        var serializer = new XmlSerializer(typeof(List<RoundLog>));
        var writer = new StringWriter();
        serializer.Serialize(writer, roundLogs);
        var xmlText = writer.ToString();
        return xmlText;
    }

    private static List<RoundLog> XmlToRoundLogs(this string xmlValue)
    {
        var serializer = new XmlSerializer(typeof(List<RoundLog>));
        var reader = new StringReader(xmlValue);
        var result = (List<RoundLog>)serializer.Deserialize(reader);

        if (result == null)
        {
            result = new List<RoundLog>();
        }

        return result;
    }
}