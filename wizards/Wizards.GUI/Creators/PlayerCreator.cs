using System;
using System.Linq;
using Wizards.BusinessLogic;

namespace Wizards.GUI.Creators
{
    public class PlayerCreator
    {
        private ValueValidator _userNameValidator;
        private ValueValidator _passwordValidator;
        private ValueValidator _emailValidator;
        private ValueValidator _dayValidator;
        private ValueValidator _monthValidator;
        private ValueValidator _yearValidator;
        private ValueValidator _yesNoValidator;
        private Screen _screen;
        private UserInput _inputer;
        public PlayerCreator()
        {
            _userNameValidator = new ValueValidator
            {
                AlredyInUseValues = Repository.Players.Select(p => p.UserName).ToList(),
                AllowSpecialCharacters = true,
                AllowSpace = false,
                Min = 3,
                Max = 20
            };

            _passwordValidator = new ValueValidator
            {
                AllowSpecialCharacters = true,
                Min = 6,
                Max = 25
            };

            _emailValidator = new ValueValidator
            {
                AlredyInUseValues = Repository.Players.Select(p=>p.Email).ToList(),
                AllowSpecialCharacters = true,
                AllowSpace = false,
                Min = 5,
                Max = 100
            };

            _dayValidator = new ValueValidator
            {
                Min = 1,
                Max = 31
            };
            _monthValidator = new ValueValidator
            {
                Min = 1,
                Max = 12
            };
            _yearValidator = new ValueValidator
            {
                Min = 1900,
                Max = DateTime.Now.Year,
            };

            _yesNoValidator = new ValueValidator();
            _screen = new Screen();
            _inputer = new UserInput();
            _inputer.Screen = _screen;
        }
        public void Run()
        {
            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.Title)));

            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.EnterUserName)));
            _screen.Refresh();
            _inputer.Validator = _userNameValidator;
            string userName = _inputer.GetText();
            _screen.AddMessage(new Message($"{userName}\n",ConsoleColor.Green));
            
            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.EnterPassword)));
            _screen.Refresh();
            _inputer.Validator = _passwordValidator;
            string password = _inputer.GetText();
            _screen.AddMessage(new Message($"Hasło przyjęte\n", ConsoleColor.Green));

            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.EnterEmail)));
            _screen.Refresh();
            _inputer.Validator = _emailValidator;
            string email = _inputer.GetText();
            _screen.AddMessage(new Message($"{email}\n", ConsoleColor.Green));

            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.EnterBirthDate)));

            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.EnterDay)));
            _screen.Refresh();
            _inputer.Validator = _dayValidator;
            int day = _inputer.GetNumber();
            _screen.AddMessage(new Message($"{day}\n", ConsoleColor.Green));

            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.EnterMonth)));
            _screen.Refresh();
            _inputer.Validator = _monthValidator;
            int month = _inputer.GetNumber();
            _screen.AddMessage(new Message($"{month}\n", ConsoleColor.Green));

            _screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.EnterYear)));
            _screen.Refresh();
            _inputer.Validator = _yearValidator;
            int year = _inputer.GetNumber();
            _screen.AddMessage(new Message($"{year}\n", ConsoleColor.Green));

            DateTime birthDate = new ValueConverter().ToDate(day, month, year);

            var menage = new ModelsMenagement();
            var createdPlayer = new Player(1, userName, password, email, birthDate);
            menage.AddPlayer(createdPlayer);
        }
    }
}