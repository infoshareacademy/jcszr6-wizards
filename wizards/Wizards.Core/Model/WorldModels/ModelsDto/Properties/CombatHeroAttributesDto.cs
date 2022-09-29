namespace Wizards.Core.Model.WorldModels.ModelsDto.Properties;

public class CombatHeroAttributesDto
{
    public int DailyRewardEnergy { get; set; }

    // Offensive
    public int Specialization { get; set; }

    // Defensive
    public int MaxHealth { get; set; }
    public int Reflex { get; set; }
    public int Defense { get; set; }
}