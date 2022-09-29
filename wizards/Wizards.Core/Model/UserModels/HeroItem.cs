namespace Wizards.Core.Model.UserModels;

public class HeroItem
{
    //General
    public int Id { get; set; }

    // Owner usage info
    public bool InUse { get; set; }
    public double ItemEndurance { get; set; }

    // Db relations properties
    public int HeroId { get; set; }
    public Hero Hero { get; set; }
    
    public int ItemId { get; set; }
    public Item Item { get; set; }
}