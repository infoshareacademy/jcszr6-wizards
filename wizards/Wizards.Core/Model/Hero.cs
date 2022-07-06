using Wizards.Core.Model.Enums;

namespace Wizards.Core.Model
{
    public class Hero
    {
        // General Info
        public int Id { get; set; }
        public string NickName { get; set; }
        public HeroProfession Profession { get; set; }
        public int AvatarImageNumber { get; set; }

        public HeroAttributes Attributes { get; set; }

        // Economic
        public int Gold { get; set; }

        public List<Item> Inventory = new();

        public Statistics Statistics { get; set; }
        
        public Hero()
        {

        }
    }
}
