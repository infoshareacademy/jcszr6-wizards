using System.Collections.Generic;
using Wizards.Core.Model.WorldModels.Enums;
using Wizards.Core.Model.WorldModels.Properties;
using Wizards.GamePlay.CombatService;

namespace WizardsWeb.ModelViews.ExplorationModelViews;

public class BattleStageModelView
{
    // CombatHero z CombatStage
    public HeroSection HeroSection { get; set; }
    
    // Enemy z CombatStage
    public EnemySection EnemySection { get; set; }

    // Last RoundResult
    public RoundResult LastRoundResult { get; set; }

    // Pozostałe elementy z CombatStage
    public string Name { get; set; }
    public StageStatus Status { get; set; }
    public bool IsTraining { get; set; }

    public List<RoundLog> RoundLogs { get; set; }

    // Pole dla formularza
    public int HeroSelectedSkillId { get; set; }
}