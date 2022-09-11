using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Enums;
using Wizards.Core.Model.WorldModels.Properties;
using Wizards.Repository.InitialData.SeedFactories.Interfaces;

namespace Wizards.Repository.InitialData.SeedFactories.Implementations;

public class InitialDataEnemiesFactory : IInitialDataEnemiesFactory
{
    public List<EnemyAttributes> GetEnemiesAttributes()
    {
        var result = new List<EnemyAttributes>();

        result.Add(new EnemyAttributes() {Id = 1, Damage = 50, Precision = 0, Specialization = 50, Defense = 0, Reflex = 30, MaxHealth = 1750});

        return result;
    }

    public List<EnemySkill> GetEnemiesSkills()
    {
        var result = new List<EnemySkill>();

        result.Add(new EnemySkill()
        {
            Id = 1, EnemyId = 1, Name = "Attack", Type = EnemySkillType.Attack, DamageFactor = 0.15d,
            BaseHitChance = 40, ArmorPenetrationPercent = 10, Stunning = false, HealingFactor = 0d
        });
        result.Add(new EnemySkill()
        {
            Id = 2, EnemyId = 1, Name = "Strong Attack", Type = EnemySkillType.StrongAttack, DamageFactor = 0.5d,
            BaseHitChance = 60, ArmorPenetrationPercent = 20, Stunning = true, HealingFactor = 0d
        });
        result.Add(new EnemySkill()
        {
            Id = 3, EnemyId = 1, Name = "Charge Attack", Type = EnemySkillType.Charge, DamageFactor = 0.25d, BaseHitChance = 40,
            ArmorPenetrationPercent = 10, Stunning = false, HealingFactor = 0d
        });
        result.Add(new EnemySkill()
        {
            Id = 4, EnemyId = 1, Name = "Deadly Attack", Type = EnemySkillType.Deadly, DamageFactor = 2.75d, BaseHitChance = 40,
            ArmorPenetrationPercent = 10, Stunning = false, HealingFactor = 0d
        });

        return result;
    }

    public List<BehaviorPattern> GetEnemiesBehaviorPatterns()
    {
        var result = new List<BehaviorPattern>();

        var sequenceOne = new List<SkillSequenceStep>();
        var sequenceTwo = new List<SkillSequenceStep>();
        sequenceOne.Add(new SkillSequenceStep(){SequenceStepId = 1, SkillId = 1});
        sequenceOne.Add(new SkillSequenceStep() { SequenceStepId = 2, SkillId = 1 });
        sequenceOne.Add(new SkillSequenceStep() { SequenceStepId =3, SkillId = 2 });
        sequenceOne.Add(new SkillSequenceStep() { SequenceStepId = 4, SkillId = 3 });
        sequenceOne.Add(new SkillSequenceStep() { SequenceStepId = 5, SkillId = 4 });

        sequenceTwo.Add(new SkillSequenceStep() { SequenceStepId = 1, SkillId = 1 });
        sequenceTwo.Add(new SkillSequenceStep() { SequenceStepId = 2, SkillId = 2 });
        sequenceTwo.Add(new SkillSequenceStep() { SequenceStepId = 3, SkillId = 1 });
        sequenceTwo.Add(new SkillSequenceStep() { SequenceStepId = 4, SkillId = 1 });
        sequenceTwo.Add(new SkillSequenceStep() { SequenceStepId = 5, SkillId = 3 });
        sequenceTwo.Add(new SkillSequenceStep() { SequenceStepId = 6, SkillId = 4 });
        sequenceTwo.Add(new SkillSequenceStep() { SequenceStepId = 7, SkillId = 3 });
        sequenceTwo.Add(new SkillSequenceStep() { SequenceStepId = 8, SkillId = 4 });
        
        result.Add(new BehaviorPattern()
        {
            Id = 1, EnemyId = 1, MaxHealthPercentToTrigger = 100, MinHealthPercentToTrigger = 50, SequenceOfSkillsId = sequenceOne
        });
        result.Add(new BehaviorPattern()
        {
            Id = 2, EnemyId = 1, MaxHealthPercentToTrigger = 50, MinHealthPercentToTrigger = 0, SequenceOfSkillsId = sequenceTwo
        });
        
        return result;
    }

    public List<Enemy> GetEnemies()
    {
        var result = new List<Enemy>();

        result.Add(new Enemy()
        {
            Id = 1, AttributesId = 1, AvatarImageNumber = 1, Name = "Crystalline Hydra", Description = "Dangeroud enemy thats has very high reflex and strong attacks",
            EnemyStageName = "Lair of Crystalline Hydra", GoldReward = 1250, StageBackgroundImageNumber = 1, Tier = 5, Type = EnemyType.Boss
        });

        return result;
    }
}