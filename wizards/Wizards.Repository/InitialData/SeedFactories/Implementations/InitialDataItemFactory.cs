using Wizards.Core.Model;
using Wizards.Core.Model.Enums;
using Wizards.Repository.InitialData.SeedFactories.Interfaces;

namespace Wizards.Repository.InitialData.SeedFactories.Implementations;

public class InitialDataItemFactory : IInitialDataItemsFactory
{
    public List<Item> GetItems()
    {
        var result = new List<Item>();

        //Weapons
        result.Add(new Item() { AttributesId = 1, Name = "Normal Staff", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Sorcerer, Tier = 1, BuyPrice = 100, SellPrice = 80 });
        result.Add(new Item() { AttributesId = 2, Name = "Fine Staff", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Sorcerer, Tier = 2, BuyPrice = 600, SellPrice = 480 });
        result.Add(new Item() { AttributesId = 3, Name = "Great Staff", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Sorcerer, Tier = 3, BuyPrice = 3000, SellPrice = 2400 });
        result.Add(new Item() { AttributesId = 4, Name = "Enchanted Staff", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Sorcerer, Tier = 4, BuyPrice = 12000, SellPrice = 9600 });
        result.Add(new Item() { AttributesId = 5, Name = "Masterpiece Staff", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Sorcerer, Tier = 5, BuyPrice = 36000, SellPrice = 28800 });

        result.Add(new Item() { AttributesId = 6, Name = "Normal Spell-book", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Sorcerer, Tier = 1, BuyPrice = 100, SellPrice = 80 });
        result.Add(new Item() { AttributesId = 7, Name = "Fine Spell-book", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Sorcerer, Tier = 2, BuyPrice = 600, SellPrice = 480 });
        result.Add(new Item() { AttributesId = 8, Name = "Great Spell-book", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Sorcerer, Tier = 3, BuyPrice = 3000, SellPrice = 2400 });
        result.Add(new Item() { AttributesId = 9, Name = "Enchanted Spell-book", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Sorcerer, Tier = 4, BuyPrice = 12000, SellPrice = 9600 });
        result.Add(new Item() { AttributesId = 10, Name = "Masterpiece Spell-book", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Sorcerer, Tier = 5, BuyPrice = 36000, SellPrice = 28800 });

        result.Add(new Item() { AttributesId = 11, Name = "Normal Scepter", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Sorcerer, Tier = 1, BuyPrice = 100, SellPrice = 80 });
        result.Add(new Item() { AttributesId = 12, Name = "Fine Scepter", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Sorcerer, Tier = 2, BuyPrice = 600, SellPrice = 480 });
        result.Add(new Item() { AttributesId = 13, Name = "Great Scepter", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Sorcerer, Tier = 3, BuyPrice = 3000, SellPrice = 2400 });
        result.Add(new Item() { AttributesId = 14, Name = "Enchanted Scepter", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Sorcerer, Tier = 4, BuyPrice = 12000, SellPrice = 9600 });
        result.Add(new Item() { AttributesId = 15, Name = "Masterpiece Scepter", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Sorcerer, Tier = 5, BuyPrice = 36000, SellPrice = 28800 });

        //Armors
        result.Add(new Item() { AttributesId = 16, Name = "Normal Vestments", Type = ItemType.Armor, Restriction = ProfessionRestriction.Sorcerer, Tier = 1, BuyPrice = 50, SellPrice = 40 });
        result.Add(new Item() { AttributesId = 17, Name = "Fine Vestments", Type = ItemType.Armor, Restriction = ProfessionRestriction.Sorcerer, Tier = 2, BuyPrice = 300, SellPrice = 240 });
        result.Add(new Item() { AttributesId = 18, Name = "Great Vestments", Type = ItemType.Armor, Restriction = ProfessionRestriction.Sorcerer, Tier = 3, BuyPrice = 1500, SellPrice = 1200 });
        result.Add(new Item() { AttributesId = 19, Name = "Enchanted Vestments", Type = ItemType.Armor, Restriction = ProfessionRestriction.Sorcerer, Tier = 4, BuyPrice = 6000, SellPrice = 4800 });
        result.Add(new Item() { AttributesId = 20, Name = "Masterpiece Vestments", Type = ItemType.Armor, Restriction = ProfessionRestriction.Sorcerer, Tier = 5, BuyPrice = 18000, SellPrice = 14400 });

        result.Add(new Item() { AttributesId = 21, Name = "Normal Mantle", Type = ItemType.Armor, Restriction = ProfessionRestriction.Sorcerer, Tier = 1, BuyPrice = 50, SellPrice = 40 });
        result.Add(new Item() { AttributesId = 22, Name = "Fine Mantle", Type = ItemType.Armor, Restriction = ProfessionRestriction.Sorcerer, Tier = 2, BuyPrice = 300, SellPrice = 240 });
        result.Add(new Item() { AttributesId = 23, Name = "Great Mantle", Type = ItemType.Armor, Restriction = ProfessionRestriction.Sorcerer, Tier = 3, BuyPrice = 1500, SellPrice = 1200 });
        result.Add(new Item() { AttributesId = 24, Name = "Enchanted Mantle", Type = ItemType.Armor, Restriction = ProfessionRestriction.Sorcerer, Tier = 4, BuyPrice = 6000, SellPrice = 4800 });
        result.Add(new Item() { AttributesId = 25, Name = "Masterpiece Mantle", Type = ItemType.Armor, Restriction = ProfessionRestriction.Sorcerer, Tier = 5, BuyPrice = 18000, SellPrice = 14400 });

        result.Add(new Item() { AttributesId = 26, Name = "Normal Overcoat", Type = ItemType.Armor, Restriction = ProfessionRestriction.Sorcerer, Tier = 1, BuyPrice = 50, SellPrice = 40 });
        result.Add(new Item() { AttributesId = 27, Name = "Fine Overcoat", Type = ItemType.Armor, Restriction = ProfessionRestriction.Sorcerer, Tier = 2, BuyPrice = 300, SellPrice = 240 });
        result.Add(new Item() { AttributesId = 28, Name = "Great Overcoat", Type = ItemType.Armor, Restriction = ProfessionRestriction.Sorcerer, Tier = 3, BuyPrice = 1500, SellPrice = 1200 });
        result.Add(new Item() { AttributesId = 29, Name = "Enchanted Overcoat", Type = ItemType.Armor, Restriction = ProfessionRestriction.Sorcerer, Tier = 4, BuyPrice = 6000, SellPrice = 4800 });
        result.Add(new Item() { AttributesId = 30, Name = "Masterpiece Overcoat", Type = ItemType.Armor, Restriction = ProfessionRestriction.Sorcerer, Tier = 5, BuyPrice = 18000, SellPrice = 14400 });

        return result;
    }

