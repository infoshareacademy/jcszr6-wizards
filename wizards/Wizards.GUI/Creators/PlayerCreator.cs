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
        public void Run()
        {
            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.Title)));

            var userName = SetUserName();
            var password = SetPassword();
            var email = SetEmail();
            var birthDate = SetBirthDate();
            
            var createdPlayer = new Player(1, userName, password, email, birthDate);
            _modelsMenagement.AddPlayer(createdPlayer);

            AddHeroes();

            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.PlayerAdded)));
            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.PressKeyToExit)));
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


            do
            {
                _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.EnterDay)));
                _screen.Refresh();

                validator.Min = 1;
                validator.Max = 31;
                
                int day = _inputer.GetNumber();
                _screen.AddMessage(new Message($"{day}", ConsoleColor.Green));

                _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.EnterMonth)));
                _screen.Refresh();
                
                validator.Max = 12;
                int month = _inputer.GetNumber();
                _screen.AddMessage(new Message($"{month}", ConsoleColor.Green));

                _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.EnterYear)));
                _screen.Refresh();
                
                validator.Min = 1900;
                validator.Max = DateTime.Now.Year;
                
                int year = _inputer.GetNumber();
                _screen.AddMessage(new Message($"{year}", ConsoleColor.Green));

                try
                {
                    birthDate = new ValueConverter().ToDate(day, month, year);
                    break;
                }
                catch (InvalidValueException e)
                {
                    _screen.AddMessage(new Message(e.Message, ConsoleColor.Red));
                    _screen.Refresh();
                    Console.ReadKey(true);
                    _screen.RemoveLastMessages(1);
                    _screen.Refresh();
                }

            } while (true);

            return birthDate;
        }

        private void AddHeroes()
        {
            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.WantToAddHeroes)));
            _screen.Refresh();

            var validator = new ValueValidator();
            _inputer.Validator = validator;

            char yesNoAnswer = _inputer.GetKey(new []{'y','n'});

            if (yesNoAnswer == 'n')
                return;

            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.HowManyHeroes)));
            _screen.Refresh();

            validator.Min = 1;
            validator.Max = 5;

            int heroCountToAdd = _inputer.GetNumber();

            for (int i = 0; i < heroCountToAdd; i++)
            {
                new HeroCreator(_player).Run();
            }
        }


    }
}