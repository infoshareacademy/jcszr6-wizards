using System.Collections.Generic;
using Wizards.Core.Model.WorldModels.Enums;
using Wizards.Core.Model.WorldModels.Properties;

namespace WizardsWeb.ModelViews.CombatModelViews;

public class CombatStageModelView
{
    // CombatHero z CombatStage
    public HeroSectionModelView HeroSection { get; set; }
    
    // Enemy z CombatStage
    public EnemySectionModelView EnemySection { get; set; }

    // Last RoundResult
    public RoundResult LastRoundResult { get; set; }
    public bool WasResultShown { get; set; }

    // Pozostałe elementy z CombatStage
    public string Name { get; set; }
    public StageStatus Status { get; set; }
    public bool IsTraining { get; set; }
    public int BackgroundImageNumber { get; set; }

    public List<RoundLog> RoundLogs { get; set; }

    // Pole dla formularza
    public int HeroSelectedSkillId { get; set; }
}