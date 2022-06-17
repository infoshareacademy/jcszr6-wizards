using System.Collections.Generic;

namespace Wizards.BusinessLogic
{
    public static class GameDataRepository
    {
        public static List<Player> Players { get; private set; }
        
        static GameDataRepository()
        {
            Players = new List<Player>();
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