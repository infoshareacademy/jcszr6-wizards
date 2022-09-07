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

    public StageService(ICombatService combatService, ICombatStageFactory combatStageFactory, IPlayerRepository playerRepository,
        IEnemyAI enemyAI, ICombatStageInstancesRepository combatStageInstancesRepository, IResultLogService resultLogService)
    {
        _combatService = combatService;
        _combatStageFactory = combatStageFactory;
        _playerRepository = playerRepository;
        _enemyAI = enemyAI;
        _combatStageInstancesRepository = combatStageInstancesRepository;
        _resultLogService = resultLogService;
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
        // TODO: Należy zwrócic się do repozytorium po CombatStage przypisany do gracza o Id = playerId

        var combatStage = await _combatStageInstancesRepository.GetAsync(playerId);


        // TODO: Obliczyc rezultat rundy przy pomocy Combat Serwisu;

        var roundResult = await _combatService.CalculateRoundAsync(combatStage);


        //
        // TODO: Trzeba wprowadzić rezultat rundy do obecnego stanu stage'a:
        // - Odebrać obu uczestnikom punkty życia które utracili w skutek ataków (uwaga żeby nikomu nie spadło poniżej 0!!!);

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

        // - Ustawić ich status na następną rundę: (czy są zestunowani ...)

        combatStage.CombatHero.IsHeroStunned = roundResult.HeroWillBeStunned;
        combatStage.CombatEnemy.IsEnemyStunned = roundResult.EnemyWillBeStunned;


        // - Dodać obu uczestnikom punkty życia, które odzyskali w skutek leczenia.
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


        // - Dodać stopień uszkodzenia broni i zbroi (obliczony przez pomocniczny serwisik który robi to na podstawie RoundResult'u).

        var armorDamage = CalculateArmorDamage();
        var weaponDamage = CalculateWeaponDamage();

        combatStage.CombatHero.ArmorUsage += armorDamage;
        combatStage.CombatHero.WeaponUsage += weaponDamage;


        //
        // TODO: Trzeba sprawdzić czy walka się zakończyła. (czy ktoś ma 0 CurrentHealth).

        if (combatStage.CombatEnemy.CurrentEnemyHealth == 0 && combatStage.CombatHero.CurrentHeroHealth == 0)
        {
            combatStage.CombatHero.CurrentHeroHealth = 1;
        }
        
        if (combatStage.CombatEnemy.CurrentEnemyHealth == 0 )
        {
            combatStage.Status = StageStatus.ConcludedHeroWins;
        }

        else if (combatStage.CombatHero.CurrentHeroHealth == 0)
        {
            combatStage.Status = StageStatus.ConcludedEnemyWins;
        }

        await _enemyAI.GetEnemySelectedSkillIdAsync(combatStage);


        // Jeśli nie to:
        // TODO: Należy przy pomocy EnemyAI ustalić następną akcję przeciwnika.
        // Jeśli tak to:
        // TODO: Ustawić na Stage'u status "ConcludedHeroWins" lub "ConcludedEnemyWins" zależnie od tego kto wygrał (kto ma jeszcze punkty życia).
        // Uwaga może pojawić się sytuacja w której obaj uczestnicy mają 0 punktów życia. W takim przypadku mecz jest rostrzygany jako wygrana gracza,
        // a jego Healt jest ustawiany na 1 punkt życia (tak zwany cios ostatniej szansy).
        // 
        // TODO: Obliczony rezultat przekazać do ResultLogService żeby otrzymać log z rundy.

        var resultLog = await _resultLogService.CreateRoundLogAsync(roundResult); 


        // TODO: Otrzymanemu logowi trzeba nadać numer rundy (na podstawie już zawartych logów w stage'u) i dodać nowy log do listy w stage'u

        var numberRound = combatStage.RoundLogs.Count + 1;

        resultLog.RoundNumber = numberRound;

        combatStage.RoundLogs.Add(resultLog);

        throw new NotImplementedException();
    }

    private double CalculateWeaponDamage()
    {
        throw new NotImplementedException();
    }

    private double CalculateArmorDamage()
    {
        throw new NotImplementedException();
    }

    public async Task FinishMatchAsync(int playerId)
    {
        // TODO: Wręczenie nagród bohaterowi
        // Pobieramy nagrodę z enemy (najlepiej tego z bazy danych) i dodajemy ja do naszego Hero.
        // TODO: Uszkodzenie ekwipunku bohaterowi.
        // Tutaj zależnie od wyniku meczu albo psujemy ekwipunek tym co zostało naliczone (wygrana bohatera) albo naliczamy to podwójnie (przegrana).
        // TODO: Ustawiamy status areny na "ReadyToClose"
        // TODO: Usuwamy instancję CombatStage'a z repozytorium.

        throw new NotImplementedException();
    }
}