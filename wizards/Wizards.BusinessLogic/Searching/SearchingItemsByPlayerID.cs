using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizards.BusinessLogic.Searching
{
    public class SearchingItemsByPlayerID
    {
        //Jako klient chciałbym znaleźć wszystkie przedmioty należące do gracza o konkretnym ID wprowadzonym przez użytkownika, 
        //aby być zawsze na bieżąco z wynikami w aplikacji.

        public static void Search()
        {

            var listPlayers = new List<Player>();

            var playersOrderByID = listPlayers.OrderBy(i => i.Id).ToList();

            playersOrderByID.ForEach(p => Console.WriteLine($"Player: {p.Id}, {p.UserName}"));

            Console.WriteLine("Proszę podaj Id gracza: ");

            var inputPlayerId = int.Parse(Console.ReadLine());

            var player = playersOrderByID.FirstOrDefault(p => p.Id == inputPlayerId);

            var playerHeroes = player.Heroes;

            Console.Clear();

            Console.WriteLine($"Player: {player.Id}, {player.UserName}");

            playerHeroes.ForEach(hero =>
            {
                Console.WriteLine($"{hero.Id}, {hero.NickName}");

                Console.WriteLine("Przedmioty w inwentarzu");

                hero.Inventory.ForEach(i => Console.WriteLine($"{i.Id}, {i.Name}"));

                Console.WriteLine("Przedmioty w ekwipunku");

                hero.Equipped.ForEach(i => Console.WriteLine($"{i.Id}, {i.Name}"));
            });
        }
    }

}
