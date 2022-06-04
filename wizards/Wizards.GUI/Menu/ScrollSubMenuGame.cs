using System;
using DustInTheWind.ConsoleTools.Controls.Menus.MenuItems;
using DustInTheWind.ConsoleTools.Controls.Menus;

namespace Wizards.GUI.Menu
{
    internal class ScrollSubMenuGame
    {
        public static void DisplayScrollSubMenuGame()
        {



            ScrollMenu scrollSubMenuGame = new ScrollMenu
            {

                Margin = 1,
                HorizontalAlignment = DustInTheWind.ConsoleTools.Controls.HorizontalAlignment.Left,
                ItemsHorizontalAlignment = DustInTheWind.ConsoleTools.Controls.HorizontalAlignment.Left,
                EraseAfterClose = true

            };

            scrollSubMenuGame.AddItems(new IMenuItem[]
            {
                new LabelMenuItem
                {
                    Text = "Wyświelt stan gry",
                    Command = new ShowGameData()
                },

                new LabelMenuItem
                {
                    Text = "Wczytaj grę",
                    Command = new LoadGameData()
                },

                new LabelMenuItem
                {
                    Text = "Zapisz grę",
                    Command = new SaveGameData()
                },

                new SeparatorMenuItem(),

                new LabelMenuItem
                {
                    Text = "Powrót",
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

            scrollSubMenuGame.Display();
        }
    }
}
