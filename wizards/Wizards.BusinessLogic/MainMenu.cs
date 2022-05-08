using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Wizards.BusinessLogic
{
    internal class MainMenu
    {
        public static bool ShowMenu()
        {
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
            Console.WriteLine();
            Console.WriteLine("Choose an option:\n");
            Console.WriteLine("1) Logowanie,");
            Console.WriteLine("2) Założenie konta,");
            Console.WriteLine("3) O grze,");
            Console.WriteLine("4) Odczyt z CSV,");
            Console.WriteLine("5) Zapis do CSV,");
            Console.WriteLine("9) Wyjście.\n");
            Console.Write("Wybierz opcję: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Wybrałeś zalogowanie");
                    Console.WriteLine("Wciśnij dowolny przycisk, aby wrócić do poprzedniego okna.");
                    Console.ReadKey();
                    return true;
                case "2":
                    Console.WriteLine("Wybrałeś założenie konta");
                    HeroApi.GetHeroName();
                    return true;
                case "3":
                    ShowAuthors();
                    return true;
                case "4":
                    FilesOperations.ReadCSVFile();
                    return true;
                case "5":
                    FilesOperations.AppendToCSV();
                    Console.WriteLine("Wciśnij dowolny przycisk, aby wrócić do poprzedniego okna.");
                    Console.ReadLine();
                    return true;
                case "9":
                    Console.Clear();
                    Console.WriteLine("A więc żegnaj.");
                    Console.WriteLine();
                    Console.Write("Zwalnianie zasobów systemowych: ");
                    using (var progress = new ProgressBar())
                    {
                        for (int i = 0; i <= 100; i++)
                        {
                            progress.Report((double)i / 100);
                            Thread.Sleep(20);
                        }
                    }

                    return false;
                default:
                    return true;
            }

        }

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
        }

    }
}
