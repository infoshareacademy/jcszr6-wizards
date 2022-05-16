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
    internal class ScrollMenu
    {
        //    public static void DisplayMenu()
        //    {
        //        DustInTheWind.ConsoleTools.Controls.Menus.ScrollMenu scrollMenu = new DustInTheWind.ConsoleTools.Controls.Menus.ScrollMenu
        //        {

        //            //Margin = 0,
        //            Padding = 5,
        //            //HorizontalAlignment = DustInTheWind.ConsoleTools.Controls.HorizontalAlignment.Center,

        //            //AllowWrapAround = true,
        //            EraseAfterClose = true,


        //        };

        //        scrollMenu.AddItems(new IMenuItem[]
        //        {
        //            new LabelMenuItem
        //            {
        //                Text = "Uaktualnij dane",
        //                Command = new NewMethod()

        //            },

        //            new LabelMenuItem
        //            {
        //                Text = "Dodaj element",
        //                Command = new NewMethod()

        //            },

        //            new LabelMenuItem
        //            {
        //                Text = "Edycja",
        //                Command = new NewMethod()

        //            },

        //            new LabelMenuItem
        //            {
        //                Text = "Wyszukiwanie",
        //                Command = new NewMethod()

        //            },

        //            new LabelMenuItem
        //            {
        //                Text = "Authors",
        //                Command = new ShowAuthors()

        //            },
        //            new LabelMenuItem
        //            {
        //                Text = "Exit",
        //                Command = new ExitCommand()
        //            },

        //        }

        //    );
        //        Console.Clear();
        //        scrollMenu.Display();
        //    }

        //}

        //internal class NewMethod : ICommand
        //{
        //    bool ICommand.IsActive => true;

        //    void ICommand.Execute()
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Tu wsadz metodę");
        //        Console.ReadKey();
        //        ScrollMenu.DisplayMenu();
        //    }
        //}

        //internal class ShowAuthors : ICommand
        //{
        //    bool ICommand.IsActive => true;

        //    void ICommand.Execute()
        //    {
        //        MainMenu.ShowAuthors();
        //    }
        //}

        //internal class ExitCommand : ICommand
        //{
        //    bool ICommand.IsActive => true;

        //    void ICommand.Execute()
        //    {
        //        Console.Clear();
        //        Console.WriteLine("A więc żegnaj.");
        //        Console.WriteLine();
        //        Console.Write("Zwalnianie zasobów systemowych: ");
        //    }


        //}

        public static void DisplayMenu2()
        {
            DustInTheWind.ConsoleTools.Controls.Menus.ScrollMenu scrollMenu = new DustInTheWind.ConsoleTools.Controls.Menus.ScrollMenu
            {
                //MarginTop = 1,
                //MarginBottom = 1,
                EraseAfterClose = false,
                HorizontalAlignment = DustInTheWind.ConsoleTools.Controls.HorizontalAlignment.Left,
                ItemsHorizontalAlignment = DustInTheWind.ConsoleTools.Controls.HorizontalAlignment.Left,
                
            };

            scrollMenu.AddItems(new IMenuItem[]
            {
        new LabelMenuItem
        {
            Text = "test",
            Command = new NewGameCommand()
        },

        new LabelMenuItem
        {
            Text = "asdasdasdadsadasd",
            Command = new NewGameCommand()
        },

        new LabelMenuItem
        {
            Text = "asdasdasdadsadasd",
            Command = new NewGameCommand()
        },

        new LabelMenuItem
        {
            Text = "New",
            Command = new NewGameCommand()
        },

        new LabelMenuItem
        {
            Text = "New Game",
            Command = new NewGameCommand()
        },
        new YesNoMenuItem
        {
            Text = "Save Game",
            Command = new NewGameCommand()
        },
        new LabelMenuItem
        {
            Text = "Load Game",
            Command = new NewGameCommand()
        },

        });

            scrollMenu.Display();
        }

    }

    internal class NewGameCommand : ICommand
    {
        bool ICommand.IsActive => true;

        void ICommand.Execute()
        {
            Console.WriteLine("dupa");
        }
    }
}

