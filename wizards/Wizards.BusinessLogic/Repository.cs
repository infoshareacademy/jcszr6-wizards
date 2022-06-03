using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Wizards.BusinessLogic
{
    public static class Repository
    {
        public static List<Player> Players = new List<Player>();
        
        static Repository()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Data", "data.json");
            var dataFile = File.ReadAllText(path);
            Players = JsonConvert.DeserializeObject<List<Player>>(dataFile);
        }

        public static List<Player> GetAllPlayers()
        {
            return Players;
        }
    }
}