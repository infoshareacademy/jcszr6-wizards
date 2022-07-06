using Wizards.Core.Model.Enums;

namespace Wizards.Core.Model
{
    public class Hero
    {
        // General Info
        public int Id { get; set; }
        public string NickName { get; set; }
        public HeroProfession Profession { get; set; }
        public int AvatarImageNumber { get; set; }

        // Battle Attributes
        public int DailyRewardEnergy { get; set; }

        // Offensive
        public int Damage { get; set; }
        public int Precision { get; set; }
        public int Specialization { get; set; }

        // Defensive
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int Reflex { get; set; }
        public int Defense { get; set; }

        // Economic
        public int Gold { get; set; }

        public List<Item> Inventory = new();

        // Hero Statistics
        public int RankPoints { get; set; }
        public int TotalMatchPlayed { get; set; }
        public int TotalMatchWin { get; set; }
        public int TotalMatchLoose { get; set; }

        public Hero()
        {

        }
    }
}
