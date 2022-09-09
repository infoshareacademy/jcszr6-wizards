using Wizards.Core.Interfaces.UserModelInterfaces;
using Wizards.Core.Interfaces.WorldModelInterfaces;
using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Enums;
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
    private readonly ICombatStageInstancesRepository _combatStageInstancesRepository;
    private readonly IResultLogService _resultLogService;
    private readonly IHeroRepository _heroRepository;

    public StageService(ICombatService combatService,
                        ICombatStageFactory combatStageFactory,
                        IPlayerRepository playerRepository,
                        IEnemyAI enemyAI,
                        ICombatStageInstancesRepository combatStageInstancesRepository,
                        IResultLogService resultLogService,
                        IHeroRepository heroRepository
                        )
    {
        _combatService = combatService;
        _combatStageFactory = combatStageFactory;
        _playerRepository = playerRepository;
        _enemyAI = enemyAI;
        _combatStageInstancesRepository = combatStageInstancesRepository;
        _resultLogService = resultLogService;
        _heroRepository = heroRepository;
    }
    public async Task<CombatStage> CreateNewMatchAsync(int playerId, int enemyId)
    {
        var player = await _playerRepository.Get(playerId);
        var heroId = player.ActiveHeroId;
        var combatStage = await _combatStageFactory.CreateCombatStageAsync(heroId, enemyId, false);

        await _enemyAI.GetEnemySelectedSkillIdAsync(combatStage);

        await _combatStageInstancesRepository.AddAsync(combatStage, playerId);

        combatStage.Status = StageStatus.DuringCombat;

        return combatStage;
    }

    public async Task<RoundResult> CommitRoundAsync(int playerId, int selectedSkillId)
    {

        var combatStage = await _combatStageInstancesRepository.GetAsync(playerId);

        var roundResult = await _combatService.CalculateRoundAsync(combatStage);

        combatStage.CombatHero.CurrentHeroHealth -= roundResult.HeroDamageTaken;

        if (combatStage.CombatHero.CurrentHeroHealth < 0)
        {
            combatStage.CombatHero.CurrentHeroHealth = 0;
        }

        combatStage.CombatEnemy.CurrentEnemyHealth -= roundResult.EnemyDamageTaken;

        if (combatStage.CombatEnemy.CurrentEnemyHealth < 0)
        {
            combatStage.CombatEnemy.CurrentEnemyHealth = 0;
        }

        combatStage.CombatHero.IsHeroStunned = roundResult.HeroWillBeStunned;
        combatStage.CombatEnemy.IsEnemyStunned = roundResult.EnemyWillBeStunned;

        combatStage.CombatHero.CurrentHeroHealth += roundResult.HeroHealthRecovered;
        if (combatStage.CombatHero.CurrentHeroHealth > combatStage.CombatHero.Attributes.MaxHealth)
        {
            combatStage.CombatHero.CurrentHeroHealth = combatStage.CombatHero.Attributes.MaxHealth;
        }

        combatStage.CombatEnemy.CurrentEnemyHealth += roundResult.EnemyHealthRecovered;
        if (combatStage.CombatEnemy.CurrentEnemyHealth > combatStage.CombatEnemy.Attributes.MaxHealth)
        {
            combatStage.CombatEnemy.CurrentEnemyHealth = combatStage.CombatEnemy.Attributes.MaxHealth;
        }

        var armorDamage = CalculateArmorDamage(roundResult.EnemyCombatStatus == CombatService.Enums.EnemyCombatStatus.MissesAttack);
        var weaponDamage = CalculateWeaponDamage(roundResult.EnemyCombatStatus == CombatService.Enums.EnemyCombatStatus.MissesAttack);

        combatStage.CombatHero.ArmorUsage += armorDamage;
        combatStage.CombatHero.WeaponUsage += weaponDamage;

        if (combatStage.CombatEnemy.CurrentEnemyHealth == 0 && combatStage.CombatHero.CurrentHeroHealth == 0)
        {
            combatStage.CombatHero.CurrentHeroHealth = 1;
        }

        if (combatStage.CombatEnemy.CurrentEnemyHealth == 0)
        {
            combatStage.Status = StageStatus.ConcludedHeroWins;
        }

        else if (combatStage.CombatHero.CurrentHeroHealth == 0)
        {
            combatStage.Status = StageStatus.ConcludedEnemyWins;
        }

        await _enemyAI.GetEnemySelectedSkillIdAsync(combatStage);

        var resultLog = await _resultLogService.CreateRoundLogAsync(roundResult);

        var numberRound = combatStage.RoundLogs.Count + 1;

        resultLog.RoundNumber = numberRound;

        combatStage.RoundLogs.Add(resultLog);

        throw new NotImplementedException();
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

    public async Task FinishMatchAsync(int playerId)
    {

        var combatStage = await _combatStageInstancesRepository.GetAsync(playerId);
        var hero = await _heroRepository.Get(combatStage.CombatHero.Id);
        if (combatStage.Status == StageStatus.ConcludedHeroWins)
        {
            if (hero.Attributes.DailyRewardEnergy > 0)
            {
                hero.Gold += combatStage.CombatEnemy.GoldReward;
            }
            var heroWeaponId = combatStage.CombatHero.EquippedWeaponId;
            var heroArmorId = combatStage.CombatHero.EquippedArmorId;

            var heroWeapon = hero.Inventory.SingleOrDefault(i => i.Id == heroWeaponId);
            var heroArmor = hero.Inventory.SingleOrDefault(a => a.Id == heroArmorId);

            heroWeapon.ItemEndurance -= combatStage.CombatHero.WeaponUsage;
            if (heroWeapon.ItemEndurance < 0)
            {
                heroWeapon.ItemEndurance = 0;
            }

            heroArmor.ItemEndurance -= combatStage.CombatHero.ArmorUsage;
            if (heroArmor.ItemEndurance < 0)
            {
                heroArmor.ItemEndurance = 0;
            }
        }
        else if (combatStage.Status == StageStatus.ConcludedEnemyWins)
        {
            var heroWeaponId = combatStage.CombatHero.EquippedWeaponId;
            var heroArmorId = combatStage.CombatHero.EquippedArmorId;

            var heroWeapon = hero.Inventory.SingleOrDefault(i => i.Id == heroWeaponId);
            var heroArmor = hero.Inventory.SingleOrDefault(a => a.Id == heroArmorId);

            heroWeapon.ItemEndurance -= combatStage.CombatHero.WeaponUsage * 2;
            if (heroWeapon.ItemEndurance < 0)
            {
                heroWeapon.ItemEndurance = 0;
            }

            heroArmor.ItemEndurance -= combatStage.CombatHero.ArmorUsage * 2;
            if (heroArmor.ItemEndurance < 0)
            {
                heroArmor.ItemEndurance = 0;
            }
        }
        else
        {
            var heroWeaponId = combatStage.CombatHero.EquippedWeaponId;
            var heroArmorId = combatStage.CombatHero.EquippedArmorId;

            var heroWeapon = hero.Inventory.SingleOrDefault(i => i.Id == heroWeaponId);
            var heroArmor = hero.Inventory.SingleOrDefault(a => a.Id == heroArmorId);

            heroWeapon.ItemEndurance -= combatStage.CombatHero.WeaponUsage * 4;
            if (heroWeapon.ItemEndurance < 0)
            {
                heroWeapon.ItemEndurance = 0;
            }

            heroArmor.ItemEndurance -= combatStage.CombatHero.ArmorUsage * 4;
            if (heroArmor.ItemEndurance < 0)
            {
                heroArmor.ItemEndurance = 0;
            }
        }


        if (hero.Attributes.DailyRewardEnergy > 0)
        {
            hero.Attributes.DailyRewardEnergy -= 1;
        }

        await _heroRepository.Update(hero);

        combatStage.Status = StageStatus.ReadyToClose;
        await _combatStageInstancesRepository.RemoveAsync(playerId);

    }
}