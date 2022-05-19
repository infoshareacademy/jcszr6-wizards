using System;

namespace Wizards.GUI.Screen
{
    public class Message
    {
        public string Text { get; private set; }
        public ConsoleColor TextColor { get; private set; }
        public ConsoleColor BackColor { get; private set; }

        public Message(string text, ConsoleColor textColor = ConsoleColor.DarkGray, ConsoleColor backColor = ConsoleColor.Black)
        {
            Text = text;
            TextColor = textColor;
            BackColor = backColor;
        }
    }
}