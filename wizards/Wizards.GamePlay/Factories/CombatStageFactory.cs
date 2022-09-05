using Wizards.Core.Model.WorldModels;

namespace Wizards.GamePlay.Factories;

public class CombatStageFactory : ICombatStageFactory
{
    public async Task<CombatStage> CreateCombatStageAsync(int heroId, int enemyId, bool isTraining)
    {
        // TODO: Tworzymy nową pustą instancję CombatStage.
        // TODO: Znajdujemy Hero i Enemy w bazie danych przy pomocy HeroRepository oraz EnemyRepository
        // TODO: Mapujemy i wstawiamy uczestników na arenę
        // TODO: Wypełniamy pozostałe pola areny odpowiednimi danymi (nazwa areny, czy jest reningiem itp...)

        // TODO: Zwracamy przygotowaną arenę!

        throw new NotImplementedException();
    }
}