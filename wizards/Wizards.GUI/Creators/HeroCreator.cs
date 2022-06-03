using System;
using System.Linq;
using Wizards.BusinessLogic;
using Wizards.GUI.Printers;

namespace Wizards.GUI.Creators
{
    public class HeroCreator
    {
        private Screen _screen;
        private UserInput _inputer;
        private ModelsMenagement _modelsMenagement;
        private Player _player;
        private Hero _createdHero;

        public HeroCreator(Player player)
        {
            _screen = new Screen();
            _inputer = new UserInput();
            _inputer.Screen = _screen;
            _modelsMenagement = new ModelsMenagement();
            _player = player;
            _createdHero = new Hero();
        }
        public HeroCreator(Player player, Hero hero) : this(player)
        {
            _createdHero = hero;
        }

        public void Run()
        {
            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.HeroCreatorTitle), ConsoleColor.Cyan));
            _screen.AddMessage(new Message($"Gracz: {_player.UserName}\n"));
            _screen.Refresh();

            new HeroPrinter(_screen).PrintPlayersHeroes(_player);
            
            _createdHero.NickName = SetNickName();
            _createdHero.Id = _player.Id + (_player.Heroes.Count + 1) * 100;
            _modelsMenagement.AddHeroToPlayer(_createdHero, _player);

            AddItemsToHero();

            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.HeroCreated), ConsoleColor.Green));
            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.PressKeyToExit), ConsoleColor.Cyan));
            _screen.Refresh();
            _inputer.WaitForKey();
        }

        private string SetNickName()
        {
            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.EnterNickName)));
            _screen.Refresh();

            var validator = new ValueValidator()
            {
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
        private void AddItemsToHero()
        {
            var validator = new ValueValidator();
            _inputer.Validator = validator;

            new ItemPrinter(_screen).PrintAllHeroesItems(_createdHero);

            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.WantToAddItem)));
            _screen.Refresh();

            char yesNoAnswer = _inputer.GetKey(new[] { 'y', 'n' });

            if (yesNoAnswer == 'n')
                return;

            do
            {
                _screen.RemoveLastMessages(5 + _createdHero.Inventory.Count + _createdHero.Equipped.Count);
                
                new ItemCreator(_createdHero).Run();

                new ItemPrinter(_screen).PrintAllHeroesItems(_createdHero);

                _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.WantToAddAnotherItem)));
                _screen.Refresh();
                
                yesNoAnswer = _inputer.GetKey(new[] { 'y', 'n' });

            } while (yesNoAnswer == 'y');

        }

    }
}