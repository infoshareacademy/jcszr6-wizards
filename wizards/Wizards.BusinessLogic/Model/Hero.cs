using System.Collections.Generic;

namespace Wizards.BusinessLogic
{
    public class Hero
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public HeroProfession Profession { get; set; }
        public int AvatarImageNumber { get; set; }

        public HeroAttributes Attributes { get; set; }

        public int Gold { get; set; }
        public List<Item> Inventory = new();
        public List<Item> Equipped = new();

        public HeroStatistics Statistics { get; set; }
        public int DailyRewardEnergy { get; set; }

        public Hero()
        {

        }
    }
}
