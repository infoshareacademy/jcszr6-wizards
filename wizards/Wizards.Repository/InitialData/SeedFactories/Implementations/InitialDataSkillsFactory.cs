using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.UserModels.Enums;
using Wizards.Repository.InitialData.SeedFactories.Interfaces;

namespace Wizards.Repository.InitialData.SeedFactories.Implementations;

public class InitialDataSkillsFactory : IInitialDataSkillsFactory
{
    public List<Skill> GetSkills()
    {
        var result = new List<Skill>();

        result.Add(new Skill(){Id = 1, Name = "Fireball", ProfessionRestriction = ProfessionRestriction.Sorcerer, Type = HeroSkillType.Attack, DamageFactor = 1.0d, ArmorPenetrationPercent = 0, BaseHitChance = 80, HealingFactor = 0d});
        result.Add(new Skill(){Id = 2, Name = "Ice Shard", ProfessionRestriction = ProfessionRestriction.Sorcerer, Type = HeroSkillType.CounterAttack, DamageFactor = 0.75d, ArmorPenetrationPercent = 0, BaseHitChance = 120, HealingFactor = 0d});
        result.Add(new Skill(){Id = 3, Name = "Lighting Strike", ProfessionRestriction = ProfessionRestriction.Sorcerer, Type = HeroSkillType.Attack, DamageFactor = 1.25d, ArmorPenetrationPercent = 15, BaseHitChance = 60, HealingFactor = 0d});
        result.Add(new Skill(){Id = 4, Name = "Inferno", ProfessionRestriction = ProfessionRestriction.Sorcerer, Type = HeroSkillType.Attack, DamageFactor = 1.75d, ArmorPenetrationPercent = 10, BaseHitChance = 40, HealingFactor = 0d});
        result.Add(new Skill(){Id = 5, Name = "Reneval Fountain", ProfessionRestriction = ProfessionRestriction.Sorcerer, Type = HeroSkillType.Heal, DamageFactor = 0d, ArmorPenetrationPercent = 0, BaseHitChance = 100, HealingFactor = 0.09d});
        result.Add(new Skill(){Id = 6, Name = "Magnetic Shield", ProfessionRestriction = ProfessionRestriction.Sorcerer, Type = HeroSkillType.Block, DamageFactor = 0d, ArmorPenetrationPercent = 0, BaseHitChance = 100, HealingFactor = 0d});

        result.Add(new Skill() { Id = 7, Name = "Necro1", ProfessionRestriction = ProfessionRestriction.Necromancer, Type = HeroSkillType.Attack, DamageFactor = 1.0d, ArmorPenetrationPercent = 0, BaseHitChance = 85, HealingFactor = 0d });
        result.Add(new Skill() { Id = 8, Name = "Necro2", ProfessionRestriction = ProfessionRestriction.Necromancer, Type = HeroSkillType.CounterAttack, DamageFactor = 0.5d, ArmorPenetrationPercent = 30, BaseHitChance = 100, HealingFactor = 0d });
        result.Add(new Skill() { Id = 9, Name = "Necro3", ProfessionRestriction = ProfessionRestriction.Necromancer, Type = HeroSkillType.Attack, DamageFactor = 1.1d, ArmorPenetrationPercent = 40, BaseHitChance = 70, HealingFactor = 0d });
        result.Add(new Skill() { Id = 10, Name = "Necro4", ProfessionRestriction = ProfessionRestriction.Necromancer, Type = HeroSkillType.Attack, DamageFactor = 1.5d, ArmorPenetrationPercent = 40, BaseHitChance = 55, HealingFactor = 0d });
        result.Add(new Skill() { Id = 11, Name = "Necro5", ProfessionRestriction = ProfessionRestriction.Necromancer, Type = HeroSkillType.Heal, DamageFactor = 0d, ArmorPenetrationPercent = 0, BaseHitChance = 100, HealingFactor = 0.11d });
        result.Add(new Skill() { Id = 12, Name = "Necro6", ProfessionRestriction = ProfessionRestriction.Necromancer, Type = HeroSkillType.Block, DamageFactor = 0d, ArmorPenetrationPercent = 0, BaseHitChance = 100, HealingFactor = 0d });
        
        return result;
    }
}