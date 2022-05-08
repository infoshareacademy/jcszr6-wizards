using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizards.BusinessLogic
{
    internal class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AttackIncrease { get; set; }
        public int DefenceIncrease { get;  set; }
        public int ItemEndurance { get; set; }

        public Item(int id, string name, int attack, int defence)
        {
            this.Id = id;
            this.Name = name;
            this.AttackIncrease = attack;
            this.DefenceIncrease = defence;
            this.ItemEndurance = 100;
        }

        public Item()
        {
            
        }
    }
}
