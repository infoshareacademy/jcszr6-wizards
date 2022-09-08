using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Properties;
using Wizards.GamePlay.CombatService;

namespace Wizards.GamePlay.StageService;

public class StageService : IStageService
{
    public async Task<CombatStage> CreateNewMatchAsync(int playerId, int enemyId)
    {
        // TODO: Wykorzystać pomocniczą fabrykę i uzyskać od niej "wyprodukowanego" nową instancję CombatStage'a.

        // TODO: Przygotować pierwszą akcję Enemy przy pomocy EnemyAI!
        // TODO: Dodać otrzymany stage do jego repozytorium przypisując go do konkretnego PlayerId (które już przyjmujemy w metodzie)
        
        // TODO: Zwrócić nowo utworzony stage!

        throw new NotImplementedException();
    }

    public Task<RoundResult> CommitRoundAsync(int playerId, int selectedSkillId)
    {
        // TODO: Należy zwrócic się do repozytorium po CombatStage przypisany do gracza o Id = playerId
        // TODO: Obliczyc rezultat rundy przy pomocy Combat Serwisu;
        //
        // TODO: Trzeba wprowadzić rezultat rundy do obecnego stanu stage'a:
        // - Odebrać obu uczestnikom punkty życia które utracili w skutek ataków (uwaga żeby nikomu nie spadło poniżej 0!!!);
        // - Ustawić ich status na następną rundę: (czy są zestunowani ...)
        // - Dodać obu uczestnikom punkty życia, które odzyskali w skutek leczenia.
        // - Dodać stopień uszkodzenia broni i zbroi (obliczony przez pomocniczny serwisik który robi to na podstawie RoundResult'u).
        //
        // TODO: Trzeba sprawdzić czy walka się zakończyła. (czy ktoś ma 0 CurrentHealth).
        // Jeśli nie to:
        // TODO: Należy przy pomocy EnemyAI ustalić następną akcję przeciwnika.
        // Jeśli tak to:
        // TODO: Ustawić na Stage'u status "ConcludedHeroWins" lub "ConcludedEnemyWins" zależnie od tego kto wygrał (kto ma jeszcze punkty życia).
        // Uwaga może pojawić się sytuacja w której obaj uczestnicy mają 0 punktów życia. W takim przypadku mecz jest rostrzygany jako wygrana gracza,
        // a jego Healt jest ustawiany na 1 punkt życia (tak zwany cios ostatniej szansy).
        // 
        // TODO: Obliczony rezultat przekazać do ResultLogService żeby otrzymać log z rundy.
        // TODO: Otrzymanemu logowi trzeba nadać numer rundy (na podstawie już zawartych logów w stage'u) i dodać nowy log do listy w stage'u

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