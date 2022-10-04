using System.ComponentModel.DataAnnotations;

namespace WizardsWeb.ModelViews.RankingModelViews;
public class PlayerDetailsDto
{
    [Display(Name = "Ranking Position")]
    public int RankingPosition { get; set; }
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
    [Display(Name = "Average Win Ratio")]
    public double PlayerWinRatio { get; set; }
    [Display(Name = "Total Match Played")]
    public double TotalMatchPlayed { get; set; }
    [Display(Name = "Max Item Tier")]
    public double MaxTier { get; set; }
    [Display(Name = "The Best Hero")]
    public string BestHero { get; set; }
}