    public List<ItemAttributes> GetAttributes()
    {
        var result = new List<ItemAttributes>();

        //For Weapons
        result.Add(new ItemAttributes() { Damage = 7, Precision = 15, Specialization = -8, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Damage = 14, Precision = 20, Specialization = -6, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Damage = 21, Precision = 25, Specialization = -4, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Damage = 28, Precision = 30, Specialization = -2, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Damage = 35, Precision = 35, Specialization = 0, MaxHealth = 0, Defense = 0, Reflex = 0 });

        result.Add(new ItemAttributes() { Damage = 8, Precision = -8, Specialization = 30, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Damage = 16, Precision = -6, Specialization = 35, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Damage = 24, Precision = -4, Specialization = 40, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Damage = 32, Precision = -2, Specialization = 45, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Damage = 40, Precision = 0, Specialization = 50, MaxHealth = 0, Defense = 0, Reflex = 0 });

        result.Add(new ItemAttributes() { Damage = 9, Precision = 12, Specialization = 3, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Damage = 18, Precision = 14, Specialization = 6, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Damage = 27, Precision = 16, Specialization = 9, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Damage = 36, Precision = 18, Specialization = 12, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Damage = 45, Precision = 20, Specialization = 15, MaxHealth = 0, Defense = 0, Reflex = 0 });

        //For Armors
        result.Add(new ItemAttributes() { Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 25, Reflex = 15, Defense = -8 });
        result.Add(new ItemAttributes() { Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 75, Reflex = 20, Defense = -6 });
        result.Add(new ItemAttributes() { Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 125, Reflex = 25, Defense = -4 });
        result.Add(new ItemAttributes() { Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 175, Reflex = 30, Defense = -2 });
        result.Add(new ItemAttributes() { Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 225, Reflex = 35, Defense = 0 });

        result.Add(new ItemAttributes() { Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 25, Reflex = -8, Defense = 30 });
        result.Add(new ItemAttributes() { Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 75, Reflex = -6, Defense = 35 });
        result.Add(new ItemAttributes() { Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 125, Reflex = -4, Defense = 40 });
        result.Add(new ItemAttributes() { Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 175, Reflex = -2, Defense = 45 });
        result.Add(new ItemAttributes() { Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 225, Reflex = 0, Defense = 50 });

        result.Add(new ItemAttributes() { Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 25, Reflex = 4, Defense = 15 });
        result.Add(new ItemAttributes() { Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 75, Reflex = 8, Defense = 20 });
        result.Add(new ItemAttributes() { Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 125, Reflex = 12, Defense = 25});
        result.Add(new ItemAttributes() { Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 175, Reflex = 16, Defense = 30 });
        result.Add(new ItemAttributes() { Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 225, Reflex = 20, Defense = 35 });

        return result;
    }
}