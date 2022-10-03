using Wizards.Core.Model;
using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.UserModels.Enums;
using Wizards.Core.Model.UserModels.Properties;
using Wizards.Repository.InitialData.SeedFactories.Interfaces;

namespace Wizards.Repository.InitialData.SeedFactories.Implementations;

public class InitialDataItemsFactory : IInitialDataItemsFactory
{
    public List<Item> GetItems()
    {
        var result = new List<Item>();

        result.Add(new Item() { Id = 1, AttributesId = 1, Name = "Normal Staff", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Sorcerer, Tier = 1, BuyPrice = 100, SellPrice = 80 });
        result.Add(new Item() { Id = 2, AttributesId = 2, Name = "Fine Staff", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Sorcerer, Tier = 2, BuyPrice = 600, SellPrice = 480 });
        result.Add(new Item() { Id = 3, AttributesId = 3, Name = "Great Staff", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Sorcerer, Tier = 3, BuyPrice = 3000, SellPrice = 2400 });
        result.Add(new Item() { Id = 4, AttributesId = 4, Name = "Enchanted Staff", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Sorcerer, Tier = 4, BuyPrice = 12000, SellPrice = 9600 });
        result.Add(new Item() { Id = 5, AttributesId = 5, Name = "Masterpiece Staff", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Sorcerer, Tier = 5, BuyPrice = 36000, SellPrice = 28800 });
        result.Add(new Item() { Id = 6, AttributesId = 6, Name = "Normal Spell-book", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Sorcerer, Tier = 1, BuyPrice = 100, SellPrice = 80 });
        result.Add(new Item() { Id = 7, AttributesId = 7, Name = "Fine Spell-book", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Sorcerer, Tier = 2, BuyPrice = 600, SellPrice = 480 });
        result.Add(new Item() { Id = 8, AttributesId = 8, Name = "Great Spell-book", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Sorcerer, Tier = 3, BuyPrice = 3000, SellPrice = 2400 });
        result.Add(new Item() { Id = 9, AttributesId = 9, Name = "Enchanted Spell-book", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Sorcerer, Tier = 4, BuyPrice = 12000, SellPrice = 9600 });
        result.Add(new Item() { Id = 10, AttributesId = 10, Name = "Masterpiece Spell-book", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Sorcerer, Tier = 5, BuyPrice = 36000, SellPrice = 28800 });
        result.Add(new Item() { Id = 11, AttributesId = 11, Name = "Normal Scepter", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Sorcerer, Tier = 1, BuyPrice = 100, SellPrice = 80 });
        result.Add(new Item() { Id = 12, AttributesId = 12, Name = "Fine Scepter", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Sorcerer, Tier = 2, BuyPrice = 600, SellPrice = 480 });
        result.Add(new Item() { Id = 13, AttributesId = 13, Name = "Great Scepter", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Sorcerer, Tier = 3, BuyPrice = 3000, SellPrice = 2400 });
        result.Add(new Item() { Id = 14, AttributesId = 14, Name = "Enchanted Scepter", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Sorcerer, Tier = 4, BuyPrice = 12000, SellPrice = 9600 });
        result.Add(new Item() { Id = 15, AttributesId = 15, Name = "Masterpiece Scepter", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Sorcerer, Tier = 5, BuyPrice = 36000, SellPrice = 28800 });

        result.Add(new Item() { Id = 16, AttributesId = 16, Name = "Normal Vestments", Type = ItemType.Armor, Restriction = ProfessionRestriction.Sorcerer, Tier = 1, BuyPrice = 50, SellPrice = 40 });
        result.Add(new Item() { Id = 17, AttributesId = 17, Name = "Fine Vestments", Type = ItemType.Armor, Restriction = ProfessionRestriction.Sorcerer, Tier = 2, BuyPrice = 300, SellPrice = 240 });
        result.Add(new Item() { Id = 18, AttributesId = 18, Name = "Great Vestments", Type = ItemType.Armor, Restriction = ProfessionRestriction.Sorcerer, Tier = 3, BuyPrice = 1500, SellPrice = 1200 });
        result.Add(new Item() { Id = 19, AttributesId = 19, Name = "Enchanted Vestments", Type = ItemType.Armor, Restriction = ProfessionRestriction.Sorcerer, Tier = 4, BuyPrice = 6000, SellPrice = 4800 });
        result.Add(new Item() { Id = 20, AttributesId = 20, Name = "Masterpiece Vestments", Type = ItemType.Armor, Restriction = ProfessionRestriction.Sorcerer, Tier = 5, BuyPrice = 18000, SellPrice = 14400 });
        result.Add(new Item() { Id = 21, AttributesId = 21, Name = "Normal Mantle", Type = ItemType.Armor, Restriction = ProfessionRestriction.Sorcerer, Tier = 1, BuyPrice = 50, SellPrice = 40 });
        result.Add(new Item() { Id = 22, AttributesId = 22, Name = "Fine Mantle", Type = ItemType.Armor, Restriction = ProfessionRestriction.Sorcerer, Tier = 2, BuyPrice = 300, SellPrice = 240 });
        result.Add(new Item() { Id = 23, AttributesId = 23, Name = "Great Mantle", Type = ItemType.Armor, Restriction = ProfessionRestriction.Sorcerer, Tier = 3, BuyPrice = 1500, SellPrice = 1200 });
        result.Add(new Item() { Id = 24, AttributesId = 24, Name = "Enchanted Mantle", Type = ItemType.Armor, Restriction = ProfessionRestriction.Sorcerer, Tier = 4, BuyPrice = 6000, SellPrice = 4800 });
        result.Add(new Item() { Id = 25, AttributesId = 25, Name = "Masterpiece Mantle", Type = ItemType.Armor, Restriction = ProfessionRestriction.Sorcerer, Tier = 5, BuyPrice = 18000, SellPrice = 14400 });
        result.Add(new Item() { Id = 26, AttributesId = 26, Name = "Normal Overcoat", Type = ItemType.Armor, Restriction = ProfessionRestriction.Sorcerer, Tier = 1, BuyPrice = 50, SellPrice = 40 });
        result.Add(new Item() { Id = 27, AttributesId = 27, Name = "Fine Overcoat", Type = ItemType.Armor, Restriction = ProfessionRestriction.Sorcerer, Tier = 2, BuyPrice = 300, SellPrice = 240 });
        result.Add(new Item() { Id = 28, AttributesId = 28, Name = "Great Overcoat", Type = ItemType.Armor, Restriction = ProfessionRestriction.Sorcerer, Tier = 3, BuyPrice = 1500, SellPrice = 1200 });
        result.Add(new Item() { Id = 29, AttributesId = 29, Name = "Enchanted Overcoat", Type = ItemType.Armor, Restriction = ProfessionRestriction.Sorcerer, Tier = 4, BuyPrice = 6000, SellPrice = 4800 });
        result.Add(new Item() { Id = 30, AttributesId = 30, Name = "Masterpiece Overcoat", Type = ItemType.Armor, Restriction = ProfessionRestriction.Sorcerer, Tier = 5, BuyPrice = 18000, SellPrice = 14400 });

        result.Add(new Item() { Id = 31, AttributesId = 31, Name = "Normal Scythe", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Necromancer, Tier = 1, BuyPrice = 100, SellPrice = 80 });
        result.Add(new Item() { Id = 32, AttributesId = 32, Name = "Fine Scythe", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Necromancer, Tier = 2, BuyPrice = 600, SellPrice = 480 });
        result.Add(new Item() { Id = 33, AttributesId = 33, Name = "Great Scythe", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Necromancer, Tier = 3, BuyPrice = 3000, SellPrice = 2400 });
        result.Add(new Item() { Id = 34, AttributesId = 34, Name = "Enchanted Scythe", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Necromancer, Tier = 4, BuyPrice = 12000, SellPrice = 9600 });
        result.Add(new Item() { Id = 35, AttributesId = 35, Name = "Masterpiece Scythe", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Necromancer, Tier = 5, BuyPrice = 36000, SellPrice = 28800 });
        result.Add(new Item() { Id = 36, AttributesId = 36, Name = "Normal Urn", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Necromancer, Tier = 1, BuyPrice = 100, SellPrice = 80 });
        result.Add(new Item() { Id = 37, AttributesId = 37, Name = "Fine Urn", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Necromancer, Tier = 2, BuyPrice = 600, SellPrice = 480 });
        result.Add(new Item() { Id = 38, AttributesId = 38, Name = "Great Urn", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Necromancer, Tier = 3, BuyPrice = 3000, SellPrice = 2400 });
        result.Add(new Item() { Id = 39, AttributesId = 39, Name = "Enchanted Urn", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Necromancer, Tier = 4, BuyPrice = 12000, SellPrice = 9600 });
        result.Add(new Item() { Id = 40, AttributesId = 40, Name = "Masterpiece Urn", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Necromancer, Tier = 5, BuyPrice = 36000, SellPrice = 28800 });
        result.Add(new Item() { Id = 41, AttributesId = 41, Name = "Normal Ritual Cup", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Necromancer, Tier = 1, BuyPrice = 100, SellPrice = 80 });
        result.Add(new Item() { Id = 42, AttributesId = 42, Name = "Fine Ritual Cup", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Necromancer, Tier = 2, BuyPrice = 600, SellPrice = 480 });
        result.Add(new Item() { Id = 43, AttributesId = 43, Name = "Great Ritual Cup", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Necromancer, Tier = 3, BuyPrice = 3000, SellPrice = 2400 });
        result.Add(new Item() { Id = 44, AttributesId = 44, Name = "Enchanted Ritual Cup", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Necromancer, Tier = 4, BuyPrice = 12000, SellPrice = 9600 });
        result.Add(new Item() { Id = 45, AttributesId = 45, Name = "Masterpiece Ritual Cup", Type = ItemType.Weapon, Restriction = ProfessionRestriction.Necromancer, Tier = 5, BuyPrice = 36000, SellPrice = 28800 });

        result.Add(new Item() { Id = 46, AttributesId = 46, Name = "Normal Hood", Type = ItemType.Armor, Restriction = ProfessionRestriction.Necromancer, Tier = 1, BuyPrice = 50, SellPrice = 40 });
        result.Add(new Item() { Id = 47, AttributesId = 47, Name = "Fine Hood", Type = ItemType.Armor, Restriction = ProfessionRestriction.Necromancer, Tier = 2, BuyPrice = 300, SellPrice = 240 });
        result.Add(new Item() { Id = 48, AttributesId = 48, Name = "Great Hood", Type = ItemType.Armor, Restriction = ProfessionRestriction.Necromancer, Tier = 3, BuyPrice = 1500, SellPrice = 1200 });
        result.Add(new Item() { Id = 49, AttributesId = 49, Name = "Enchanted Hood", Type = ItemType.Armor, Restriction = ProfessionRestriction.Necromancer, Tier = 4, BuyPrice = 6000, SellPrice = 4800 });
        result.Add(new Item() { Id = 50, AttributesId = 50, Name = "Masterpiece Hood", Type = ItemType.Armor, Restriction = ProfessionRestriction.Necromancer, Tier = 5, BuyPrice = 18000, SellPrice = 14400 });
        result.Add(new Item() { Id = 51, AttributesId = 51, Name = "Normal Shroud", Type = ItemType.Armor, Restriction = ProfessionRestriction.Necromancer, Tier = 1, BuyPrice = 50, SellPrice = 40 });
        result.Add(new Item() { Id = 52, AttributesId = 52, Name = "Fine Shroud", Type = ItemType.Armor, Restriction = ProfessionRestriction.Necromancer, Tier = 2, BuyPrice = 300, SellPrice = 240 });
        result.Add(new Item() { Id = 53, AttributesId = 53, Name = "Great Shroud", Type = ItemType.Armor, Restriction = ProfessionRestriction.Necromancer, Tier = 3, BuyPrice = 1500, SellPrice = 1200 });
        result.Add(new Item() { Id = 54, AttributesId = 54, Name = "Enchanted Shroud", Type = ItemType.Armor, Restriction = ProfessionRestriction.Necromancer, Tier = 4, BuyPrice = 6000, SellPrice = 4800 });
        result.Add(new Item() { Id = 55, AttributesId = 55, Name = "Masterpiece Shroud", Type = ItemType.Armor, Restriction = ProfessionRestriction.Necromancer, Tier = 5, BuyPrice = 18000, SellPrice = 14400 });
        result.Add(new Item() { Id = 56, AttributesId = 56, Name = "Normal Ritual Livery", Type = ItemType.Armor, Restriction = ProfessionRestriction.Necromancer, Tier = 1, BuyPrice = 50, SellPrice = 40 });
        result.Add(new Item() { Id = 57, AttributesId = 57, Name = "Fine Ritual Livery", Type = ItemType.Armor, Restriction = ProfessionRestriction.Necromancer, Tier = 2, BuyPrice = 300, SellPrice = 240 });
        result.Add(new Item() { Id = 58, AttributesId = 58, Name = "Great Ritual Livery", Type = ItemType.Armor, Restriction = ProfessionRestriction.Necromancer, Tier = 3, BuyPrice = 1500, SellPrice = 1200 });
        result.Add(new Item() { Id = 59, AttributesId = 59, Name = "Enchanted Ritual Livery", Type = ItemType.Armor, Restriction = ProfessionRestriction.Necromancer, Tier = 4, BuyPrice = 6000, SellPrice = 4800 });
        result.Add(new Item() { Id = 60, AttributesId = 60, Name = "Masterpiece Ritual Livery", Type = ItemType.Armor, Restriction = ProfessionRestriction.Necromancer, Tier = 5, BuyPrice = 18000, SellPrice = 14400 });

        return result;
    }

