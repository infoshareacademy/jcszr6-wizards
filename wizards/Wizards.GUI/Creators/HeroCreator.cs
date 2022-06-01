﻿using System;
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
            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.HeroCreatorTitle)));

            _createdHero.NickName = SetNickName();
            _createdHero.Id = _player.Id * 100 + _player.Heroes.Count + 1;
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

            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.InventoryItemsCount)));
            _screen.AddMessage(new Message($"{_createdHero.Inventory.Count}",ConsoleColor.Green));
            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.EquipmentItemsCount)));
            _screen.AddMessage(new Message($"{_createdHero.Equipped.Count}", ConsoleColor.Green));
            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.WantToAddItem)));
            _screen.Refresh();

            char yesNoAnswer = _inputer.GetKey(new[] { 'y', 'n' });

            if (yesNoAnswer == 'n')
                return;

            do
            {
                new ItemCreator(_createdHero).Run();

                _screen.RemoveLastMessages(5);
                _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.InventoryItemsCount)));
                _screen.AddMessage(new Message($"{_createdHero.Inventory.Count}", ConsoleColor.Green));
                _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.EquipmentItemsCount)));
                _screen.AddMessage(new Message($"{_createdHero.Equipped.Count}", ConsoleColor.Green));
                _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.WantToAddItem)));
                _screen.Refresh();

                yesNoAnswer = _inputer.GetKey(new[] { 'y', 'n' });

            } while (yesNoAnswer == 'y');

        }

    }
}