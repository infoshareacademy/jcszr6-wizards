using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizards.BusinessLogic.Model.Items
{
    internal class LightArmor : Item
    {
        public int DefenceIncrease { get; set; }
        public int ItemEndurance { get; set; }
        public int RepairCostPerEndurance { get; set; }

        public LightArmor(int id, string name, int buyPrice, int sellPrice, int defenceIncrease)
        {
            base.Id = id;
            base.Name = name;
            base.BuyPrice = buyPrice;
            base.SellPrice = sellPrice;
            this.DefenceIncrease = defenceIncrease;
            this.ItemEndurance = 100;
            this.RepairCostPerEndurance = (int)Math.Round(BuyPrice/100.0);
        }

        public LightArmor()
        {
            
        }
    }
}
