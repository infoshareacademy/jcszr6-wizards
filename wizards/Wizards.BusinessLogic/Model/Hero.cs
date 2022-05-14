using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wizards.BusinessLogic
{
    public class Hero
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Gold { get; set; }
        public int RankPoints { get; set; }
        public int MatchPlayedToday { get; set; }
        public int TotalMatchPlayed { get; set; }
        public int TotalMatchWin { get; set; }
        public int TotalMatchLoose { get; set; }
        public List<Item> Inventory { get; set; }
        public List<Item> Equipped { get; set; }
        public Restriction Restrictions { get; set; }

        // funkcja swap(List<item> source, List<Item> target, Item source, Item target)

        public Hero(int id, string nick)
        {
            this.Id = id;
            this.NickName = nick;
            this.MaxHealth = 300;
            this.CurrentHealth = MaxHealth;
            this.Attack = 10;
            this.Defense = 5;
            this.Gold = 0;
            this.RankPoints = 0;
            this.MatchPlayedToday = 0;
            this.TotalMatchPlayed = 0;
            this.TotalMatchWin = 0;
            this.TotalMatchLoose = 0;
        }

        public Hero()
        {

        }
    }
}
