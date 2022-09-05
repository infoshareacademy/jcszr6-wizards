using Wizards.Core.Model.WorldModels;
using Wizards.GamePlay.CombatService;

namespace Wizards.GamePlay.StageService;

public class StageService : IStageService
{
    public async Task<CombatStage> CreateNewMatchAsync(int playerId, int enemyId)
    {
        // TODO: Zamiast przyjmować w argumencie CombatStage'a przyjmujemy PlayerId jako int
        // TODO: Zmienić metodę tak żeby zwracała obiekt typu CombatStage (nadal asynchronicznie)
        // Poprawić to też w interfejsie IStageService!

        // Ciało metody:
        // TODO: Wykorzystać pomocniczą fabrykę (do napisania) i uzyskać od niej "wyprodukowanego" CombatStage'a.
        // TODO: Pobrać hero z bazy danych (na podstawie Id przyjętego w metodzie).
        // TODO: Pobrać Enemy z bazy danych (na podstawie Id przyjętego w metodzie).
        // TODO: Wstawić obu uczestników na stage.

        // TODO: Dodać tak utworzony stage do jego repozytorium przypisując go do tego konkretnego PlayerId (które już przyjmujemy w metodzie)
        // TODO: Zwrócić nowo utworzony stage!

        throw new NotImplementedException();
    }

    public Task<RoundResult> CommitRoundAsync(CombatStage stage, int selectedSkillId)
    {
        // TODO: Obliczyc rezultat runy przy pomocy Combat Serwisu
        // TODO: Obliczony rezultat przekazać do ResultLogService żeby otrzymać log z rundy.
        // TODO: Otrzymanemu logowi trzeba nadać numer rundy (na podstawie już zawartych logów w stage'u)
        // TODO: Trzeba wprowadzić rezultat rundy do obecnego stanu stage'a:
        // - Odebrać obu uczestnikom punkty życia które utracili w skutek ataków;
        // - Ustawić ich status na następną rundę: (czy są zestunowani ...)
        // - Dodać obu uczestnikom punkty życia które odzyskali w skutek leczenia.
        // TODO: Trzeba "popsuć" ekwipunek gracza
        // - być może mały pomocniszy serwis albo metoda która zrobi to na podstawie obrażeń zadanych i otrzymanych. (Szczegóły Do ustalenia)
        //
        // TODO: Trzeba sprawdzić czy walka się zakończyła. (czy ktoś ma 0 Health).
        // Jeśli nie to:
        // TODO: Należy przy pomocy EnemyAI ustalić następną akcję przeciwnika.
        // Jeśli tak to:
        // TODO: Ustawić na Stage'u status "concluded".

        throw new NotImplementedException();
    }

    public async Task FinishMatchAsync(CombatStage stage)
    {
        throw new NotImplementedException();
    }
}