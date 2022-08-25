namespace Wizards.Core.Model.UserModels.Properties;

public class Statistics
{
    public Hero Hero { get; set; }
    public int Id { get; set; }

    public int RankPoints { get; set; }
    public int TotalMatchPlayed { get; set; }
    public int TotalMatchWin { get; set; }
    public int TotalMatchLoose { get; set; }
}