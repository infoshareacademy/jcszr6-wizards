using System.ComponentModel.DataAnnotations;
using Wizards.Core.Model;

namespace WizardsWeb.ModelViews.Properties;

public class StatisticsModelView
{
    public int Id { get; set; }

    [Display(Name = "Rank Points")]
    public int RankPoints { get; set; }

    [Display(Name = "Total match played")]
    public int TotalMatchPlayed { get; set; }

    [Display(Name = "Total match won")]
    public int TotalMatchWin { get; set; }

    [Display(Name = "Total match lost")]
    public int TotalMatchLoose { get; set; }

    [Display(Name = "Win rate")]
    public string WinRatio => GetWinRatio();

    public StatisticsModelView() { }

    private string GetWinRatio()
    {
        float winRatio = 0f;

        if (TotalMatchPlayed > 0)
        {
            winRatio = (float)((float)TotalMatchWin / (float)TotalMatchPlayed);
        }

        return $"{winRatio:P}";
    }
}