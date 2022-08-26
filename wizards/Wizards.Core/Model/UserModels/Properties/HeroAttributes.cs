namespace Wizards.Core.Model.UserModels.Properties;

public class HeroAttributes
{
    // General
    public int Id { get; set; }
 
    public int DailyRewardEnergy { get; set; }

    // Offensive
    public int Damage { get; set; }
    public int Precision { get; set; }
    public int Specialization { get; set; }

    // Defensive
    public int MaxHealth { get; set; }
    public int Reflex { get; set; }
    public int Defense { get; set; }

    // Db relations properties
    public Hero Hero { get; set; }
}