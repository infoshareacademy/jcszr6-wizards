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

        }
        
        public static List<Player> GetAllPlayers()
        {
            return Players;
        }

        public static void UpdateAllPlayers(List<Player> players)
        {
            if (players != null)
            {
                Players = players;
            }
        }
    }
}