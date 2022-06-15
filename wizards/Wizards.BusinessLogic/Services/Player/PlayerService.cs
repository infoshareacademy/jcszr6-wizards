using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Wizards.BusinessLogic.Services
{
    public class PlayerService : IPlayerService
    {
        private List<Player> _players;

        public PlayerService()
        {
            _players = Repository.GetAllPlayers();
        }

        public void Add(Player player)
        {
            //TODO: Validate player!
            player.SetId(GetUniqueId());
            _players.Add(player);
            Repository.UpdateAllPlayers(_players);
        }

        public void DeleteById(int id)
        {
            var player = GetById(id);
            _players.Remove(player);
        }

        public void Update(int id, Player player)
        {
            //TODO: Validate player!
            var playerToUpdate = GetById(id);

            playerToUpdate.Password = player.Password;
            playerToUpdate.Email = player.Email;
            playerToUpdate.DateOfBirth = player.DateOfBirth;
        }

        public IEnumerable<Player> GetAll()
        {
            return _players.AsEnumerable();
        }

        public Player GetById(int id)
        {
            var player = _players.FirstOrDefault(p => p.Id == id);

            if (player != null)
            {
                return player;
            }

            throw new NullReferenceException($"There is no Player with id{id}!");
        }

        private int GetUniqueId()
        {
            
            var uniqueId = 1;
            
            if (_players.Count == 0)
            {
                return uniqueId;
            }

            int maxId = _players.Max(p => p.Id);
            
            if (maxId < _players.Count)
            {
                while (_players.Any(p => p.Id == uniqueId))
                {
                    uniqueId++;
                }
            }
            else
            {
                uniqueId = maxId + 1;
            }

            return uniqueId;
        }
    }
}