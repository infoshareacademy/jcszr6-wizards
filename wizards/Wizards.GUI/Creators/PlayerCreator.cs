using System;
using System.Linq;
using Wizards.BusinessLogic;

namespace Wizards.GUI.Creators
{
    public class PlayerCreator
    {
        private Screen _screen;
        private UserInput _inputer;
        private ModelsMenagement _modelsMenagement;
        private Player _player;

        public PlayerCreator()
        {
            _screen = new Screen();
            _inputer = new UserInput();
            _inputer.Screen = _screen;
            _modelsMenagement = new ModelsMenagement();
            _player = new Player();
        }

        public PlayerCreator(Player player) : this()
        {
            _player = player;
        }

        public void Run()
        {
            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.PlayerCreatorTitle)));

            _player.UserName = SetUserName();
            _player.Password = SetPassword();
            _player.Email = SetEmail();
            _player.DateOfBirth = SetBirthDate();
            _player.Id = Repository.Players.Max(p => p.Id) + 1;
            
            _modelsMenagement.AddPlayer(_player);

            AddHeroes();

            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.PlayerCreated), ConsoleColor.Green));
            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.PressKeyToExit), ConsoleColor.Cyan));
            _screen.Refresh();
            _inputer.WaitForKey();
        }

        private string SetUserName()
        {
            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.EnterUserName)));
            _screen.Refresh();

            var validator = new ValueValidator()
            {
                AllowSpecialCharacters = true,
                AllowSpace = false,
                Min = 3,
                Max = 20,
                AlredyInUseValues = Repository.Players.Select(p => p.UserName).ToList()
            };

            _inputer.Validator = validator;

            string userName = _inputer.GetText();

            _screen.AddMessage(new Message(userName, ConsoleColor.Green));

            return userName;
        }

        private string SetPassword()
        {
            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.EnterPassword)));
            _screen.Refresh();

            var validator = new ValueValidator()
            {
                AllowSpecialCharacters = true,
                AllowSpace = false,
                Min = 8,
                Max = 50
            };

            _inputer.Validator = validator;

            string password = _inputer.GetText();

            _screen.AddMessage(new Message("Hasło przyjęte", ConsoleColor.Green));

            return password;
        }

        private string SetEmail()
        {
            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.EnterEmail)));
            _screen.Refresh();

            var validator = new ValueValidator()
            {
                AllowSpecialCharacters = true,
                AllowSpace = false,
                Min = 5,
                AlredyInUseValues = Repository.Players.Select(p => p.Email).ToList()
            };

            _inputer.Validator = validator;

            string email = _inputer.GetText();

            _screen.AddMessage(new Message(email, ConsoleColor.Green));

            return email;
        }

        private DateTime SetBirthDate()
        {
            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.EnterBirthDate)));

            DateTime birthDate;
            var validator = new ValueValidator();
            _inputer.Validator = validator;

            bool isValid = true;
            do
            {
                _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.EnterDay)));
                _screen.Refresh();

                validator.Min = 1;
                validator.Max = 31;

                int day = _inputer.GetNumber();

                if (!isValid)
                {
                    _screen.RemoveLastMessages(1);
                }
                _screen.RemoveLastMessages(1);
                _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.EnterMonth)));
                _screen.Refresh();

                validator.Max = 12;
                int month = _inputer.GetNumber();

                _screen.RemoveLastMessages(1);
                _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.EnterYear)));
                _screen.Refresh();

                validator.Min = 1900;
                validator.Max = DateTime.Now.Year;

                int year = _inputer.GetNumber();

                _screen.RemoveLastMessages(1);

                try
                {
                    birthDate = new ValueConverter().ToDate(day, month, year);
                    break;
                }
                catch (InvalidValueException e)
                {
                    _screen.AddMessage(new Message(e.Message, ConsoleColor.Red));
                    _screen.Refresh();
                    isValid = false;
                }

            } while (true);

            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.DateOfBirth)));
            _screen.AddMessage(new Message($"{birthDate:yyyy-MM-dd}"));
            _screen.Refresh();

            return birthDate;
        }

        private void AddHeroes()
        {
            var validator = new ValueValidator();
            _inputer.Validator = validator;

            _screen.AddMessage(new Message($"{TextRepository.Get(CreatorMsg.HeroesCount)}"));
            _screen.AddMessage(new Message($"{_player.Heroes.Count}", ConsoleColor.Green));
            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.WantToAddHero)));
            _screen.Refresh();

            char yesNoAnswer = _inputer.GetKey(new[] { 'y', 'n' });

            if (yesNoAnswer == 'n')
                return;

            do
            {
                new HeroCreator(_player).Run();

                _screen.RemoveLastMessages(3);
                _screen.AddMessage(new Message($"{TextRepository.Get(CreatorMsg.HeroesCount)}"));
                _screen.AddMessage(new Message($"{_player.Heroes.Count}", ConsoleColor.Green));
                _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.WantToAddAnotherHero)));
                _screen.Refresh();

                yesNoAnswer = _inputer.GetKey(new[] { 'y', 'n' });

            } while (yesNoAnswer == 'y');
        }
    }
}