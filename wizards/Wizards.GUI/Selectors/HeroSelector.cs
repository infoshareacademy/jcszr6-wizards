using System;
using Wizards.BusinessLogic;

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

            var heroes = _player.Heroes;

            for (int i = 0; i < heroes.Count; i++)
            {
                _screen.AddMessage(new Message($"\n\t{i + 1}. {heroes[i].NickName}", ConsoleColor.Magenta));
            }

            _screen.AddMessage(new Message(TextRepository.Get(SelectorsMsg.EnterNumberOfHero)));
            _screen.Refresh();

            _inputer.Validator = new ValueValidator() { Min = 1, Max = heroes.Count };
            int index = _inputer.GetNumber();

            _hero = heroes[index - 1];

            _screen.AddMessage(new Message(TextRepository.Get(SelectorsMsg.HeroSelected), ConsoleColor.Cyan));
        }

        public Hero Get()
        {
            return _hero;
        }
    }
}