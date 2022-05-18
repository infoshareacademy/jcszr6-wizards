using System;
using DustInTheWind.ConsoleTools.Controls.Menus.MenuItems;
using DustInTheWind.ConsoleTools.Controls.Menus;

namespace Wizards.GUI.Menu
{
    internal class ScrollSubMenuEdit
    {
        public static void DisplayScrollSubMenuEdit()
        {



            ScrollMenu scrollSubMenuEdit = new ScrollMenu
            {

                Margin = 1,
                EraseAfterClose = false,
                HorizontalAlignment = DustInTheWind.ConsoleTools.Controls.HorizontalAlignment.Left,
                ItemsHorizontalAlignment = DustInTheWind.ConsoleTools.Controls.HorizontalAlignment.Left,

            };

            scrollSubMenuEdit.AddItems(new IMenuItem[]
            {
                new LabelMenuItem
                {
                    Text = "Edytuj gracza",
                    Command = new EditPlayerMenuClassItem()
                },

                new LabelMenuItem
                {
                    Text = "Edytuj bohatera",
                    Command = new EditHeroMenuClassItem()
                },

                new LabelMenuItem
                {
                    Text = "Edytuj przedmiot",
                    Command = new EditItemMenuCLassItem()
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
