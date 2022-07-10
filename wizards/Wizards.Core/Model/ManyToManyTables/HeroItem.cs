namespace Wizards.Core.Model.ManyToManyTables;

public class HeroItem
{
    public int Id { get; set; }
    public int HeroId { get; set; }
    public Hero Hero { get; set; }
    public int ItemId { get; set; }
    public Item Item { get; set; }
    public bool InUse { get; set; }


}