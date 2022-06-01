using System;
using Wizards.BusinessLogic;
using Wizards.GUI.Printers;

namespace Wizards.GUI.Selectors
{
    public class HeroSelector
    {
        private Player _player;
        private Hero _hero;
        private Screen _screen;
        private UserInput _inputer;

        public HeroSelector(Player player)
        {
            _screen = new Screen();
            _inputer = new UserInput();
            _inputer.Screen = _screen;
            _player = player;
        }

        public void Select()
        {
            _screen.AddMessage(new Message(TextRepository.Get(SelectorsMsg.SelectHero)));

            new HeroPrinter(_screen).PrintPlayersHeroes(_player);
            
            _screen.AddMessage(new Message(TextRepository.Get(SelectorsMsg.EnterNumberOfHero)));
            _screen.Refresh();

            _inputer.Validator = new ValueValidator() { Min = 1, Max = _player.Heroes.Count };
            int index = _inputer.GetNumber();

            _hero = _player.Heroes[index - 1];

            _screen.AddMessage(new Message(TextRepository.Get(SelectorsMsg.HeroSelected), ConsoleColor.Cyan));
        }

        public Hero ReturnHero()
        {
            return _hero;
        }
    }
}