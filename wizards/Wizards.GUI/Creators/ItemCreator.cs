using System;
using Wizards.BusinessLogic;
using Wizards.BusinessLogic.Model.Items;

namespace Wizards.GUI.Creators
{
    public class ItemCreator
    {
        private Screen _screen;
        private UserInput _inputer;
        private ModelsMenagement _modelsMenagement;
        private Hero _hero;
        private Item _createdItem;


        public ItemCreator(Hero hero)
        {
            _screen = new Screen();
            _inputer = new UserInput();
            _inputer.Screen = _screen;
            _modelsMenagement = new ModelsMenagement();
            _hero = hero;
        }

        public ItemCreator(Hero hero, Item item) : this(hero)
        {
            _createdItem = item;
        }

        public void Run()
        {
            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.ItemCreatorTitle), ConsoleColor.Cyan));
            _screen.AddMessage(new Message($"Bohater: {_hero.NickName}\n"));
            _screen.Refresh();

            var itemType = SetTypeOfItem();

            if (itemType == typeof(Weapon))
            {
                _createdItem = SetWeapon();
            }
            else if (itemType == typeof(Armor))
            {
                _createdItem = SetArmor();
            }
            
            _modelsMenagement.AddItemToInventory(_createdItem,_hero);

            EquipItemIfUserWants();
            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.ItemCreated),ConsoleColor.Green));
            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.PressKeyToExit),ConsoleColor.Cyan));
            _screen.Refresh();
            _inputer.WaitForKey();
        }

        private Weapon SetWeapon()
        {
            var id = _hero.Id * 100 + (_hero.Equipped.Count + _hero.Inventory.Count + 1);
            var name = SetItemName();
            
            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.EnterAttackInceaseValue)));
            _screen.Refresh();
            
            var attributeIncreaseValue = SetAttributeIncrease();
            
            int buyPrice = attributeIncreaseValue * (attributeIncreaseValue / 5) * attributeIncreaseValue;
            int sellPrice = (int)Math.Round(buyPrice * 0.82m,0);
            
            return new Weapon(id, name, buyPrice, sellPrice, attributeIncreaseValue);
        }

        private Armor SetArmor()
        {
            var id = _hero.Id * 100 + (_hero.Equipped.Count + _hero.Inventory.Count + 1);
            var name = SetItemName();

            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.EnterDefenseInceaseValue)));
            _screen.Refresh();

            var attributeIncreaseValue = SetAttributeIncrease();

            int buyPrice = attributeIncreaseValue * (attributeIncreaseValue / 5) * attributeIncreaseValue;
            int sellPrice = (int)Math.Round(buyPrice * 0.82m, 0);

            return new Armor(id, name, buyPrice, sellPrice, attributeIncreaseValue);
        }

        private void EquipItemIfUserWants()
        {
            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.WantToEquip)));
            _screen.Refresh();

            char yesNoAnswer = _inputer.GetKey(new[] { 'y', 'n' });
            if (yesNoAnswer == 'n')
            {
                return;
            }

            new EquipmentMenagement(_hero).EquipItem(_createdItem);
        }

        private Type SetTypeOfItem()
        {
            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.GetTypeOfItem)));
            _screen.Refresh();

            _inputer.Validator = new ValueValidator();

            char userKey = _inputer.GetKey(new[] { 'b', 'z' });
            
            if (userKey == 'b')
            {
                _screen.AddMessage(new Message("Broń",ConsoleColor.Green));
                return typeof(Weapon);
            }
            
            if (userKey == 'z')
            {
                _screen.AddMessage(new Message("Zbroja", ConsoleColor.Green));
                return typeof(Armor);
            }

            return null;
        }
        private string SetItemName()
        {
            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.EnterItemName)));
            _screen.Refresh();

            var validator = new ValueValidator()
            {
                AllowDigits = false,
                Min = 2,
                Max = 35,
            };

            _inputer.Validator = validator;

            string itemName = _inputer.GetText();

            _screen.AddMessage(new Message(itemName, ConsoleColor.Green));

            return itemName;
        }

        private int SetAttributeIncrease()
        {
            var validator = new ValueValidator()
            {
                Min = 5,
                Max = 50,
            };

            _inputer.Validator = validator;

            int atributeIncreaseValue = _inputer.GetNumber();

            _screen.AddMessage(new Message($"{atributeIncreaseValue}", ConsoleColor.Green));

            return atributeIncreaseValue;
        }

    }
}