using Wizards.Core.Model.WorldModels.Properties;
using Wizards.GamePlay.CombatService;

namespace Wizards.GamePlay.ResultLogService;

public class ResultLogService : IResultLogService
{
    public Task<RoundLog> CreateRoundLogAsync(RoundResult roundResult)
    {
        // TODO: Najpierw trzeba ustalić koncepcję jak piszemy komunikat graczowi
        // [Kto] [co zrobił] [komu] [ile zadał obrażeń] ? czy tak czy inaczej?
        // Trzymamy sie konwencji czasu (albo cały czas przeszły albo cały czas teraźniejszy)

        // TODO: Wygenerować komunikat CO GRACZ ZROBIŁ ENEMY:

        // Czy Hero Był Zestunowany jesli tak to [cały komunika] ustawiamy na Hero is Stunned
        // Czy Skontrował przeciwnika? Jeśli tak to [co zrobił] ustawiamy na "Counters"
        // Czy Zablokował przeciwnika? Jeśli tak to [co zrobił] ustawiamy na "Blocks"
        // Jeśli nie trafił przeciwnika? To [co zrobił] ustawiamy na "Mishits"

        // Jeśli Trafił przeciwnika. To: [co zrobił] ustawiamy na 'hits' oraz [ile zadał obrażeń] ustawiamy na wartość obrażeń.


        // TODO: Wygenerować komunikat CO ENEMY ZROBIŁ GRACZOWI:

        // Czy Enemy Był Zestunowany. Jesli tak to [cały komunika] ustawiamy na Enemy is Stunned
        // Czy Enemy Był Zablokowany. Jesli tak to [cały komunika] ustawiamy na Enemy is Blocked
        // Czy Enemy Był Skontrowany. Jesli tak to [cały komunika] ustawiamy na Enemy is Contered
        // Jeśli nie trafił bohatera? To [co zrobił] ustawiamy na "Mishits"

        // Czy Enemy Trafił bohatera? Jeśli tak to [co zrobił] ustawiamy na 'hits' oraz [ile zadał obrażeń] ustawiamy na wartość obrażeń.


        throw new NotImplementedException();
    }
}