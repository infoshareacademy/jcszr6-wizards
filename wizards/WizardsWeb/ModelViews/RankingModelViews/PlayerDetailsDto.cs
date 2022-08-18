using System.ComponentModel.DataAnnotations;

namespace WizardsWeb.ModelViews.RankingModelViews;
public class PlayerDetailsDto
{
    [Display(Name ="User Name")]
    public string UserName { get; set; }
    [Display(Name = "Email")]
    public string Email { get; set; }
    [Display(Name = "Hero's Count")]
    public int HeroNumber { get; set; }
    [Display(Name = "Rank Points")]
    public int RankNumber { get; set; }
    [Display(Name = "Total Gold")]
    public int GoldHeroNumber { get; set; }
}