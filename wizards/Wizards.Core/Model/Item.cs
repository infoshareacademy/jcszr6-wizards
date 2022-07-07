using Wizards.Core.Model.Enums;

namespace Wizards.Core.Model
{
    public class Item
    {
        // General Info

        public int Id { get; set; }
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public ProfessionRestriction Restriction { get; set; }

        public ItemAttributes Attributes { get; set; }
        public int AttributesId { get; set; }

        // Economic
        public int BuyPrice { get; set; }
        public int SellPrice { get; set; }
        
        public List<Hero> Heroes { get; set; }

    }
}
