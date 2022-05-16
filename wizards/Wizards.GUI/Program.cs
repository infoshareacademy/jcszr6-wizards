using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Media;
using Newtonsoft.Json;
using Wizards.BusinessLogic;
using Wizards.BusinessLogic.Model.Items;
using System.Threading.Tasks;
using DustInTheWind.ConsoleTools.Controls.Menus.MenuItems;
using DustInTheWind.ConsoleTools.Controls.Menus;

namespace Wizards.GUI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Ładowanie Unreal Engine 5: ");
            //using (var progress = new ProgressBar())
            //{
            //    for (int i = 0; i <= 100; i++)
            //    {
            //        progress.Report((double)i / 100);
            //        Thread.Sleep(20);
            //    }
            //}

            //ManualResetEventSlim finishEvent = new ManualResetEventSlim();
            //finishEvent.Reset();

            //DustInTheWind.ConsoleTools.Controls.Spinners.ProgressBar progressBar = new DustInTheWind.ConsoleTools.Controls.Spinners.ProgressBar();

            //Task.Run<Task>(async () =>
            //{
            //    progressBar.Display();

            //    for (int i = 0; i < 100; i++)
            //    {
            //        await Task.Delay(100);
            //        progressBar.Value++;
            //    }

            //    finishEvent.Set();
            //});

            //finishEvent.Wait();

            //progressBar.Close();


            //if (OperatingSystem.IsWindows())
            //{
            //    SoundPlayer player = new SoundPlayer(@"MenuMusic-1.wav");
            //    player.Load();
            //    player.PlayLooping();
            //}

            //bool showMenu = true;
            //while (showMenu)
            //{
            //    showMenu = MainMenu.ShowMenu();
            //}

            //ScrollMenu.DisplayMenu();
            ScrollMenu.DisplayMenu2();

        }


    }


}
