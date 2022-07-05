

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
        public int Damage { get; set; }
        public int Precision { get; set; }
        public int Specialization { get; set; }

        // Defensive
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int Reflex { get; set; }
        public int Defense { get; set; }

        // Economic
        public int BuyPrice { get; set; }
        public int SellPrice { get; set; }


        public List<Hero> Heroes { get; set; }

        public Item()
        {

        }
    }
}
