using System.Text.Json;
using Wizards.Core.Interfaces.UserModelInterfaces;
using Wizards.Core.Interfaces.WorldModelInterfaces;
using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.UserModels.Properties;
using Wizards.Core.Model.WorldModels;

namespace Wizards.Repository.GameDataManagement.Uploaders;

public class GameDataUploader : IGameDataUploader
{
    private readonly ISkillRepository _skillRepository;
    private readonly IItemRepository _itemRepository;
    private readonly IEnemyRepository _enemyRepository;
    private readonly IHeroRepository _heroRepository;

    public GameDataUploader(
        ISkillRepository skillRepository, IItemRepository itemRepository,
        IEnemyRepository enemyRepository, IHeroRepository heroRepository)
    {
        _skillRepository = skillRepository;
        _itemRepository = itemRepository;
        _enemyRepository = enemyRepository;
        _heroRepository = heroRepository;
    }

    public async Task AddOrUpdateSkillsFromFileAsync(bool forceUpdate = false)
    {
        var path = Path.Combine(Environment.CurrentDirectory, "..", "Wizards.Repository", "GameDataManagement", "JSON", "Skills.json");
        
        if (IsUpToDate(path) && !forceUpdate)
        {
            return;
        }

        var skills = ReadJsonDataFile<List<Skill>>(path).OrderBy(s => s.Id).ToList();

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

        SetUpToDate(path);
    }

    public async Task AddOrUpdateItemsFromFileAsync(bool forceUpdate = false)
    {
        var path = Path.Combine(Environment.CurrentDirectory, "..", "Wizards.Repository", "GameDataManagement", "JSON", "Items.json");
        if (IsUpToDate(path) && !forceUpdate)
        {
            return;
        }

        var items = ReadJsonDataFile<List<Item>>(path).OrderBy(i => i.Id).ToList();

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

        SetUpToDate(path);
    }

    public async Task AddOrUpdateEnemiesFromFileAsync(bool forceUpdate = false)
    {
        var path = Path.Combine(Environment.CurrentDirectory, "..", "Wizards.Repository", "GameDataManagement", "JSON", "Enemies.json");
        if (IsUpToDate(path) && !forceUpdate)
        {
            return;
        }

        var enemies = ReadJsonDataFile<List<Enemy>>(path).OrderBy(e => e.Id).ToList();

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
                enemyToUpdate.EnemyStageName = enemy.EnemyStageName;
                enemyToUpdate.StageBackgroundImageNumber = enemy.StageBackgroundImageNumber;
                enemyToUpdate.TrainingEnemy = enemy.TrainingEnemy;
                enemyToUpdate.GoldReward = enemy.GoldReward;
                enemyToUpdate.RankPointsReward = enemy.RankPointsReward;

                UpdateEnemyAttributes(enemyToUpdate, enemy);
                AddOrUpdateEnemySkills(enemy, enemyToUpdate);
                AddOrUpdateBehaviorPatterns(enemy, enemyToUpdate);

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
        
        SetUpToDate(path);
    }

    public async Task UpdateHeroAttributes(bool balanceOrFixUpdate, bool resetDailyRewards = true)
    {
        var path = Path.Combine(Environment.CurrentDirectory, "..", "Wizards.Repository", "GameDataManagement", "JSON", "CoreAttributes.json");

        var attributes = ReadJsonDataFile<List<HeroAttributes>>(path).OrderBy(e => e.Id).ToList();

        var heroes = await _heroRepository.GetAll();

        foreach (var hero in heroes)
        {
            var heroAttributes = attributes.SingleOrDefault(a => a.Id == (int)hero.Profession);

            if (heroAttributes == null)
            {
                break;
            }

            if (resetDailyRewards)
            {
                hero.Attributes.DailyRewardEnergy = heroAttributes.DailyRewardEnergy;
            }

            if (balanceOrFixUpdate)
            {
                hero.Attributes.Damage = heroAttributes.Damage;
                hero.Attributes.Precision = heroAttributes.Precision;
                hero.Attributes.Specialization = heroAttributes.Specialization;

                hero.Attributes.MaxHealth = heroAttributes.MaxHealth;
                hero.Attributes.Reflex = heroAttributes.Reflex;
                hero.Attributes.Defense = heroAttributes.Defense;
            }

            await _heroRepository.Update(hero);
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

    private static void AddOrUpdateEnemySkills(Enemy enemy, Enemy enemyToUpdate)
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

    private static void AddOrUpdateBehaviorPatterns(Enemy enemy, Enemy enemyToUpdate)
    {
        foreach (var behaviorPattern in enemy.BehaviorPatterns)
        {
            if (enemyToUpdate.BehaviorPatterns.Any(bp => bp.Id == behaviorPattern.Id))
            {
                var behaviorPatternToUpdate =
                    enemyToUpdate.BehaviorPatterns.SingleOrDefault(bp => bp.Id == behaviorPattern.Id);

                behaviorPatternToUpdate.MaxHealthPercentToTrigger = behaviorPattern.MaxHealthPercentToTrigger;
                behaviorPatternToUpdate.MinHealthPercentToTrigger = behaviorPattern.MinHealthPercentToTrigger;
                behaviorPatternToUpdate.SequenceOfSkillsId = behaviorPattern.SequenceOfSkillsId;
            }
            else
            {
                enemyToUpdate.BehaviorPatterns.Add(behaviorPattern);
            }
        }
    }

    private static T ReadJsonDataFile<T>(string path)
    {
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "[]");
        }

        try
        {
            var deserializedObjects = JsonSerializer.Deserialize<T>(File.ReadAllText(path));
            return deserializedObjects;
        }
        catch (Exception)
        {
            throw new FileLoadException("Invalid File Format!");
        }
    }

    private bool IsUpToDate(string path)
    {
        var evidenceFilePath = Path.Combine(Environment.CurrentDirectory, "..", "Wizards.Repository", "GameDataManagement", "JSON", "FilesEvidence.json");

        if (!File.Exists(evidenceFilePath) || !File.Exists(path))
        {
            return false;
        }

        var fileInformation = ReadJsonDataFile<List<FileInformation>>(evidenceFilePath).SingleOrDefault(f => f.FileName == Path.GetFileNameWithoutExtension(path));

        var realFileModifyData = File.GetLastWriteTimeUtc(path);

        if (fileInformation != null && fileInformation.LastUpdate >= realFileModifyData)
        {
            return true;
        }

        return false;
    }

    private void SetUpToDate(string path)
    {
        var evidenceFilePath = Path.Combine(Environment.CurrentDirectory, "..", "Wizards.Repository", "GameDataManagement", "JSON", "FilesEvidence.json");
        var filesInformation = ReadJsonDataFile<List<FileInformation>>(evidenceFilePath);

        var realFileModifyData = File.GetLastWriteTimeUtc(path);

        var fileInformation = filesInformation.SingleOrDefault(f => f.FileName == Path.GetFileNameWithoutExtension(path));

        if (fileInformation == null)
        {
            var newInfo = new FileInformation()
            {
                FileName = Path.GetFileNameWithoutExtension(path),
                LastUpdate = realFileModifyData
            };

            filesInformation.Add(newInfo);
        }
        else
        {
            fileInformation.LastUpdate = realFileModifyData;
        }

        var json = JsonSerializer.Serialize(filesInformation);

        File.WriteAllText(evidenceFilePath, json);
    }
}