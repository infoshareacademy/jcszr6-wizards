using System.Text.Json;
using Wizards.Core.Interfaces.UserModelInterfaces;
using Wizards.Core.Interfaces.WorldModelInterfaces;
using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.WorldModels;
using Wizards.Repository.InitialData.SeedFactories.Interfaces;

namespace Wizards.Repository.InitialData.SeedFactories.Implementations;

public class GameDataUpdater : IGameDataUpdater
{
    private readonly ISkillRepository _skillRepository;
    private readonly IItemRepository _itemRepository;
    private readonly IEnemyRepository _enemyRepository;

    public GameDataUpdater(ISkillRepository skillRepository, IItemRepository itemRepository, IEnemyRepository enemyRepository)
    {
        _skillRepository = skillRepository;
        _itemRepository = itemRepository;
        _enemyRepository = enemyRepository;
    }

    public async Task UpdateSkillsAsync()
    {
        var skills = ReadFromJson<Skill>("Skills").OrderBy(s => s.Id).ToList();

        var skillsInDb = (await _skillRepository.GetAllAsync()).OrderBy(s => s.Id).ToList();

        foreach (var skill in skills)
        {
            if (skillsInDb.Any(s => s.Id == skill.Id))
            {
                var skillToUpdate = skillsInDb.SingleOrDefault(s => s.Id == skill.Id);

                skillToUpdate.Name = skill.Name;
                skillToUpdate.Description = skill.Description;
                skillToUpdate.Type = skill.Type;
                skillToUpdate.ProfessionRestriction = skill.ProfessionRestriction;
                skillToUpdate.DamageFactor = skill.DamageFactor;
                skillToUpdate.BaseHitChance = skill.BaseHitChance;
                skillToUpdate.ArmorPenetrationPercent = skill.ArmorPenetrationPercent;
                skillToUpdate.HealingFactor = skill.HealingFactor;

                await _skillRepository.UpdateAsync(skillToUpdate);
            }
            else
            {
                skill.Id = 0;
                await _skillRepository.AddAsync(skill);
            }
        }
    }
    public async Task UpdateItemsAsync()
    {
        var items = ReadFromJson<Item>("Items").OrderBy(i => i.Id).ToList();

        var itemsInDb = (await _itemRepository.GetAll()).OrderBy(i => i.Id).ToList();

        foreach (var item in items)
        {
            if (itemsInDb.Any(s => s.Id == item.Id))
            {
                var itemToUpdate = itemsInDb.SingleOrDefault(s => s.Id == item.Id);

                itemToUpdate.Name = item.Name;
                itemToUpdate.Type = item.Type;
                itemToUpdate.Restriction = item.Restriction;
                itemToUpdate.Tier = item.Tier;
                itemToUpdate.BuyPrice = item.BuyPrice;
                itemToUpdate.SellPrice = item.SellPrice;

                itemToUpdate.Attributes.Damage = item.Attributes.Damage;
                itemToUpdate.Attributes.Precision = item.Attributes.Precision;
                itemToUpdate.Attributes.Specialization = item.Attributes.Specialization;
                itemToUpdate.Attributes.MaxHealth = item.Attributes.MaxHealth;
                itemToUpdate.Attributes.Reflex = item.Attributes.Reflex;
                itemToUpdate.Attributes.Defense = item.Attributes.Defense;

                await _itemRepository.Update(itemToUpdate);
            }
            else
            {
                item.Id = 0;
                await _itemRepository.Add(item);
            }
        }
    }

    public async Task UpdateEnemiesAsync()
    {
        var enemies = ReadFromJson<Enemy>("Enemies").OrderBy(e => e.Id).ToList();

        var enemiesInDb = (await _enemyRepository.GetAllAsync()).OrderBy(e => e.Id).ToList();

        foreach (var enemy in enemies)
        {
            if (enemiesInDb.Any(e => e.Id == enemy.Id))
            {
                var enemyToUpdate = enemiesInDb.SingleOrDefault(e => e.Id == enemy.Id);

                enemyToUpdate.Name = enemy.Name;
                enemyToUpdate.Type = enemy.Type;
                enemyToUpdate.Tier = enemy.Tier;
                enemyToUpdate.Description = enemy.Description;
                enemyToUpdate.AvatarImageNumber = enemy.AvatarImageNumber;
                enemyToUpdate.EnemyStageName = enemy.Name;
                enemyToUpdate.StageBackgroundImageNumber = enemy.StageBackgroundImageNumber;
                enemyToUpdate.TrainingEnemy = enemy.TrainingEnemy;
                enemyToUpdate.GoldReward = enemy.GoldReward;
                enemyToUpdate.RankPointsReward = enemy.RankPointsReward;

                UpdateEnemyAttributes(enemyToUpdate, enemy);
                UpdateEnemySkills(enemy, enemyToUpdate);
                UpdateBehaviorPatterns(enemy, enemyToUpdate);

                await _enemyRepository.UpdateAsync(enemyToUpdate);
            }
            else
            {
                enemy.Id = 0;
                enemy.Attributes.Id = 0;
                enemy.Skills.ForEach(s => s.Id = 0);
                enemy.BehaviorPatterns.ForEach(bp => bp.Id = 0);
                await _enemyRepository.AddAsync(enemy);
            }
        }
    }

