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

            ProgressBar.DisplayProgressBar();

            if (OperatingSystem.IsWindows())
            {
                SoundPlayer player = new SoundPlayer(@"MenuMusic-1.wav");
                player.Load();
                player.PlayLooping();
            }
            FilesOperations.LoadGameData();
            ScrollMainMenu.DisplayScrollMenu();


        }


    }


}