    public List<ItemAttributes> GetAttributes()
    {
        var result = new List<ItemAttributes>();

        result.Add(new ItemAttributes() { Id = 1, Damage = 10, Precision = 20, Specialization = 0, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Id = 2, Damage = 20, Precision = 26, Specialization = -2, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Id = 3, Damage = 30, Precision = 32, Specialization = -4, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Id = 4, Damage = 40, Precision = 38, Specialization = -6, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Id = 5, Damage = 50, Precision = 44, Specialization = -8, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Id = 6, Damage = 10, Precision = 0, Specialization = 20, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Id = 7, Damage = 20, Precision = -2, Specialization = 26, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Id = 8, Damage = 30, Precision = -4, Specialization = 32, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Id = 9, Damage = 40, Precision = -6, Specialization = 38, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Id = 10, Damage = 50, Precision = -8, Specialization = 44, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Id = 11, Damage = 9, Precision = 2, Specialization = 10, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Id = 12, Damage = 18, Precision = 6, Specialization = 14, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Id = 13, Damage = 27, Precision = 10, Specialization = 18, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Id = 14, Damage = 36, Precision = 14, Specialization = 22, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Id = 15, Damage = 45, Precision = 18, Specialization = 26, MaxHealth = 0, Defense = 0, Reflex = 0 });

        result.Add(new ItemAttributes() { Id = 16, Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 25, Defense = 0, Reflex = 26 });
        result.Add(new ItemAttributes() { Id = 17, Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 75, Defense = -2, Reflex = 32 });
        result.Add(new ItemAttributes() { Id = 18, Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 125, Defense = -4, Reflex = 38 });
        result.Add(new ItemAttributes() { Id = 19, Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 175, Defense = -6, Reflex = 44 });
        result.Add(new ItemAttributes() { Id = 20, Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 225, Defense = -8, Reflex = 50 });
        result.Add(new ItemAttributes() { Id = 21, Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 25, Defense = 26, Reflex = 0 });
        result.Add(new ItemAttributes() { Id = 22, Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 75, Defense = 32, Reflex = -2 });
        result.Add(new ItemAttributes() { Id = 23, Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 125, Defense = 38, Reflex = -4 });
        result.Add(new ItemAttributes() { Id = 24, Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 175, Defense = 44, Reflex = -6 });
        result.Add(new ItemAttributes() { Id = 25, Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 225, Defense = 50, Reflex = -8 });
        result.Add(new ItemAttributes() { Id = 26, Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 20, Defense = 18, Reflex = 16 });
        result.Add(new ItemAttributes() { Id = 27, Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 60, Defense = 22, Reflex = 20 });
        result.Add(new ItemAttributes() { Id = 28, Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 100, Defense = 26, Reflex = 24 });
        result.Add(new ItemAttributes() { Id = 29, Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 140, Defense = 30, Reflex = 28 });
        result.Add(new ItemAttributes() { Id = 30, Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 180, Defense = 34, Reflex = 32 });

        result.Add(new ItemAttributes() { Id = 31, Damage = 10, Precision = 20, Specialization = 0, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Id = 32, Damage = 20, Precision = 26, Specialization = -1, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Id = 33, Damage = 30, Precision = 32, Specialization = -2, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Id = 34, Damage = 40, Precision = 38, Specialization = -3, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Id = 35, Damage = 50, Precision = 44, Specialization = -4, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Id = 36, Damage = 10, Precision = 0, Specialization = 20, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Id = 37, Damage = 20, Precision = -1, Specialization = 26, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Id = 38, Damage = 30, Precision = -2, Specialization = 32, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Id = 39, Damage = 40, Precision = -3, Specialization = 38, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Id = 40, Damage = 50, Precision = -4, Specialization = 44, MaxHealth = 0, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Id = 41, Damage = 10, Precision = 10, Specialization = 6, MaxHealth = -10, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Id = 42, Damage = 20, Precision = 14, Specialization = 10, MaxHealth = -20, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Id = 43, Damage = 30, Precision = 18, Specialization = 14, MaxHealth = -30, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Id = 44, Damage = 40, Precision = 22, Specialization = 18, MaxHealth = -40, Defense = 0, Reflex = 0 });
        result.Add(new ItemAttributes() { Id = 45, Damage = 50, Precision = 26, Specialization = 22, MaxHealth = -50, Defense = 0, Reflex = 0 });

        result.Add(new ItemAttributes() { Id = 46, Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 75, Defense = 0, Reflex = 26 });
        result.Add(new ItemAttributes() { Id = 47, Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 125, Defense = -1, Reflex = 32 });
        result.Add(new ItemAttributes() { Id = 48, Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 175, Defense = -2, Reflex = 38 });
        result.Add(new ItemAttributes() { Id = 49, Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 225, Defense = -3, Reflex = 44 });
        result.Add(new ItemAttributes() { Id = 50, Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 275, Defense = -4, Reflex = 50 });
        result.Add(new ItemAttributes() { Id = 51, Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 75, Defense = 26, Reflex = 0 });
        result.Add(new ItemAttributes() { Id = 52, Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 125, Defense = 32, Reflex = -1 });
        result.Add(new ItemAttributes() { Id = 53, Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 175, Defense = 38, Reflex = -2 });
        result.Add(new ItemAttributes() { Id = 54, Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 225, Defense = 44, Reflex = -3 });
        result.Add(new ItemAttributes() { Id = 55, Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 275, Defense = 50, Reflex = -4 });
        result.Add(new ItemAttributes() { Id = 56, Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 60, Defense = 20, Reflex = 16 });
        result.Add(new ItemAttributes() { Id = 57, Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 100, Defense = 24, Reflex = 20 });
        result.Add(new ItemAttributes() { Id = 58, Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 140, Defense = 28, Reflex = 24 });
        result.Add(new ItemAttributes() { Id = 59, Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 180, Defense = 32, Reflex = 28 });
        result.Add(new ItemAttributes() { Id = 60, Damage = 0, Precision = 0, Specialization = 0, MaxHealth = 220, Defense = 36, Reflex = 32 });

        return result;
    }
}