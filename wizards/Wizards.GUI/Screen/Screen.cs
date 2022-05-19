using System;
using System.Collections.Generic;

namespace Wizards.GUI.Screen
{
    public class Screen
    {
        private List<Message> messages = new List<Message>();

        public void AddMessage(Message msg)
        {
            messages.Add(msg);
        }

        public void RemoveMessage(int msgIndex)
        {
            messages.RemoveAt(msgIndex);
        }

        public void RemoveMessage(Message msg)
        {
            messages.Remove(msg);
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
        }

    }
}