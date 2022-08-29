using Wizards.Core.Model.WorldModels;

namespace Wizards.GamePlay.CombatService;

public interface ICombatService
{
    Task<RoundResult> CalculateRoundAsync(CombatStage stage);
}