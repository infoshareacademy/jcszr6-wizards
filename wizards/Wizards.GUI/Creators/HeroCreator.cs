using System;
using System.Linq;
using Wizards.BusinessLogic;

namespace Wizards.GUI.Creators
{
    public class HeroCreator
    {
        private Screen _screen;
        private UserInput _inputer;
        private ModelsMenagement _modelsMenagement;
        private Player _player;

        public HeroCreator(Player player)
        {
            _screen = new Screen();
            _inputer = new UserInput();
            _inputer.Screen = _screen;
            _modelsMenagement = new ModelsMenagement();
            _player = player;
        }

        public void Run()
        {
            var nickName = SetNickName();
            var id = _player.Id * 100 + _player.Heroes.Count + 1;

            var hero = new Hero(id, nickName);
            _modelsMenagement.AddHeroToPlayer(hero, _player);

            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.HeroAdded)));
            _screen.Refresh();
        }

        private string SetNickName()
        {
            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.EnterNickName)));
            _screen.Refresh();

            var validator = new ValueValidator()
            {
                AllowLetters = true,
                AllowSpace = true,
                AllowSpecialCharacters = false,
                AllowDigits = false,
                Min = 3,
                Max = 17,
                AlredyInUseValues = Repository.Players.SelectMany(p => p.Heroes.Select(h => h.NickName)).ToList()
            };

            _inputer.Validator = validator;

            string nickName = _inputer.GetText();

            _screen.AddMessage(new Message(nickName, ConsoleColor.Green));

            return nickName;
        }
    }
}