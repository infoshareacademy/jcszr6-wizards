
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Wizards.BusinessLogic.Services.FileOperations
{
    public class GameDataService : IGameDataService
    {
        public void UpdateGameData()
        {
            var path = GetJsonDirectory();
            var json = JsonConvert.SerializeObject(Repository.GetAllPlayers());
            File.WriteAllText(path, json);
        }

        public void LoadGameData()
        {
            var path = GetJsonDirectory();
            if (File.Exists(path))
            {
                var dataFile = File.ReadAllText(path);
                var players = JsonConvert.DeserializeObject<List<Player>>(dataFile);
                Repository.UpdateAllPlayers(players);
            }
        }

        private static string GetJsonDirectory()
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
    }
}