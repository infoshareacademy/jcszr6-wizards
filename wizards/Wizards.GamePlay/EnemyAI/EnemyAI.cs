using Wizards.Core.Model.WorldModels;

namespace Wizards.GamePlay.EnemiesAI;

public class EnemyAI : IEnemyAI
{
    public Task<int> GetEnemySelectedSkillIdAsync(CombatStage stage)
    {
        // TODO: Wyciągnąć Enemy z CombatStage

        // TODO: Wyciągamy Patterny z Enemy

        // TODO: Pobierz poziom życa Enemy

        // TODO: Wybrać Patern Pasujący do poziomu (procentowego) życia Enemy

        // TODO: Pobrać Numer Patternu z CombatStage'a użytego w poprzedniej rundzie

        // Jeśli patterny są różne to bierze pierwszy skill z nowego patternu

        // TODO: Pobrać kolejność skilla z CombatStage'a użytego w poprzedniej rundzie

        // Jeśli kolejność skilla z poprzedniej rundy jest maxem z patternu to bierze pierwszy skill z obecnego patternu

        // W przeciwnym wypadku Bierze następny skill z obecnego patternu

        throw new NotImplementedException();
    }
}