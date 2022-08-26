namespace Wizards.Core.Model.UserModels.Properties;

public class Statistics
{
    // General
    public int Id { get; set; }
    
    // Statistics
    public int RankPoints { get; set; }
    public int TotalMatchPlayed { get; set; }
    public int TotalMatchWin { get; set; }
    public int TotalMatchLoose { get; set; }

    // Db relations properties
    public Hero Hero { get; set; }
}