using Wizards.Core.Model.UserModels.Enums;
using Wizards.Core.Model.UserModels.Properties;

namespace Wizards.Core.Model.UserModels;

public class Hero
{
    // General
    public int Id { get; set; }
    public string NickName { get; set; }
    public HeroProfession Profession { get; set; }
    public int AvatarImageNumber { get; set; }

    // Combat
    public HeroAttributes Attributes { get; set; }
    public List<HeroSkill> Skills { get; set; }

    // Economic
    public int Gold { get; set; }
    public List<HeroItem> Inventory { get; set; }

    // Statistics and progression
    public Statistics Statistics { get; set; }

    // Db relations properties
    public int AttributesId { get; set; }
    public int StatisticsId { get; set; }
    public Player Player { get; set; }
    public int PlayerId { get; set; }
}