using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizards.BusinessLogic.Model.Items
{
    public class Weapon : Item
    {
        public int AttackIncrease { get; set; }
        public int ItemEndurance { get; set; }
        public int RepairCostPerEndurance { get; set; }

        public Weapon(int id, string name, int buyPrice, int sellPrice, int attackIncrease)
        {
            base.Id = id;
            base.Name = name;
            base.BuyPrice = buyPrice;
            base.SellPrice = sellPrice;
            this.AttackIncrease = attackIncrease;
            this.ItemEndurance = 100;
            this.RepairCostPerEndurance = (int)Math.Round(BuyPrice / 100.0);
        }

        public Weapon()
        {
            
        }
    }
}
