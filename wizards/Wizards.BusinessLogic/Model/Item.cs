using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizards.BusinessLogic
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BuyPrice { get; set; }
        public int SellPrice { get; set; }

        public Item(int id, string name, int buyPrice, int sellPrice)
        {
            this.Id = id;
            this.Name = name;
            this.BuyPrice = buyPrice;
            this.SellPrice = sellPrice;
        }

        public Item()
        {
            
        }
    }
}
