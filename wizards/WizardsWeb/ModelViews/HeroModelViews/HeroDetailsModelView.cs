using Wizards.Core.Model;
using Wizards.Core.Model.Enums;
using WizardsWeb.ModelViews.Properties;

namespace WizardsWeb.ModelViews;

public class HeroDetailsModelView
{
    public int Id { get; set; }
    public HeroBasicsModelView Basics { get; set; }
    public int Gold { get; set; }
    public StatisticsModelView Statistics { get; set; }
    public HeroAttributesModelView Attributes { get; set; }

    public HeroDetailsModelView() { }

}