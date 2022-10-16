using Wizards.Core.Model.WorldModels.Enums;
using Wizards.Core.Model.WorldModels.ModelsDto;
using Wizards.Core.Model.WorldModels.Properties;

namespace Wizards.Core.Model.WorldModels;

public class CombatStage
{
    // General
    public string Name { get; set; }
    public StageStatus Status { get; set; }
    public bool IsTraining { get; set; }
    public int BackgroundImageNumber { get; set; }

    // Actual Hero status in Combat
    public CombatHeroDto CombatHero { get; set; }


    // Actual Enemy status in combat
    public CombatEnemyDto CombatEnemy { get; set; }

    // Rounds information
    public List<RoundLog> RoundLogs { get; set; }

    public RoundResult LastRoundResult { get; set; }
}