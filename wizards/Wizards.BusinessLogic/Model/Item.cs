

using System.Collections.Generic;

namespace Wizards.BusinessLogic
{
    public class Item
    {
        // General Info
        public int Id { get; set; }
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public ProfessionRestriction Restriction { get; set; }

        // Item Combat Attributes
        public double ItemEndurance { get; set; }

        // Offensive
        public int AttackPower { get; set; }
        public int MaxMagicEnergy { get; set; }
        public int CurrentMagicEnergy { get; set; }

        // Defensive
        public int Defense { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }

        // Economic
        public int BuyPrice { get; set; }
        public int SellPrice { get; set; }


        public List<Hero> Heroes { get; set; }

        public Item()
        {

        }
    }
}
