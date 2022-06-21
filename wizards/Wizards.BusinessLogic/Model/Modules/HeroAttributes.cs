namespace Wizards.BusinessLogic
{
    public class HeroAttributes
    {
        // Offensive
        public int AttackPower { get; set; }
        public int MaxMagicEnergy { get; set; }
        public int CurrentMagicEnergy { get; set; }

        // Defensive
        public int Defense { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
    }
}