using System;
using DustInTheWind.ConsoleTools.Controls.Menus.MenuItems;
using DustInTheWind.ConsoleTools.Controls.Menus;

namespace Wizards.GUI.Menu
{
    internal class ScrollSubMenuSearch
    {
        public static void DisplayScrollSubMenuSearch()
        {



            ScrollMenu scrollSubMenuSearch = new ScrollMenu
            {

                Margin = 1,
                EraseAfterClose = false,
                HorizontalAlignment = DustInTheWind.ConsoleTools.Controls.HorizontalAlignment.Left,
                ItemsHorizontalAlignment = DustInTheWind.ConsoleTools.Controls.HorizontalAlignment.Left,

            };

            scrollSubMenuSearch.AddItems(new IMenuItem[]
            {
                new LabelMenuItem
                {
                    Text = "Wyszukaj gracza po nazwie",
                    Command = new SearchPlayerByNameMenuClassItem()
                },

                new LabelMenuItem
                {
                    Text = "Wyszukaj gracza po dacie",
                    Command = new SearchPalyerByDateHeroMenuClassItem()
                },

                new LabelMenuItem
                {
                    Text = "Wyszukiwanie itemu po rodzaju",
                    Command = new SearchItemsByTypeItemMenuCLassItem()
                },

                new LabelMenuItem
                {
                    Text = "Wyszukiwanie przedmiotow nalezacych do gracza",
                    Command = new SearchPlayerItemsMenuCLassItem()
                },

                new SeparatorMenuItem(),

                new LabelMenuItem
                {
                    Text = "To main menu",
                    Command = new ToMainMenu()
                },

                });

            string logo = @"
 __       __  __                                     __                 
|  \  _  |  \|  \                                   |  \                
| $$ / \ | $$ \$$ ________  ______    ______    ____| $$  _______       
| $$/  $\| $$|  \|        \|      \  /      \  /      $$ /       \      
| $$  $$$\ $$| $$ \$$$$$$$$ \$$$$$$\|  $$$$$$\|  $$$$$$$|  $$$$$$$      
| $$ $$\$$\$$| $$  /    $$ /      $$| $$   \$$| $$  | $$ \$$    \       
| $$$$  \$$$$| $$ /  $$$$_|  $$$$$$$| $$      | $$__| $$ _\$$$$$$\      
| $$$    \$$$| $$|  $$    \\$$    $$| $$       \$$    $$|       $$      
 \$$      \$$ \$$ \$$$$$$$$ \$$$$$$$ \$$        \$$$$$$$ \$$$$$$$                                                                                                                                                  
";

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(logo);
            Console.ResetColor();

            scrollSubMenuSearch.Display();
        }
    }
}
