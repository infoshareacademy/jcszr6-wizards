using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Wizards.BusinessLogic
{
    public class FilesOperations
    {
        public static void JsonCreate(int playersCount = 15)
        {
            string path = GetJsonDirectory();
            string json = JsonConvert.SerializeObject(JsonSetup.PlayersListGenerator(playersCount));
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
            result = Path.Combine(directory.FullName, "Wizards.BusinessLogic", "Data", "data3.json");
            return result;
        }

        public static void JsonRead()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Data", "data3.json");
            var dataFile = File.ReadAllText(path);
            var jsonString = JsonConvert.DeserializeObject<List<Player>>(dataFile);
            Console.WriteLine($"Path: {path}");
            foreach (Player player in jsonString)
            {
                Console.WriteLine($"{player.UserName} | {player.Email} | {player.Heroes[0].NickName} | {player.Heroes[0].Equipped[0].Name}");
            }
        }

        public static void RemoveJson()
        {
            string path = GetJsonDirectory();
            Console.WriteLine("*************************");
            Console.WriteLine($"{path}");
            File.Delete(path);
        }

        public static void PrintRepoPlayers()
        {
            //var players = Repository.Players;
            foreach (var player in Repository.Players)
            {
                //Console.WriteLine($"{player.UserName} | {player.Email} | {player.Heroes[0].NickName} | {player.Heroes[0].Equipped[0].Name}");
                Console.WriteLine($"{player.UserName} | {player.Email}");
            }
        }

        public static void SaveGameData()
        {
            var path = GetJsonDirectory();
            Console.WriteLine($"{path}");
            string json = JsonConvert.SerializeObject(Repository.Players);

            Console.WriteLine("Json created.");
            File.WriteAllText(path, json.ToString());

        }

        public static void LoadGameData()
        {
            var path = GetJsonDirectory();
            Console.WriteLine($"{path}");
            var dataFile = File.ReadAllText(path);
            
            Repository.Players = JsonConvert.DeserializeObject<List<Player>>(dataFile);
        }
    }
}