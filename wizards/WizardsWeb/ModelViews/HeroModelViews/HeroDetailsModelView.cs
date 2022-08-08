using WizardsWeb.ModelViews.Properties;

namespace WizardsWeb.ModelViews;

public class HeroDetailsModelView
{
    public HeroBasicsModelView Basics { get; set; }
    public StatisticsModelView Statistics { get; set; }
    public HeroAttributesModelView Attributes { get; set; }

    public HeroDetailsModelView() { }

}