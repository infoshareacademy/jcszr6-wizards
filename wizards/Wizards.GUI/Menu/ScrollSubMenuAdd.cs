using System;
using DustInTheWind.ConsoleTools.Controls.Menus.MenuItems;
using DustInTheWind.ConsoleTools.Controls.Menus;

namespace Wizards.GUI.Menu
{
    internal class ScrollSubMenuAdd
    {
        public static void DisplayScrollSubMenuAdd()
        {



            ScrollMenu scrollSubMenuAdd = new ScrollMenu
            {

                Margin = 1,
                HorizontalAlignment = DustInTheWind.ConsoleTools.Controls.HorizontalAlignment.Left,
                ItemsHorizontalAlignment = DustInTheWind.ConsoleTools.Controls.HorizontalAlignment.Left,
                EraseAfterClose = true


            };

            scrollSubMenuAdd.AddItems(new IMenuItem[]
            {
                new LabelMenuItem
                {
                    Text = "Dodaj gracza",
                    Command = new AddPlayerMenuClassItem()
                },

                new LabelMenuItem
                {
                    Text = "Dodaj bohatera",
                    Command = new AddHeroMenuClassItem()
                },

                new LabelMenuItem
                {
                    Text = "Dodaj przedmiot",
                    Command = new AddItemMenuCLassItem()
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

            scrollSubMenuAdd.Display();
        }
    }
}
