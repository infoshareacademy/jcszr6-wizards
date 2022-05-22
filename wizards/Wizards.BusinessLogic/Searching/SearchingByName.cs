using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizards.BusinessLogic.Searching
{
    public class SearchingByName
    {
        //Jako klient chciałbym znaleźć gracza, który będzie odpowiadać kryterium "nazwa" wprowadzonemu przez użytkownika.Funkcja ma zwrócić wszystkich użytkowników,
        //którzy spełniają kryterium, filtrowanie ma wykonać oddzielna klasa, która otrzyma od nas List<Player?>() aby być zawsze na bieżąco z wynikami w aplikacji.

        //    Ta funkcjonalność powinna być możliwa do wybrania z menu konsolowego.

        static public void Name()
        {

            var listPlayers = new List<Player>();

            var listByNames = listPlayers.OrderBy(n => n.UserName).ToList();

            Console.WriteLine("Wpisz nazwę gracza: ");
            var nameOfPlayer = Console.ReadLine();


            foreach (var listByName in listByNames)
            {
                if (listByName.UserName.Contains(nameOfPlayer))
                {
                    Console.WriteLine($"{listByName.Id}, {listByName.UserName}, {listByName.Email}, {listByName.DateOfBirth}");
                }
            }
            Console.WriteLine("Wciśnij dowolny przycisk, aby wrócić do poprzedniego okna.");
            Console.ReadKey();

        }
    }
}
