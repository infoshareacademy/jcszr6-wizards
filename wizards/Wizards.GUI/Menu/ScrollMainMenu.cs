using System;
using DustInTheWind.ConsoleTools.Controls.Menus.MenuItems;
using DustInTheWind.ConsoleTools.Controls.Menus;


namespace Wizards.GUI
{
    internal class ScrollMainMenu
    {

        public static void DisplayScrollMenu()
        {



            ScrollMenu scrollMenu = new ScrollMenu
            {

                Margin = 1,                
                EraseAfterClose = false,
                HorizontalAlignment = DustInTheWind.ConsoleTools.Controls.HorizontalAlignment.Left,
                ItemsHorizontalAlignment = DustInTheWind.ConsoleTools.Controls.HorizontalAlignment.Left,
                
            };

            scrollMenu.AddItems(new IMenuItem[]
            {
                new YesNoMenuItem
                {
                    Text = "Uaktualnij dane",
                    Command = new RefreshData()
                },

                new LabelMenuItem
                {
                    Text = "Dodaj element",
                    Command = new AddElement()
                },

                new LabelMenuItem
                {
                    Text = "Edycja",
                    Command = new EditElement()
                },

                new LabelMenuItem
                {
                    Text = "Wyszukiwanie",
                    Command = new Search()
                },

                new LabelMenuItem
                {
                    Text = "Authors",
                    Command = new ShowAuthors()
                },

                new SeparatorMenuItem(),

                new YesNoMenuItem
                {
                    Text = "Exit",
                    Command = new Exit()
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
            string version = "0.1";

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(logo);
            Console.ResetColor();
            Console.WriteLine($"Ver.: {version}");

            scrollMenu.Display();
        }

    }
}

