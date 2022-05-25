﻿using System;
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

        public static void RemoveJson()
        {
            string path = GetJsonDirectory();
            Console.WriteLine("*************************");
            Console.WriteLine($"{path}");
            File.Delete(path);
        }
    }
}

