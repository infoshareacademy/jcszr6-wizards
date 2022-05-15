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

        public static void DisplayMenu()
        {
            DustInTheWind.ConsoleTools.Controls.Menus.ScrollMenu scrollMenu = new DustInTheWind.ConsoleTools.Controls.Menus.ScrollMenu
            {
                //MarginTop = 1,
                //MarginBottom = 1,
                EraseAfterClose = true
            };

            scrollMenu.AddItems(new IMenuItem[]
            {
                            new LabelMenuItem
                            {
                                Text = "New Game",
                                Command = new LoadGameCommand()

                            },
                            //new YesNoMenuItem
                            //{
                            //    Text = "Save Game",
                            //    Command = new SaveGameCommand()
                            //},
                            //new LabelMenuItem
                            //{
                            //    Text = "Load Game",
                            //    Command = new LoadGameCommand()
                            //},
            }
        );

            scrollMenu.Display();
        }
    }

    internal class LoadGameCommand : ICommand
    {
        public bool IsActive => MainMenu.ShowMenu();

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }

    //internal class SaveGameCommand : ICommand
    //{
    //    public bool IsActive => throw new NotImplementedException();

    //    public void Execute()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //internal class NewGameCommand : ICommand
    //{
    //    public bool IsActive => throw new NotImplementedException();

    //    public void Execute()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