    private static void UpdateEnemyAttributes(Enemy enemyToUpdate, Enemy enemy)
    {
        enemyToUpdate.Attributes.Damage = enemy.Attributes.Damage;
        enemyToUpdate.Attributes.Precision = enemy.Attributes.Precision;
        enemyToUpdate.Attributes.Specialization = enemy.Attributes.Specialization;
        enemyToUpdate.Attributes.MaxHealth = enemy.Attributes.MaxHealth;
        enemyToUpdate.Attributes.Reflex = enemy.Attributes.Reflex;
        enemyToUpdate.Attributes.Defense = enemy.Attributes.Defense;
    }

    private static void UpdateEnemySkills(Enemy enemy, Enemy enemyToUpdate)
    {
        foreach (var enemySkill in enemy.Skills)
        {
            if (enemyToUpdate.Skills.Any(s => s.Id == enemySkill.Id))
            {
                var skillToUpdate = enemyToUpdate.Skills.SingleOrDefault(s => s.Id == enemySkill.Id);

                skillToUpdate.Name = enemySkill.Name;
                skillToUpdate.Type = enemySkill.Type;
                skillToUpdate.DamageFactor = enemySkill.DamageFactor;
                skillToUpdate.BaseHitChance = enemySkill.BaseHitChance;
                skillToUpdate.ArmorPenetrationPercent = enemySkill.ArmorPenetrationPercent;
                skillToUpdate.HealingFactor = enemySkill.HealingFactor;
            }
            else
            {
                enemySkill.Id = 0;
                enemyToUpdate.Skills.Add(enemySkill);
            }
        }
    }

    private static void UpdateBehaviorPatterns(Enemy enemy, Enemy enemyToUpdate)
    {
        foreach (var behaviorPattern in enemy.BehaviorPatterns)
        {
            if (enemyToUpdate.BehaviorPatterns.Any(bp => bp.Id == behaviorPattern.Id))
            {
                var behaviorPatternToUpdate =
                    enemyToUpdate.BehaviorPatterns.SingleOrDefault(bp => bp.Id == behaviorPattern.Id);

                behaviorPatternToUpdate.MaxHealthPercentToTrigger = behaviorPattern.MaxHealthPercentToTrigger;
                behaviorPatternToUpdate.MinHealthPercentToTrigger = behaviorPattern.MinHealthPercentToTrigger;

                foreach (var skillSequenceStep in behaviorPattern.SequenceOfSkillsId)
                {
                    if (behaviorPatternToUpdate.SequenceOfSkillsId.Any(ss =>
                            ss.SequenceStepId == skillSequenceStep.SequenceStepId))
                    {
                        var skillSequenceStepToUpdate =
                            behaviorPatternToUpdate.SequenceOfSkillsId.SingleOrDefault(ss =>
                                ss.SequenceStepId == skillSequenceStep.SequenceStepId);

                        skillSequenceStepToUpdate.SequenceStepId = skillSequenceStep.SequenceStepId;
                        skillSequenceStepToUpdate.SkillId = skillSequenceStep.SkillId;
                    }
                    else
                    {
                        behaviorPatternToUpdate.SequenceOfSkillsId.Add(skillSequenceStep);
                    }
                }
            }
            else
            {
                enemyToUpdate.BehaviorPatterns.Add(behaviorPattern);
            }
        }
    }

    private static List<T> ReadFromJson<T>(string fileName)
    {
        string path = Path.Combine(Environment.CurrentDirectory, "..", "Wizards.Repository", "InitialData", "JSON", $"{fileName}.json");
        var deserializedObjects = JsonSerializer.Deserialize<List<T>>(File.ReadAllText(path));
        return deserializedObjects;
    }
}