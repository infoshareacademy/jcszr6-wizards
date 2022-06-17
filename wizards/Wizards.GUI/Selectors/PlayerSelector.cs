using System;
using System.Linq;
using Wizards.BusinessLogic;

namespace Wizards.GUI.Selectors
{
    public class PlayerSelector
    {
        private Player _player;
        private Screen _screen;
        private UserInput _inputer;

        public PlayerSelector()
        {
            _screen = new Screen();
            _inputer = new UserInput();
            _inputer.Screen = _screen;
        }

        public void Select()
        {
            _screen.AddMessage(new Message(TextRepository.Get(SelectorsMsg.SelectPlayer)));

            do
            {
                _screen.AddMessage(new Message(TextRepository.Get(SelectorsMsg.EnterUserName)));
                _screen.Refresh();

                var userName = _inputer.GetText();
                _screen.AddMessage(new Message(userName,ConsoleColor.Green));

                _screen.AddMessage(new Message(TextRepository.Get(SelectorsMsg.EnterPassword)));
                _screen.Refresh();

                var password = _inputer.GetText();
                _screen.AddMessage(new Message("Hasło wprowadzone.",ConsoleColor.Green));

                _player = GameDataRepository.Players.FirstOrDefault(p => p.UserName == userName && p.Password == password);

                if (_player != null)
                    break;

                _screen.AddMessage(new Message(TextRepository.Get(SelectorsMsg.PlayerNotExist),ConsoleColor.Red));
                _screen.Refresh();
                _screen.RemoveLastMessages(5);
                _inputer.WaitForKey();

            } while (true);
            
            _screen.AddMessage(new Message(TextRepository.Get(SelectorsMsg.PlayerSelected),ConsoleColor.Cyan));
            
        }

        public Player ReturnPlayer()
        {
            return _player;
        }
    }
}