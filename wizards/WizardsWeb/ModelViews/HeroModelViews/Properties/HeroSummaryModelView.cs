using System.ComponentModel.DataAnnotations;

namespace WizardsWeb.ModelViews.HeroModelViews.Properties;

public class HeroSummaryModelView
{
    [Display(Name = "Item Tier: ")]
    public double HerosAvargeItemTier { get; set; }
    public int Gold { get; set; }
}