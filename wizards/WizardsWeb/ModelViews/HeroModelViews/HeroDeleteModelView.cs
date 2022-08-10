using System.ComponentModel.DataAnnotations;
using WizardsWeb.ModelViews.Properties;

namespace WizardsWeb.ModelViews;

public class HeroDeleteModelView
{
    public HeroBasicsModelView Basics { get; set; }
    public StatisticsModelView Statistics { get; set; }
    
    [Required(ErrorMessage = "You have to enter Nick Name to confirm delete!")]
    [Display(Name = "Enter Nick Name to confirm")]
    public string ConfirmNickName { get; set; }

    public HeroDeleteModelView() { }
}