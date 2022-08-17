using System.ComponentModel.DataAnnotations;
using WizardsWeb.ModelViews.HeroModelViews.Properties;

namespace WizardsWeb.ModelViews.HeroModelViews;

public class HeroDeleteModelView
{
    public HeroBasicsModelView Basics { get; set; }
    public StatisticsModelView Statistics { get; set; }
    
    [Required(ErrorMessage = "You have to enter Nick Name to confirm delete!")]
    [Display(Name = "Enter Nick Name to confirm")]
    public string ConfirmNickName { get; set; }
}