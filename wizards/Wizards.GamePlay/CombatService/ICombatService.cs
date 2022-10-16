using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Properties;

namespace Wizards.GamePlay.CombatService;

public interface ICombatService
{
    Task<RoundResult> CalculateRoundAsync(CombatStage stage);
}