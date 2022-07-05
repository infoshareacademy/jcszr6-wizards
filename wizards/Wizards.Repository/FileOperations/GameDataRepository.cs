using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Wizards.BusinessLogic.Services.FileOperations
{
    public class GameDataRepository : IGameDataRepository
    {
        public void Update(List<Player> players)
        {
            var path = GetJsonDirectory();
            
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Directory.CreateDirectory(path);
            }

            var json = JsonConvert.SerializeObject(players);

            using (var writer = File.CreateText(path))
            {
                writer.Write(json);
            }
        }

        public List<Player> Get()
        {
            var path = GetJsonDirectory();
            
            if (File.Exists(path))
            {
                string dataFile;
                
                using (var reader = File.OpenText(path))
                {
                    dataFile = reader.ReadToEnd();
                }
                
                return JsonConvert.DeserializeObject<List<Player>>(dataFile);
            }

            return new List<Player>();
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