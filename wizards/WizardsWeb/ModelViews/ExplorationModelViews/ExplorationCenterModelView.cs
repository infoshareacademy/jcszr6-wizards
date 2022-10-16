using System.Collections.Generic;
using WizardsWeb.ModelViews.HeroModelViews.Properties;

namespace WizardsWeb.ModelViews.ExplorationModelViews;

public class ExplorationCenterModelView
{
    public HeroSummaryModelView HeroSummary { get; set; }
    
    public List<EnemyIndexModelView> TierOneEnemies { get; set; }
    public List<EnemyIndexModelView> TierTwoEnemies { get; set; }
    public List<EnemyIndexModelView> TierThreeEnemies { get; set; }
    public List<EnemyIndexModelView> TierFourEnemies { get; set; }
    public List<EnemyIndexModelView> TierFiveEnemies { get; set; }
}