namespace Wizards.Core.Model.UserModels.Properties;

public class ItemAttributes
{
    // General
    public int Id { get; set; }

    // Offensive
    public int Damage { get; set; }
    public int Precision { get; set; }
    public int Specialization { get; set; }

    // Defensive
    public int MaxHealth { get; set; }
    public int Reflex { get; set; }
    public int Defense { get; set; }

    // Db relations properties
    public Item Item { get; set; }
}