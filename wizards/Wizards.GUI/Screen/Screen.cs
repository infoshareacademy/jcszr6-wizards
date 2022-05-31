using System;
using System.Collections.Generic;

namespace Wizards.GUI
{
    public class Screen
    {
        private List<Message> messages = new List<Message>();

        public void AddMessage(Message msg)
        {
            messages.Add(msg);
        }

        public void RemoveLastMessages(int numberOfLastMessagesToDelete)
        {
            messages.RemoveRange(messages.Count - numberOfLastMessagesToDelete, numberOfLastMessagesToDelete);
        }

        public void ClearMessages()
        {
            messages.Clear();
        }

        public void Refresh()
        {
            Console.Clear();
            foreach (var message in messages)
            {
                Console.ForegroundColor = message.TextColor;
                Console.BackgroundColor = message.BackColor;
                Console.Write(message.Text);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }

    }
}