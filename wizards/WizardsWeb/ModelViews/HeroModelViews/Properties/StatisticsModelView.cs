using System.ComponentModel.DataAnnotations;

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