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
            
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Directory.CreateDirectory(path);
            }

            var json = JsonConvert.SerializeObject(GameDataRepository.GetAllPlayers());

            using (var writer = File.CreateText(path))
            {
                writer.Write(json);
            }

        }

        public void LoadGameData()
        {
            var path = GetJsonDirectory();
            
            if (File.Exists(path))
            {
                string dataFile;
                
                using (var reader = File.OpenText(path))
                {
                    dataFile = reader.ReadToEnd();
                }
                
                var players = JsonConvert.DeserializeObject<List<Player>>(dataFile);
            
                GameDataRepository.UpdateAllPlayers(players);
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