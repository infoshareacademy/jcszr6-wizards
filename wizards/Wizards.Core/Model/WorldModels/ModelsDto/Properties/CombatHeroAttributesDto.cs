namespace Wizards.Core.Model.WorldModels.ModelsDto.Properties;

public class CombatHeroAttributesDto
{
    // Offensive
    public int Damage { get; set; }
    public int Precision { get; set; }
    public int Specialization { get; set; }

    // Defensive
    public int MaxHealth { get; set; }
    public int Reflex { get; set; }
    public int Defense { get; set; }
}