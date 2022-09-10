using Wizards.Core.Interfaces.UserModelInterfaces;
using Wizards.Core.Interfaces.WorldModelInterfaces;
using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Enums;
using Wizards.Core.Model.WorldModels.Properties;
using Wizards.Core.Model.WorldModels.Properties.Enums;
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

    public async Task CreateNewMatchAsync(int playerId, int enemyId, bool isTraining)
    {
        var player = await _playerRepository.Get(playerId);

        if (player == null)
        {
            throw new NullReferenceException($"There is no player with id: {playerId}");
        }

        var heroId = player.ActiveHeroId;
        var combatStage = await _combatStageFactory.CreateCombatStageAsync(heroId, enemyId, isTraining);

        await _enemyAI.SelectNextEnemyActionAsync(combatStage);

        await _combatStageRepository.AddAsync(combatStage, playerId);

        combatStage.Status = StageStatus.DuringCombat;
    }

    public async Task CommitRoundAsync(int playerId, int selectedSkillId)
    {
        var combatStage = await _combatStageRepository.GetAsync(playerId);
        var roundResult = await _combatService.CalculateRoundAsync(combatStage);

        SubtractHeroHealth(combatStage, roundResult);
        SubtractEnemyHealth(combatStage, roundResult);

        combatStage.CombatHero.IsHeroStunned = roundResult.HeroWillBeStunned;
        combatStage.CombatEnemy.IsEnemyStunned = roundResult.EnemyWillBeStunned;

        RecoverHeroHealth(combatStage, roundResult);
        RecoverEnemyHealth(combatStage, roundResult);
        LastChanceHitMechanic(combatStage);

        var armorDamage = CalculateArmorDamage(roundResult.EnemyCombatStatus == EnemyCombatStatus.MissesAttack);
        var weaponDamage = CalculateWeaponDamage(roundResult.EnemyCombatStatus == EnemyCombatStatus.MissesAttack);
        combatStage.CombatHero.ArmorUsage += armorDamage;
        combatStage.CombatHero.WeaponUsage += weaponDamage;

        SetNewStageStatus(combatStage);

        await _enemyAI.SelectNextEnemyActionAsync(combatStage);

        await AddResultLog(roundResult, combatStage);

        combatStage.LastRoundResult = roundResult;
    }

    public async Task FinishMatchAsync(int playerId)
    {
        var combatStage = await _combatStageRepository.GetAsync(playerId);
        var hero = await _heroRepository.Get(combatStage.CombatHero.Id);

        
        GiveHeroReward(hero, combatStage);

        if (!combatStage.IsTraining)
        {
            DamageHeroEquipment(combatStage, hero);
        }
        
        if (hero.Attributes.DailyRewardEnergy > 0 && !combatStage.IsTraining)
        {
            hero.Attributes.DailyRewardEnergy -= 1;
        }

        await _heroRepository.Update(hero);

        combatStage.Status = StageStatus.ReadyToClose;
        await _combatStageRepository.RemoveAsync(playerId);
    }

    private static void DamageHeroEquipment(CombatStage combatStage, Hero hero)
    {
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
        
        if (combatStage.Status == StageStatus.DuringCombat)
        {
            heroArmorUsage *= 4;
            heroWeaponUsage *= 4;
        }

        if (heroWeapon.ItemEndurance - heroWeaponUsage <= 0)
        {
            heroWeapon.ItemEndurance = 0;
        }
        else
        {
            heroWeapon.ItemEndurance -= heroWeaponUsage;
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

    private static void GiveHeroReward(Hero? hero, CombatStage combatStage)
    {
        if (hero.Attributes.DailyRewardEnergy > 0 && !combatStage.IsTraining && combatStage.Status == StageStatus.ConcludedHeroWins)
        {
            hero.Gold += combatStage.CombatEnemy.GoldReward;
        }
    }

    private async Task AddResultLog(RoundResult roundResult, CombatStage combatStage)
    {
        var resultLog = await _resultLogService.CreateRoundLogAsync(roundResult);

        var numberRound = combatStage.RoundLogs.Count + 1;

        resultLog.RoundNumber = numberRound;

        combatStage.RoundLogs.Add(resultLog);
    }

    private static void SetNewStageStatus(CombatStage combatStage)
    {
        if (combatStage.CombatEnemy.CurrentEnemyHealth == 0)
        {
            combatStage.Status = StageStatus.ConcludedHeroWins;
        }
        else if (combatStage.CombatHero.CurrentHeroHealth == 0)
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
        if (combatStage.CombatEnemy.CurrentEnemyHealth == 0 && combatStage.CombatHero.CurrentHeroHealth == 0)
        {
            combatStage.CombatHero.CurrentHeroHealth = 1;
        }
    }

    private static void RecoverHeroHealth(CombatStage combatStage, RoundResult roundResult)
    {
        var currentHealth = combatStage.CombatHero.CurrentHeroHealth;
        var maxHealth = combatStage.CombatHero.Attributes.MaxHealth;

        if (currentHealth + roundResult.HeroHealthRecovered > maxHealth)
        {
            combatStage.CombatHero.CurrentHeroHealth = maxHealth;
        }

        combatStage.CombatHero.CurrentHeroHealth += roundResult.HeroHealthRecovered;
    }

    private static void RecoverEnemyHealth(CombatStage combatStage, RoundResult roundResult)
    {
        var currentHealth = combatStage.CombatEnemy.CurrentEnemyHealth;
        var maxHealth = combatStage.CombatEnemy.Attributes.MaxHealth;

        if (currentHealth + roundResult.EnemyHealthRecovered > maxHealth)
        {
            combatStage.CombatEnemy.CurrentEnemyHealth = maxHealth;
        }

        combatStage.CombatEnemy.CurrentEnemyHealth += roundResult.EnemyHealthRecovered;
    }

    private static void SubtractHeroHealth(CombatStage combatStage, RoundResult roundResult)
    {
        var currentHealth = combatStage.CombatHero.CurrentHeroHealth;

        if (currentHealth - roundResult.HeroDamageTaken <= 0)
        {
            combatStage.CombatHero.CurrentHeroHealth = 0;
        }

        combatStage.CombatHero.CurrentHeroHealth -= roundResult.HeroDamageTaken;
    }

    private static void SubtractEnemyHealth(CombatStage combatStage, RoundResult roundResult)
    {
        var currentHealth = combatStage.CombatEnemy.CurrentEnemyHealth;

        if (currentHealth - roundResult.EnemyDamageTaken <= 0)
        {
            combatStage.CombatEnemy.CurrentEnemyHealth = 0;
        }

        combatStage.CombatEnemy.CurrentEnemyHealth -= roundResult.EnemyDamageTaken;
    }

    private double CalculateWeaponDamage(bool heroMissedAttack)
    {
        if (!heroMissedAttack)
        {
            return 0.05;
        }
        else
        {
            return 0.1;
        };
    }

    private double CalculateArmorDamage(bool enemyMissedAttack)
    {
        if (!enemyMissedAttack)
        {
            return 0.1;
        }
        else
        {
            return 0;
        }
    }
}