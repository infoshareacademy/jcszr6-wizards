using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.UserModels.Enums;
using Wizards.Repository.InitialData.SeedFactories.Interfaces;

namespace Wizards.Repository.InitialData.SeedFactories.Implementations;

public class InitialDataSkillsFactory : IInitialDataSkillsFactory
{
    public List<Skill> GetSkills()
    {
        var result = new List<Skill>();

        result.Add(new Skill() { Id = 1, Name = "Fireball", Description = "Hit enemy with sphere of fire", ProfessionRestriction = ProfessionRestriction.Sorcerer, Type = HeroSkillType.Attack, DamageFactor = 1d, ArmorPenetrationPercent = 0, BaseHitChance = 80, HealingFactor = 0d });
        result.Add(new Skill() { Id = 2, Name = "Ice Shard", Description = "Throw ice shard that deals damage and stops enemy movement", ProfessionRestriction = ProfessionRestriction.Sorcerer, Type = HeroSkillType.CounterAttack, DamageFactor = 0.75d, ArmorPenetrationPercent = 0, BaseHitChance = 105, HealingFactor = 0d });
        result.Add(new Skill() { Id = 3, Name = "Lighting Strike", Description = "Summon lighting strike that breaks enemy defense and deal lot of damage", ProfessionRestriction = ProfessionRestriction.Sorcerer, Type = HeroSkillType.Attack, DamageFactor = 1.35d, ArmorPenetrationPercent = 10, BaseHitChance = 40, HealingFactor = 0d });
        result.Add(new Skill() { Id = 4, Name = "Inferno", Description = "Create fire field under enemy that deals him very high damage.", ProfessionRestriction = ProfessionRestriction.Sorcerer, Type = HeroSkillType.Attack, DamageFactor = 1.75d, ArmorPenetrationPercent = 0, BaseHitChance = 20, HealingFactor = 0d });
        result.Add(new Skill() { Id = 5, Name = "Renewal Fountain", Description = "Create spring that recovers your health", ProfessionRestriction = ProfessionRestriction.Sorcerer, Type = HeroSkillType.Heal, DamageFactor = 0d, ArmorPenetrationPercent = 0, BaseHitChance = 200, HealingFactor = 0.225d });
        result.Add(new Skill() { Id = 6, Name = "Magnetic Shield", Description = "Create magnetic barrier in front of you that protect you from enemy attacks", ProfessionRestriction = ProfessionRestriction.Sorcerer, Type = HeroSkillType.Block, DamageFactor = 0d, ArmorPenetrationPercent = 0, BaseHitChance = 300, HealingFactor = 0d });
        
        result.Add(new Skill() { Id = 7, Name = "Death Breath", Description = "Corrupt air around your enemy to deal him damage", ProfessionRestriction = ProfessionRestriction.Necromancer, Type = HeroSkillType.Attack, DamageFactor = 1d, ArmorPenetrationPercent = 10, BaseHitChance = 90, HealingFactor = 0d });
        result.Add(new Skill() { Id = 8, Name = "Terror", Description = "Fears your enemy, breaks his charge attack and deals damage", ProfessionRestriction = ProfessionRestriction.Necromancer, Type = HeroSkillType.CounterAttack, DamageFactor = 0.5d, ArmorPenetrationPercent = 0, BaseHitChance = 110, HealingFactor = 0d });
        result.Add(new Skill() { Id = 9, Name = "Evil Blood", Description = "Curse enemy's blood to deal damage", ProfessionRestriction = ProfessionRestriction.Necromancer, Type = HeroSkillType.Attack, DamageFactor = 1.25d, ArmorPenetrationPercent = 15, BaseHitChance = 45, HealingFactor = 0.05d });
        result.Add(new Skill() { Id = 10, Name = "Deadly Shroud", Description = "Summon Shroud of Death that deals a lot of damage to your foe.", ProfessionRestriction = ProfessionRestriction.Necromancer, Type = HeroSkillType.Attack, DamageFactor = 1.55d, ArmorPenetrationPercent = 20, BaseHitChance = 25, HealingFactor = 0d });
        result.Add(new Skill() { Id = 11, Name = "Blood Ritual", Description = "Perform Ritual that steals some health from your enemy and recovers yours.", ProfessionRestriction = ProfessionRestriction.Necromancer, Type = HeroSkillType.Heal, DamageFactor = 0.02d, ArmorPenetrationPercent = 25, BaseHitChance = 200, HealingFactor = 0.195d });
        result.Add(new Skill() { Id = 12, Name = "Phantom Shield", Description = "Arise phantom shield that protects you.", ProfessionRestriction = ProfessionRestriction.Necromancer, Type = HeroSkillType.Block, DamageFactor = 0d, ArmorPenetrationPercent = 0, BaseHitChance = 300, HealingFactor = 0d });

        return result;
    }
}