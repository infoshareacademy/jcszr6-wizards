using DustInTheWind.ConsoleTools.Controls.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wizards.BusinessLogic;


namespace Wizards.GUI
{
    internal class MainMenuItems
    {

        public static void ShowAuthors()
        {
            Console.Clear();
            Console.WriteLine("Zespół Wizards w składzie:\n");
            Console.WriteLine("Adrian Zamysłowski:");
            Console.WriteLine("Jakub Oczko:");
            Console.WriteLine("Paweł Grajnert,");
            Console.WriteLine("Paweł Dawicki\n");
            Console.WriteLine("Wciśnij dowolny przycisk, aby wrócić do poprzedniego okna.");
            Console.ReadKey();
            Console.Clear();
        }

    }

    internal class RefreshData : ICommand
    {
        bool ICommand.IsActive => true;

        void ICommand.Execute()
        {
            Console.Clear();
            Console.WriteLine("Uaktualnij dane");
            Console.ReadKey();
            ScrollMainMenu.DisplayMenu();
        }
    }

    internal class AddElement : ICommand
    {
        bool ICommand.IsActive => true;

        void ICommand.Execute()
        {
            Console.Clear();
            Console.WriteLine("Dodaj element");
            Console.ReadKey();
            ScrollMainMenu.DisplayMenu();
        }
    }

    internal class EditElement : ICommand
    {
        bool ICommand.IsActive => true;

        void ICommand.Execute()
        {
            Console.Clear();
            Console.WriteLine("Edycja");
            Console.ReadKey();
            ScrollMainMenu.DisplayMenu();
        }
    }

    internal class Search : ICommand
    {
        bool ICommand.IsActive => true;

        void ICommand.Execute()
        {
            Console.Clear();
            Console.WriteLine("Wyszukiwanie");
            Console.ReadKey();
            ScrollMainMenu.DisplayMenu();
        }
    }



    public class Exit : ICommand
    {
        bool ICommand.IsActive => true;

        void ICommand.Execute()
        {
            Console.Clear();
            Console.WriteLine("A więc żegnaj.");
            Console.WriteLine();
            Console.Write("Zwalnianie zasobów systemowych: ");
            ProgressBar.DisplayProgressBar();

        }
    }

    internal class ShowAuthors : ICommand
    {
        bool ICommand.IsActive => true;

        void ICommand.Execute()
        {

            MainMenuItems.ShowAuthors();
            ScrollMainMenu.DisplayMenu();
        }
    }


}

