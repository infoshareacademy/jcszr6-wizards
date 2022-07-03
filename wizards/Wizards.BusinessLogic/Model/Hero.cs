using System.Collections.Generic;

namespace Wizards.BusinessLogic
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
        public int AttackPower { get; set; }
        public int MaxMagicEnergy { get; set; }
        public int CurrentMagicEnergy { get; set; }

        // Defensive
        public int Defense { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }

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
