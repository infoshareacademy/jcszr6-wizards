using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizards.BusinessLogic.Model.Items;

namespace Wizards.BusinessLogic.Model.HeroClasses
{
    internal class Wizard : Hero
    {
        public LightArmor EquippedLightArmor { get; set; }
        public Staff EquippedStaff { get; set; }

        public Wizard(int id, string nick)
        {
            this.Id = id;
            this.NickName = nick;
            this.MaxHealth = 300;
            this.CurrentHealth = MaxHealth;
            this.Attack = 10;
            this.Defence = 5;
            this.Gold = 0;
            this.RankPoints = 0;
            this.MatchPlayedToday = 0;
            this.TotalMatchPlayed = 0;
            this.TotalMatchWin = 0;
            this.TotalMatchLoose = 0;
        }

        public Wizard()
        {
            
        }
    }
}
