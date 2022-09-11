﻿using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;
using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Properties;

namespace Wizards.Repository.DbConfiguration;

internal static class EnemyDbConfiguration
{
    internal static void SetEnemyConfiguration(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Enemy>()
            .HasKey(e => e.Id);

        modelBuilder.Entity<Enemy>()
            .Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<Enemy>()
            .Property(e => e.EnemyStageName)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<Enemy>()
            .Property(e => e.StageBackgroundImageNumber)
            .IsRequired();
        
        modelBuilder.Entity<Enemy>()
            .Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(2048);

        modelBuilder.Entity<Enemy>()
            .Property(e => e.AvatarImageNumber)
            .IsRequired();

        modelBuilder.Entity<Enemy>()
            .Property(e => e.Type)
            .IsRequired();

        modelBuilder.Entity<Enemy>()
            .Property(e => e.Tier)
            .IsRequired();

        modelBuilder.Entity<Enemy>()
            .HasOne(e => e.Attributes)
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

    internal static void SetEnemyAttributesConfiguration(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EnemyAttributes>()
            .HasKey(ea => ea.Id);

        modelBuilder.Entity<EnemyAttributes>()
            .HasOne(ea => ea.Enemy)
            .WithOne(e => e.Attributes)
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
            .Property(ea => ea.Reflex)
            .IsRequired()
            .HasDefaultValue(0);

        modelBuilder.Entity<EnemyAttributes>()
            .Property(ea => ea.Defense)
            .IsRequired()
            .HasDefaultValue(0);
    }
    internal static void SetEnemySkillConfiguration(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EnemySkill>()
            .HasKey(es => es.Id);

        modelBuilder.Entity<EnemySkill>()
            .HasOne(es => es.Enemy)
            .WithMany(e => e.Skills)
            .HasForeignKey(es => es.EnemyId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<EnemySkill>()
            .Property(es => es.Name)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<EnemySkill>()
            .Property(es => es.Type)
            .IsRequired();

        modelBuilder.Entity<EnemySkill>()
            .Property(es => es.DamageFactor)
            .IsRequired()
            .HasDefaultValue(1d);

        modelBuilder.Entity<EnemySkill>()
            .Property(es => es.BaseHitChance)
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

    internal static void SetEnemyBehaviorPatternConfiguration(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BehaviorPattern>()
            .HasKey(bp => bp.Id);

        modelBuilder.Entity<BehaviorPattern>()
            .HasOne(bp => bp.Enemy)
            .WithMany(e => e.BehaviorPatterns)
            .HasForeignKey(bp => bp.EnemyId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BehaviorPattern>()
            .Property(bp => bp.MinHealthPercentToTrigger)
            .IsRequired();

        modelBuilder.Entity<BehaviorPattern>()
            .Property(bp => bp.MaxHealthPercentToTrigger)
            .IsRequired();

        modelBuilder.Entity<BehaviorPattern>()
            .Property(bp => bp.SequenceOfSkillsId)
            .HasConversion(
                i => i.SkillsIdPatternToXml(),
                s => s.XmlToSkillIdPattern())
            .HasMaxLength(1024);
    }

    private static string SkillsIdPatternToXml(this List<SkillSequenceStep> skillsIdPattern)
    {
        var serializer = new XmlSerializer(typeof(List<SkillSequenceStep>));
        var writer = new StringWriter();
        serializer.Serialize(writer, skillsIdPattern);
        var xmlText = writer.ToString();
        return xmlText;
    }

    private static List<SkillSequenceStep> XmlToSkillIdPattern(this string xmlValue)
    {
        var serializer = new XmlSerializer(typeof(List<SkillSequenceStep>));
        var reader = new StringReader(xmlValue);
        var result = (List<SkillSequenceStep>)serializer.Deserialize(reader);

        if (result == null)
        {
            result = new List<SkillSequenceStep>();
        }

        return result;
    }
}