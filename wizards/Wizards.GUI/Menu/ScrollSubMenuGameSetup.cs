using System;
using DustInTheWind.ConsoleTools.Controls.Menus.MenuItems;
using DustInTheWind.ConsoleTools.Controls.Menus;

namespace Wizards.GUI.Menu
{
    internal class ScrollSubMenuGameSetup
    {
        public static void DisplayScrollSubMenuGameSetup()
        {



            ScrollMenu scrollSubMenuEdit = new ScrollMenu
            {

                Margin = 1,
                HorizontalAlignment = DustInTheWind.ConsoleTools.Controls.HorizontalAlignment.Left,
                ItemsHorizontalAlignment = DustInTheWind.ConsoleTools.Controls.HorizontalAlignment.Left,
                EraseAfterClose = true

            };

            scrollSubMenuEdit.AddItems(new IMenuItem[]
            {
                new LabelMenuItem
                {
                    Text = "Wygeneruj nowy seed gry",
                    Command = new NewJsocnFile()
                },

                new LabelMenuItem
                {
                    Text = "Skasuj Json-a",
                    Command = new DelJsonFile()
                },

                new LabelMenuItem
                {
                    Text = "Pokaż seeda",
                    Command = new ShowJsonSeed()
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

            scrollSubMenuEdit.Display();
        }
    }
}
