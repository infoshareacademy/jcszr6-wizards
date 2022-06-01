using System;
using Wizards.BusinessLogic;
using Wizards.BusinessLogic.Model.Items;

namespace Wizards.GUI.Printers
{
    public class ItemPrinter
    {
        private Screen _screen;

        public ItemPrinter(Screen screen)
        {
            _screen = screen;
        }

        public void PrintAllHeroesItems(Hero hero)
        {
            PrintHeroesInventory(hero);
            PrintHeroesEquipement(hero);
            _screen.Refresh();
        }

        public void PrintHeroesInventory(Hero hero)
        {
            var inventoryItems = hero.Inventory;

            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.InventoryItemsCount)));
            _screen.AddMessage(new Message($"{inventoryItems.Count}", ConsoleColor.Green));

            for (int i = 0; i < inventoryItems.Count; i++)
            {
                PrintItemInfo(inventoryItems[i], i + 1);
            }
        }

        public void PrintHeroesEquipement(Hero hero)
        {
            var equippedItems = hero.Equipped;

            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.EquipmentItemsCount)));
            _screen.AddMessage(new Message($"{equippedItems.Count}", ConsoleColor.Green));

            for (int i = 0; i < equippedItems.Count; i++)
            {
                PrintItemInfo(equippedItems[i], i + 1);
            }
        }


        public void PrintItemInfo(Item item, int index)
        {
            string itemText = "";
            if (item is Weapon)
            {
                var weapon = item as Weapon;
                itemText = String.Format("\n\t{0,-4} | {1,-7} | {2,-30} | {3,-20} |", $"{index}.", "Broń", weapon.Name, $"Wartość ataku: +{weapon.AttackIncrease}");
            }
            else if (item is Armor)
            {
                var armor = item as Armor;
                itemText = String.Format("\n\t{0,-4} | {1,-7} | {2,-30} | {3,-20} |", $"{index}.", "Zbroja", armor.Name, $"Wartość obrony: +{armor.DefenceIncrease}");
            }

            _screen.AddMessage(new Message(itemText, ConsoleColor.Yellow));
        }

    }
}