namespace Wizards.Core.Model;

public class Statistics
{
    public int Id { get; set; }
    public int RankPoints { get; set; }
    public int TotalMatchPlayed { get; set; }
    public int TotalMatchWin { get; set; }
    public int TotalMatchLoose { get; set; }
    public Hero Hero { get; set; }

}