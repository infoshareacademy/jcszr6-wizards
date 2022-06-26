

namespace Wizards.BusinessLogic
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProfessionRestriction Restriction { get; set; }

        public int BuyPrice { get; set; }
        public int SellPrice { get; set; }

        public Item()
        {

        }
    }
}
