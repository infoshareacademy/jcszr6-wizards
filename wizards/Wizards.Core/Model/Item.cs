using Wizards.Core.Model.Enums;
using Wizards.Core.Model.ManyToManyTables;

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
        
        public List<HeroItem> Heroes { get; set; }

    }
}
