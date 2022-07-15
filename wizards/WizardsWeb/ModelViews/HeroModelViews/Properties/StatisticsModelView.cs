using System.ComponentModel.DataAnnotations;
using Wizards.Core.Model;

namespace WizardsWeb.ModelViews.Properties;

public class StatisticsModelView
{
    public int Id { get; set; }

    [DisplayFormat(DataFormatString = "{0:##,###}")]
    public int RankPoints { get; set; }
    
    [DisplayFormat(DataFormatString = "{0:##,###}")]
    public int TotalMatchPlayed { get; set; }
    
    [DisplayFormat(DataFormatString = "{0:##,###}")]
    public int TotalMatchWin { get; set; }

    [DisplayFormat(DataFormatString = "{0:##,###}")]
    public int TotalMatchLoose { get; set; }

    public StatisticsModelView(Statistics statistics)
    {
        Id = statistics.Id;
        RankPoints = statistics.RankPoints;
        TotalMatchPlayed = statistics.TotalMatchPlayed;
        TotalMatchWin = statistics.TotalMatchWin;
        TotalMatchLoose = statistics.TotalMatchLoose;
    }

    public string GetWinRatio()
    {
        float winRatio = 0f;

        if (TotalMatchPlayed > 0)
        {
            winRatio = (float)((float)TotalMatchWin / (float)TotalMatchPlayed);
        }

        return $"{winRatio:0.000}";
    }
}