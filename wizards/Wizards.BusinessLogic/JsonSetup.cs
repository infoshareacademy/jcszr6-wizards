using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Wizards.BusinessLogic.Model.Items;

namespace Wizards.BusinessLogic
{
    public static class JsonSetup
    {
        public static List<Player> PlayersListGenerator(int numberOfPlayers)
        {
            List<Player> resultList = new List<Player>();

            for (int i = 0; i < numberOfPlayers; i++)
            {
                resultList.Add(CreateRandomPlayer(i + 1));
            }

            return resultList;
        }

        private static Player CreateRandomPlayer(int id)
        {
            Player player = new Player();

            player.Id = id * 1000;
            player.UserName = $"test-player-{id}";
            player.Password = $"test_{id}";
            player.Email = $"testplayer{id}@wizards.com";

            int month = new Random().Next(1, 13);
            int day = new Random().Next(1, 29);
            player.DateOfBirth = DateTime.Parse($"{1990 + id}-{month}-{day}");

            int heroesCount = new Random().Next(1, 4);
            player.Heroes = CreateHeroesList(heroesCount, 1000 * id);

            return player;
        }

        private static List<Hero> CreateHeroesList(int heroesCount, int id)
        {
            List<Hero> heroList = new List<Hero>();

            for (int i = 0; i < heroesCount; i++)
            {
                heroList.Add(CreateRandomHero(id + (i + 1) * 100));
            }

            return heroList;
        }

        private static Hero CreateRandomHero(int id)
        {
            Hero hero = new Hero(id, $"wizard-{id}");

            hero.Inventory = CreateItemList(id);
            hero.Gold = new Random().Next(0, 5001);
            hero.RankPoints = new Random().Next(0, 100001);
            hero.Restrictions = Restriction.Wizard;

            int bPrice1 = new Random().Next(1000, 10001);
            int sPrice1 = (int)Math.Round(bPrice1 * 0.75m, 0);

            int bPrice2 = new Random().Next(1000, 10001);
            int sPrice2 = (int)Math.Round(bPrice2 * 0.75m, 0);

            int stat1 = new Random().Next(5, 51);
            int stat2 = new Random().Next(5, 51);

            int id1 = id + 91;
            int id2 = id + 92;

            hero.Equipped = new List<Item>
            {
                new Weapon(id1,$"staff-{id1}",bPrice1,sPrice1,stat1),
                new Armor(id2,$"armor-{id2}",bPrice2,sPrice2,stat2)
            };

            return hero;
        }

        private static List<Item> CreateItemList(int id)
        {
            List<Item> itemList = new List<Item>();

            int itemCount = new Random().Next(4, 8);

            for (int i = 0; i < itemCount; i++)
            {
                itemList.Add(CreateItem(id + i + 1));
            }

            return itemList;
        }

        private static Item CreateItem(int id)
        {
            Item item;

            int bPrice = new Random().Next(1000, 10001);
            int sPrice = (int)Math.Round(bPrice * 0.75m, 0);
            int stat = new Random().Next(5, 51);


            if (new Random().Next(100) > 50)
            {
                item = new Weapon(id, $"staff-{id}", bPrice, sPrice, stat);
            }
            else
            {
                item = new Armor(id, $"armor-{id}", bPrice, sPrice, stat);
            }

            return item;
        }

        public static void JsonCreate(int playersCount = 15)
        {
            string path = GetJsonDirectory();
            string json = JsonConvert.SerializeObject(PlayersListGenerator(playersCount));
            Console.WriteLine("Json created.");
            File.WriteAllText(path, json.ToString());
        }

        public static string GetJsonDirectory()
        {
            string result;
            var directory = new DirectoryInfo(Environment.CurrentDirectory);

            while (!directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }
            result = Path.Combine(directory.FullName, "Wizards.BusinessLogic", "Data", "data.json");
            return result;
        }

        public static void JsonRead()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Data", "data.json");
            var dataFile = File.ReadAllText(path);
            var jsonString = JsonConvert.DeserializeObject<List<Player>>(dataFile);

            foreach (Player player in jsonString)
            {
                Console.WriteLine($"{player.UserName} | {player.Email} | {player.Heroes[0].NickName} | {player.Heroes[0].Equipped[0].Name}");
            }
        }
    }
}