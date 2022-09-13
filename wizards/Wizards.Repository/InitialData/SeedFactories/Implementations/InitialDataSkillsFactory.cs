using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.UserModels.Enums;
using Wizards.Repository.InitialData.SeedFactories.Interfaces;

namespace Wizards.Repository.InitialData.SeedFactories.Implementations;

public class InitialDataSkillsFactory : IInitialDataSkillsFactory
{
    public List<Skill> GetSkills()
    {
        var result = new List<Skill>();

        result.Add(new Skill(){Id = 1, Name = "Fireball", Description = "Hit enemy with sphere of fire", ProfessionRestriction = ProfessionRestriction.Sorcerer, Type = HeroSkillType.Attack, DamageFactor = 1.0d, ArmorPenetrationPercent = 0, BaseHitChance = 80, HealingFactor = 0d});
        result.Add(new Skill(){Id = 2, Name = "Ice Shard", Description = "Throw ice shard that deals damage and stops enemy movement", ProfessionRestriction = ProfessionRestriction.Sorcerer, Type = HeroSkillType.CounterAttack, DamageFactor = 0.75d, ArmorPenetrationPercent = 0, BaseHitChance = 125, HealingFactor = 0d});
        result.Add(new Skill(){Id = 3, Name = "Lighting Strike", Description = "Summon lighting strike that breaks enemy defense and deal lot of damage", ProfessionRestriction = ProfessionRestriction.Sorcerer, Type = HeroSkillType.Attack, DamageFactor = 1.4d, ArmorPenetrationPercent = 15, BaseHitChance = 50, HealingFactor = 0d});
        result.Add(new Skill(){Id = 4, Name = "Inferno", Description = "Create fire field under enemy that deals very high damage to enemy", ProfessionRestriction = ProfessionRestriction.Sorcerer, Type = HeroSkillType.Attack, DamageFactor = 1.75d, ArmorPenetrationPercent = 10, BaseHitChance = 30, HealingFactor = 0d});
        result.Add(new Skill(){Id = 5, Name = "Renewal Fountain", Description = "Create spring that recovers your health", ProfessionRestriction = ProfessionRestriction.Sorcerer, Type = HeroSkillType.Heal, DamageFactor = 0d, ArmorPenetrationPercent = 0, BaseHitChance = 200, HealingFactor = 0.1d});
        result.Add(new Skill(){Id = 6, Name = "Magnetic Shield", Description = "Create magnetic barrier in front of you that protect you from enemy attacks", ProfessionRestriction = ProfessionRestriction.Sorcerer, Type = HeroSkillType.Block, DamageFactor = 0d, ArmorPenetrationPercent = 0, BaseHitChance = 300, HealingFactor = 0d});

        result.Add(new Skill() { Id = 7, Name = "Necro1", Description = "", ProfessionRestriction = ProfessionRestriction.Necromancer, Type = HeroSkillType.Attack, DamageFactor = 1.0d, ArmorPenetrationPercent = 0, BaseHitChance = 85, HealingFactor = 0d });
        result.Add(new Skill() { Id = 8, Name = "Necro2", Description = "", ProfessionRestriction = ProfessionRestriction.Necromancer, Type = HeroSkillType.CounterAttack, DamageFactor = 0.5d, ArmorPenetrationPercent = 30, BaseHitChance = 100, HealingFactor = 0d });
        result.Add(new Skill() { Id = 9, Name = "Necro3", Description = "", ProfessionRestriction = ProfessionRestriction.Necromancer, Type = HeroSkillType.Attack, DamageFactor = 1.1d, ArmorPenetrationPercent = 40, BaseHitChance = 70, HealingFactor = 0d });
        result.Add(new Skill() { Id = 10, Name = "Necro4", Description = "", ProfessionRestriction = ProfessionRestriction.Necromancer, Type = HeroSkillType.Attack, DamageFactor = 1.5d, ArmorPenetrationPercent = 40, BaseHitChance = 55, HealingFactor = 0d });
        result.Add(new Skill() { Id = 11, Name = "Necro5", Description = "", ProfessionRestriction = ProfessionRestriction.Necromancer, Type = HeroSkillType.Heal, DamageFactor = 0d, ArmorPenetrationPercent = 0, BaseHitChance = 100, HealingFactor = 0.11d });
        result.Add(new Skill() { Id = 12, Name = "Necro6", Description = "", ProfessionRestriction = ProfessionRestriction.Necromancer, Type = HeroSkillType.Block, DamageFactor = 0d, ArmorPenetrationPercent = 0, BaseHitChance = 100, HealingFactor = 0d });
        
        return result;
    }
}