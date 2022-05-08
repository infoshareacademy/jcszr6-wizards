using System;
using System.Threading;
using System.Media;

namespace Wizards.GUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ładowanie Unreal Engine 5: ");
            using (var progress = new ProgressBar())
            {
                for (int i = 0; i <= 100; i++)
                {
                    progress.Report((double)i / 100);
                    Thread.Sleep(20);
                }
            }

            //if (OperatingSystem.IsWindows())
            //{
            //    SoundPlayer player = new SoundPlayer(@"Fun_House.wav");
            //    player.Load();
            //    player.PlayLooping();
            //}

            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu.ShowMenu();
            }
        }
    }
}
