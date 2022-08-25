namespace Wizards.Core.Model.WorldModels.Properties
{
    public class EnemyAttributes
    {
        public int Id { get; set; }
        public Enemy Enemy { get; set; }
        
        // Offensive
        public int Damage { get; set; }
        public int Precision { get; set; }
        public int Specialization { get; set; }

        // Defensive
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int Reflex { get; set; }
        public int Defense { get; set; }
    }
}
