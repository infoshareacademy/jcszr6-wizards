﻿using Wizards.Core.Model.Enums;
using Wizards.Core.Model.Properties;

namespace Wizards.Core.Model;

public class Hero
{
    // General Info
    public int Id { get; set; }
    public string NickName { get; set; }
    public HeroProfession Profession { get; set; }
    public int AvatarImageNumber { get; set; }

    public HeroAttributes Attributes { get; set; }
    public int AttributesId { get; set; }

    // Economic
    public int Gold { get; set; }

    public List<HeroItem> Inventory { get; set; }

    public Statistics Statistics { get; set; }
    public int StatisticsId { get; set; }

    public Player Player { get; set; }
    public int PlayerId { get; set; }

}