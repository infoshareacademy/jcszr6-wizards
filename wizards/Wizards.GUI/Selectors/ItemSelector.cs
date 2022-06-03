using System;
using System.Collections.Generic;
using Wizards.BusinessLogic;
using Wizards.GUI.Printers;

namespace Wizards.GUI.Selectors
{
    public class ItemSelector
    {
        private Hero _hero;
        private Item _item;
        private Screen _screen;
        private UserInput _inputer;

        public ItemSelector(Hero hero)
        {
            _screen = new Screen();
            _inputer = new UserInput();
            _inputer.Screen = _screen;
            _hero = hero;
        }

        public void Select()
        {
            _screen.AddMessage(new Message(TextRepository.Get(SelectorsMsg.SelectItem)));

            new ItemPrinter(_screen).PrintHeroesInventory(_hero);

            _screen.AddMessage(new Message(TextRepository.Get(SelectorsMsg.EnterNumberOfItem)));
            _screen.Refresh();

            _inputer.Validator = new ValueValidator() { Min = 1, Max = _hero.Inventory.Count };
            int index = _inputer.GetNumber();

            _item = _hero.Inventory[index - 1];

            _screen.AddMessage(new Message(TextRepository.Get(SelectorsMsg.ItemSelected), ConsoleColor.Cyan));
        }

        public Item Get()
        {
            return _item;
        }
    }
}