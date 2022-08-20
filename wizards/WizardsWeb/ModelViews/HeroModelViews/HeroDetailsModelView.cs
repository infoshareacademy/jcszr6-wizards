using WizardsWeb.ModelViews.HeroModelViews.Properties;

namespace WizardsWeb.ModelViews.HeroModelViews;

public class HeroDetailsModelView
{
    public HeroBasicsModelView Basics { get; set; }
    public HeroSummaryModelView Summary { get; set; }
    public StatisticsModelView Statistics { get; set; }
    public HeroAttributesModelView Attributes { get; set; }
}