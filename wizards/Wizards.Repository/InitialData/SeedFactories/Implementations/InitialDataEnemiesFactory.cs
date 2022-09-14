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

        result.Add(new EnemyAttributes() { Id = 1, Damage = 50, Precision = 0, Specialization = 50, Defense = 0, Reflex = 35, MaxHealth = 2500 });

        return result;
    }

    public List<EnemySkill> GetEnemiesSkills()
    {
        var result = new List<EnemySkill>();

        result.Add(new EnemySkill() { Id = 1, EnemyId = 1, Name = "Bite", Type = EnemySkillType.Attack, DamageFactor = 0.15d, BaseHitChance = 100, ArmorPenetrationPercent = 0, Stunning = false, HealingFactor = 0d });
        result.Add(new EnemySkill() { Id = 2, EnemyId = 1, Name = "Triple bite", Type = EnemySkillType.Attack, DamageFactor = 0.25d, BaseHitChance = 85, ArmorPenetrationPercent = 0, Stunning = false, HealingFactor = 0d });
        result.Add(new EnemySkill() { Id = 3, EnemyId = 1, Name = "Tail swipe", Type = EnemySkillType.StrongAttack, DamageFactor = 0.55d, BaseHitChance = 70, ArmorPenetrationPercent = 0, Stunning = true, HealingFactor = 0d });

        result.Add(new EnemySkill() { Id = 4, EnemyId = 1, Name = "Scratch", Type = EnemySkillType.Attack, DamageFactor = 0.20d, BaseHitChance = 105, ArmorPenetrationPercent = 0, Stunning = false, HealingFactor = 0d });
        result.Add(new EnemySkill() { Id = 5, EnemyId = 1, Name = "Sneaky claw", Type = EnemySkillType.Attack, DamageFactor = 0.30d, BaseHitChance = 90, ArmorPenetrationPercent = 0, Stunning = false, HealingFactor = 0d });
        result.Add(new EnemySkill() { Id = 6, EnemyId = 1, Name = "Smashing tail", Type = EnemySkillType.StrongAttack, DamageFactor = 0.55d, BaseHitChance = 85, ArmorPenetrationPercent = 0, Stunning = true, HealingFactor = 0d });

        result.Add(new EnemySkill() { Id = 7, EnemyId = 1, Name = "Rage", Type = EnemySkillType.Charge, DamageFactor = 0.65d, BaseHitChance = 200, ArmorPenetrationPercent = 0, Stunning = false, HealingFactor = 0d });
        result.Add(new EnemySkill() { Id = 8, EnemyId = 1, Name = "Roar!", Type = EnemySkillType.Heal, DamageFactor = 0d, BaseHitChance = 300, ArmorPenetrationPercent = 0, Stunning = false, HealingFactor = 0.15d });
        result.Add(new EnemySkill() { Id = 9, EnemyId = 1, Name = "Deadly blast", Type = EnemySkillType.Deadly, DamageFactor = 2.0d, BaseHitChance = 300, ArmorPenetrationPercent = 150, Stunning = false, HealingFactor = 0d });
        result.Add(new EnemySkill() { Id = 10, EnemyId = 1, Name = "Destructive shock wave", Type = EnemySkillType.Deadly, DamageFactor = 5.0d, BaseHitChance = 300, ArmorPenetrationPercent = 150, Stunning = false, HealingFactor = 0d });

        return result;
    }

    public List<BehaviorPattern> GetEnemiesBehaviorPatterns()
    {
        var result = new List<BehaviorPattern>();

        var sequenceOne = new List<SkillSequenceStep>();
        var sequenceTwo = new List<SkillSequenceStep>();
        var sequenceThree = new List<SkillSequenceStep>();
        sequenceOne.Add(new SkillSequenceStep() { SequenceStepId = 1, SkillId = 1 });
        sequenceOne.Add(new SkillSequenceStep() { SequenceStepId = 2, SkillId = 1 });
        sequenceOne.Add(new SkillSequenceStep() { SequenceStepId = 3, SkillId = 2 });
        sequenceOne.Add(new SkillSequenceStep() { SequenceStepId = 4, SkillId = 1 });
        sequenceOne.Add(new SkillSequenceStep() { SequenceStepId = 5, SkillId = 1 });
        sequenceOne.Add(new SkillSequenceStep() { SequenceStepId = 6, SkillId = 7 });
        sequenceOne.Add(new SkillSequenceStep() { SequenceStepId = 7, SkillId = 3 });
        sequenceOne.Add(new SkillSequenceStep() { SequenceStepId = 8, SkillId = 2 });

        sequenceTwo.Add(new SkillSequenceStep() { SequenceStepId = 1, SkillId = 1 });
        sequenceTwo.Add(new SkillSequenceStep() { SequenceStepId = 2, SkillId = 4 });
        sequenceTwo.Add(new SkillSequenceStep() { SequenceStepId = 3, SkillId = 4 });
        sequenceTwo.Add(new SkillSequenceStep() { SequenceStepId = 4, SkillId = 5 });
        sequenceTwo.Add(new SkillSequenceStep() { SequenceStepId = 5, SkillId = 2 });
        sequenceTwo.Add(new SkillSequenceStep() { SequenceStepId = 6, SkillId = 2 });
        sequenceTwo.Add(new SkillSequenceStep() { SequenceStepId = 7, SkillId = 5 });
        sequenceTwo.Add(new SkillSequenceStep() { SequenceStepId = 8, SkillId = 7 });
        sequenceTwo.Add(new SkillSequenceStep() { SequenceStepId = 9, SkillId = 8 });
        sequenceTwo.Add(new SkillSequenceStep() { SequenceStepId = 10, SkillId = 2 });
        sequenceTwo.Add(new SkillSequenceStep() { SequenceStepId = 11, SkillId = 4 });
        sequenceTwo.Add(new SkillSequenceStep() { SequenceStepId = 12, SkillId = 5 });
        sequenceTwo.Add(new SkillSequenceStep() { SequenceStepId = 13, SkillId = 7 });
        sequenceTwo.Add(new SkillSequenceStep() { SequenceStepId = 14, SkillId = 9 });

        sequenceThree.Add(new SkillSequenceStep() { SequenceStepId = 1, SkillId = 4});
        sequenceThree.Add(new SkillSequenceStep() { SequenceStepId = 2, SkillId = 5});
        sequenceThree.Add(new SkillSequenceStep() { SequenceStepId = 3, SkillId = 4});
        sequenceThree.Add(new SkillSequenceStep() { SequenceStepId = 4, SkillId = 4});
        sequenceThree.Add(new SkillSequenceStep() { SequenceStepId = 5, SkillId = 7});
        sequenceThree.Add(new SkillSequenceStep() { SequenceStepId = 6, SkillId = 9});
        sequenceThree.Add(new SkillSequenceStep() { SequenceStepId = 7, SkillId = 4});
        sequenceThree.Add(new SkillSequenceStep() { SequenceStepId = 8, SkillId = 5});
        sequenceThree.Add(new SkillSequenceStep() { SequenceStepId = 9, SkillId = 5});
        sequenceThree.Add(new SkillSequenceStep() { SequenceStepId = 10, SkillId = 7});
        sequenceThree.Add(new SkillSequenceStep() { SequenceStepId = 11, SkillId = 9});
        sequenceThree.Add(new SkillSequenceStep() { SequenceStepId = 12, SkillId = 4});
        sequenceThree.Add(new SkillSequenceStep() { SequenceStepId = 13, SkillId = 7});
        sequenceThree.Add(new SkillSequenceStep() { SequenceStepId = 14, SkillId = 9});
        sequenceThree.Add(new SkillSequenceStep() { SequenceStepId = 15, SkillId = 6});
        sequenceThree.Add(new SkillSequenceStep() { SequenceStepId = 16, SkillId = 10});

        result.Add(new BehaviorPattern()
        {
            Id = 1,
            EnemyId = 1,
            MaxHealthPercentToTrigger = 100,
            MinHealthPercentToTrigger = 66,
            SequenceOfSkillsId = sequenceOne
        });
        result.Add(new BehaviorPattern()
        {
            Id = 2,
            EnemyId = 1,
            MaxHealthPercentToTrigger = 66,
            MinHealthPercentToTrigger = 33,
            SequenceOfSkillsId = sequenceTwo
        });
        result.Add(new BehaviorPattern()
        {
            Id = 3,
            EnemyId = 1,
            MaxHealthPercentToTrigger = 33,
            MinHealthPercentToTrigger = 0,
            SequenceOfSkillsId = sequenceThree
        });

        return result;
    }

    public List<Enemy> GetEnemies()
    {
        var result = new List<Enemy>();

        result.Add(new Enemy()
        {
            Id = 1,
            AttributesId = 1,
            AvatarImageNumber = 1,
            Name = "Crystalline Hydra",
            Description = "Dangerous enemy with high reflex and strong attacks that overpass armor. " +
                          "Many of attacks can be dodge if you have high reflex. To hit this boss you must be precise! " +
                          "Hydra from time to time will charge on you and after it will cast deadly attack so very important is to successfully counter it's charge. " +
                          "Below 33% health hydra has to be defeated in less than 16 rounds so you have to be perfect at your damage!",
            EnemyStageName = "Lair of Crystalline Hydra",
            GoldReward = 3000,
            RankPointsReward = 100,
            StageBackgroundImageNumber = 1,
            Tier = 5,
            Type = EnemyType.Boss, 
            TrainingEnemy = false
        });

        return result;
    }
}