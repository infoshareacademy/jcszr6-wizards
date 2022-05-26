using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading;
using System.Media;
using Newtonsoft.Json;
using Wizards.BusinessLogic;
using Wizards.BusinessLogic.Model.Items;

namespace Wizards.GUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ValidatorTest();

            Console.Write("Ładowanie Unreal Engine 5: ");
            using (var progress = new ProgressBar())
            {
                for (int i = 0; i <= 100; i++)
                {
                    progress.Report((double)i / 100);
                    Thread.Sleep(20);
                }
            }

            if (OperatingSystem.IsWindows())
            {
                SoundPlayer player = new SoundPlayer(@"MenuMusic-1.wav");
                player.Load();
                player.PlayLooping();
            }

            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu.ShowMenu();
            }
        }

        private static void ValidatorTest()
        {
            var validator = new ValueValidator(new List<string>() { "kuropatfa stara" })
            {
                Min = 3,
                Max = 15,
                AllowSpace = true,
                AllowSpecialCharacters = true
            };

            string[] lista = new string[]
            {
                "kuropatfa stara nadworna",
                "kuropatfa Stara",
                "Kurwa Xd",
                "id5099",
                "kran$",
                "Ktsrmno 2011",
                "1995-12-18",
                "Kosmos#$",
                "Twoja Stara"
            };

            foreach (var item in lista)
            {
                try
                {
                    validator.Validate(item);
                    Console.WriteLine($"{item} jest poprawny");
                }
                catch (InvalidValueException e)
                {
                    Console.WriteLine($"{e.Message} {item}");
                }
            }
        }
    }
}
