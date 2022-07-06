using Wizards.Core.Model;
using System.Collections;


namespace Wizards.Services.Searching
{
    public class SearchingByBirthday
    {
        //Jako klient chciałbym znaleźć graczy, którzy będą odpowiadać kryterium "data urodzenia*"* (zakres od-do) wprowadzonemu przez użytkownika, aby być zawsze na bieżąco z wynikami w aplikacji.
        //    Ta funkcjonalność powinna być możliwa do wybrania z menu konsolowego.


        static public void Birthday()
        {

            var listPlayers = new List<Core.Model.Player>();

            var listByBirthdays = listPlayers.OrderBy(n => n.UserName).ToList();
        

            Console.WriteLine("Wpisz datę urodzenia");
            Console.WriteLine("Od: ");
            DateTime birthdayPlayerFrom = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Do: ");
            DateTime birthdayPlayerTo = DateTime.Parse(Console.ReadLine());
           

            foreach (var listByBirthday in listByBirthdays)
            {
                if (listByBirthday.DateOfBirth <= birthdayPlayerTo && listByBirthday.DateOfBirth >= birthdayPlayerFrom)
                {
                    Console.WriteLine(
                        $"{listByBirthday.Id}, {listByBirthday.UserName}, {listByBirthday.Email}, {listByBirthday.DateOfBirth}");
                }
            }
            Console.WriteLine("Wciśnij dowolny przycisk, aby wrócić do poprzedniego okna.");
        }
    }
}

