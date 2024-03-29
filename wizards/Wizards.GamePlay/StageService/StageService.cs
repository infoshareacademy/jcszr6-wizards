using Wizards.Core.Interfaces.UserModelInterfaces;
using Wizards.Core.Interfaces.WorldModelInterfaces;
using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Enums;
using Wizards.Core.Model.WorldModels.Properties;
using Wizards.Core.Model.WorldModels.Properties.Enums;
using Wizards.Core.ModelExtensions;
using Wizards.GamePlay.CombatService;
using Wizards.GamePlay.EnemyAI;
using Wizards.GamePlay.Factories;
using Wizards.GamePlay.ResultLogService;

namespace Wizards.GamePlay.StageService;

public class StageService : IStageService
{
    private readonly ICombatStageFactory _combatStageFactory;
    private readonly ICombatService _combatService;
    private readonly IPlayerRepository _playerRepository;
    private readonly IEnemyAI _enemyAI;
    private readonly ICombatStageInstancesRepository _combatStageRepository;
    private readonly IResultLogService _resultLogService;
    private readonly IHeroRepository _heroRepository;

    public StageService(ICombatService combatService,
                        ICombatStageFactory combatStageFactory,
                        IPlayerRepository playerRepository,
                        IEnemyAI enemyAI,
                        ICombatStageInstancesRepository combatStageRepository,
                        IResultLogService resultLogService,
                        IHeroRepository heroRepository
                        )
    {
        _combatService = combatService;
        _combatStageFactory = combatStageFactory;
        _playerRepository = playerRepository;
        _enemyAI = enemyAI;
        _combatStageRepository = combatStageRepository;
        _resultLogService = resultLogService;
        _heroRepository = heroRepository;
    }

    public async Task CreateNewMatchAsync(int playerId, int enemyId)
    {
        var player = await _playerRepository.Get(playerId);

        if (player == null)
        {
            throw new NullReferenceException($"There is no player with id: {playerId}");
        }

        var heroId = player.ActiveHeroId;
        var combatStage = await _combatStageFactory.CreateCombatStageAsync(heroId, enemyId);

        await _enemyAI.SelectNextEnemyActionAsync(combatStage);

        SelectHeroFirstSkill(combatStage);

        await _combatStageRepository.AddAsync(combatStage, playerId);

        combatStage.Status = StageStatus.DuringCombat;
    }

    public async Task CommitRoundAsync(int playerId, int selectedSkillId)
    {
        var combatStage = await _combatStageRepository.GetAsync(playerId);
        combatStage.CombatHero.SelectedSkillId = selectedSkillId;
        combatStage.CombatHero.SelectedSkill = combatStage.CombatHero.GetHeroSelectedSkill();
        
        var roundResult = await _combatService.CalculateRoundAsync(combatStage);

        combatStage.CombatHero.IsStunned = roundResult.HeroWillBeStunned;
        combatStage.CombatEnemy.IsStunned = roundResult.EnemyWillBeStunned;

        RecoverHeroHealth(combatStage, roundResult);
        RecoverEnemyHealth(combatStage, roundResult);

        SubtractHeroHealth(combatStage, roundResult);
        SubtractEnemyHealth(combatStage, roundResult);
        
        LastChanceHitMechanic(combatStage);

        var armorDamage = CalculateArmorDamage(roundResult.EnemyCombatStatus == EnemyCombatStatus.MissesAttack);
        var weaponDamage = CalculateWeaponDamage(roundResult.EnemyCombatStatus == EnemyCombatStatus.MissesAttack);
        combatStage.CombatHero.ArmorUsage += armorDamage;
        combatStage.CombatHero.WeaponUsage += weaponDamage;

        SetNewStageStatus(combatStage);

        if (combatStage.CombatEnemy.CurrentHealth > 0)
        {
            await _enemyAI.SelectNextEnemyActionAsync(combatStage);
        }

        await AddResultLog(roundResult, combatStage);

        combatStage.LastRoundResult = roundResult;
    }

    public async Task FinishMatchAsync(int playerId)
    {
        var combatStage = await _combatStageRepository.GetAsync(playerId);
        var hero = await _heroRepository.Get(combatStage.CombatHero.Id);

        GiveHeroReward(hero, combatStage);
        UpdateHeroStatistics(hero, combatStage);

        DamageHeroEquipment(combatStage, hero);

        SubtractHeroRewardEnergy(hero, combatStage);

        await _heroRepository.Update(hero);

        combatStage.Status = StageStatus.ReadyToClose;
        await _combatStageRepository.RemoveAsync(playerId);
    }

    public async Task AbortMatchAsync(int playerId)
    {
        var combatStage = await _combatStageRepository.GetAsync(playerId);

        combatStage.Status = StageStatus.ConcludedEnemyWins;
        combatStage.CombatHero.CurrentHealth = 0;
    }

    private void SelectHeroFirstSkill(CombatStage combatStage)
    {
        var skills = combatStage.CombatHero.Skills;
        var skill = skills.MinBy(s => (int)s.SlotNumber);

        if (skill is null)
        {
            return;
        }

        combatStage.CombatHero.SelectedSkill = skill;
        combatStage.CombatHero.SelectedSkillId = skill.Id;
    }

    private void UpdateHeroStatistics(Hero hero, CombatStage combatStage)
    {
        if (combatStage.IsTraining)
        {
            return;
        }
        
        if (combatStage.Status == StageStatus.ConcludedHeroWins)
        {
            hero.Statistics.TotalMatchPlayed += 1;
            hero.Statistics.TotalMatchWin += 1;
        }

        if (combatStage.Status == StageStatus.ConcludedEnemyWins)
        {
            hero.Statistics.TotalMatchPlayed += 1;
            hero.Statistics.TotalMatchLoose += 1;
        }
    }

