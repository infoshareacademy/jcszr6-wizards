using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wizards.BusinessLogic
{
    internal class Hero
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Gold { get; set; }
        public int RankPoints { get; set; }
        public List<Item> itemList = new List<Item>();
        
        public Hero(int id, string nick)
        {
            this.Id = id;
            this.NickName = nick;
            this.MaxHealth = 300;
            this.CurrentHealth = MaxHealth;
            this.Attack = 10;
            this.Defence = 5;
            this.Gold = 0;
            this.RankPoints = 0;
        }

        public Hero()
        {
            
        }

        public void AddItem(Item item)
        {
            this.itemList.Add(item);
        }

    }
}