    private static void GiveHeroReward(Hero? hero, CombatStage combatStage)
    {
        if (hero.Attributes.DailyRewardEnergy > 0 && !combatStage.IsTraining && combatStage.Status == StageStatus.ConcludedHeroWins)
        {
            hero.Gold += combatStage.CombatEnemy.GoldReward;
            hero.Statistics.RankPoints += combatStage.CombatEnemy.RankPointsReward;
        }
    }

    private static void DamageHeroEquipment(CombatStage combatStage, Hero hero)
    {
        if (combatStage.IsTraining)
        {
            return;
        }

        var heroWeaponId = combatStage.CombatHero.EquippedWeaponId;
        var heroArmorId = combatStage.CombatHero.EquippedArmorId;

        var heroWeapon = hero.Inventory.SingleOrDefault(i => i.Id == heroWeaponId);
        var heroArmor = hero.Inventory.SingleOrDefault(a => a.Id == heroArmorId);

        var heroWeaponUsage = combatStage.CombatHero.WeaponUsage;
        var heroArmorUsage = combatStage.CombatHero.ArmorUsage;

        if (combatStage.Status == StageStatus.ConcludedEnemyWins)
        {
            heroArmorUsage *= 2;
            heroWeaponUsage *= 2;
        }
        
        if (heroWeapon is null)
        {
            return;
        }
        if (heroWeapon.ItemEndurance - heroWeaponUsage <= 0)
        {
            heroWeapon.ItemEndurance = 0;
        }
        else
        {
            heroWeapon.ItemEndurance -= heroWeaponUsage;
        }

        if (heroArmor is null)
        {
            return;
        }
        if (heroArmor.ItemEndurance - heroArmorUsage <= 0)
        {
            heroArmor.ItemEndurance = 0;
        }
        else
        {
            heroArmor.ItemEndurance -= heroArmorUsage;
        }
    }

    private static void SubtractHeroRewardEnergy(Hero? hero, CombatStage combatStage)
    {
        if (hero.Attributes.DailyRewardEnergy > 0 && !combatStage.IsTraining)
        {
            hero.Attributes.DailyRewardEnergy -= 1;
        }
    }

    private async Task AddResultLog(RoundResult roundResult, CombatStage combatStage)
    {
        var resultLog = await _resultLogService.CreateRoundLogAsync(roundResult);

        var numberRound = combatStage.RoundLogs.Count + 1;

        resultLog.RoundNumber = numberRound;

        combatStage.RoundLogs.Add(resultLog);
        combatStage.RoundLogs = combatStage.RoundLogs.OrderByDescending(x => x.RoundNumber).ToList();
    }

    private static void SetNewStageStatus(CombatStage combatStage)
    {
        if (combatStage.CombatEnemy.CurrentHealth == 0)
        {
            combatStage.Status = StageStatus.ConcludedHeroWins;
        }
        else if (combatStage.CombatHero.CurrentHealth == 0)
        {
            combatStage.Status = StageStatus.ConcludedEnemyWins;
        }
        else
        {
            combatStage.Status = StageStatus.DuringCombat;
        }
    }

    private static void LastChanceHitMechanic(CombatStage combatStage)
    {
        if (combatStage.CombatEnemy.CurrentHealth == 0 && combatStage.CombatHero.CurrentHealth == 0)
        {
            combatStage.CombatHero.CurrentHealth = 1;
        }
    }

    private static void RecoverHeroHealth(CombatStage combatStage, RoundResult roundResult)
    {
        var currentHealth = combatStage.CombatHero.CurrentHealth;
        var maxHealth = combatStage.CombatHero.Attributes.MaxHealth;

        if (currentHealth + roundResult.HeroHealthRecovered > maxHealth)
        {
            combatStage.CombatHero.CurrentHealth = maxHealth;
        }
        else
        {
            combatStage.CombatHero.CurrentHealth += roundResult.HeroHealthRecovered;
        }
    }

    private static void RecoverEnemyHealth(CombatStage combatStage, RoundResult roundResult)
    {
        var currentHealth = combatStage.CombatEnemy.CurrentHealth;
        var maxHealth = combatStage.CombatEnemy.Attributes.MaxHealth;

        if (currentHealth + roundResult.EnemyHealthRecovered > maxHealth)
        {
            combatStage.CombatEnemy.CurrentHealth = maxHealth;
        }
        else
        {
            combatStage.CombatEnemy.CurrentHealth += roundResult.EnemyHealthRecovered;
        }
    }

    private static void SubtractHeroHealth(CombatStage combatStage, RoundResult roundResult)
    {
        var currentHealth = combatStage.CombatHero.CurrentHealth;

        if (currentHealth - roundResult.HeroDamageTaken <= 0)
        {
            combatStage.CombatHero.CurrentHealth = 0;
        }
        else
        {
            combatStage.CombatHero.CurrentHealth -= roundResult.HeroDamageTaken;
        }
    }

    private static void SubtractEnemyHealth(CombatStage combatStage, RoundResult roundResult)
    {
        var currentHealth = combatStage.CombatEnemy.CurrentHealth;

        if (currentHealth - roundResult.EnemyDamageTaken <= 0)
        {
            combatStage.CombatEnemy.CurrentHealth = 0;
        }
        else
        {
            combatStage.CombatEnemy.CurrentHealth -= roundResult.EnemyDamageTaken;
        }
    }

    private double CalculateWeaponDamage(bool heroMissedAttack)
    {
        if (!heroMissedAttack)
        {
            return 0.020;
        }

        return 0.045;
    }

    private double CalculateArmorDamage(bool enemyMissedAttack)
    {
        if (!enemyMissedAttack)
        {
            return 0.035;
        }

        return 0;
    }
}