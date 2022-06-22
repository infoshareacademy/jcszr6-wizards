using System;
using System.Collections.Generic;
using System.Linq;
using Wizards.BusinessLogic.Services.FileOperations;
using Wizards.BusinessLogic.Services.ModelsValidation;

namespace Wizards.BusinessLogic.Services
{
    public class PlayerService : IPlayerService
    {
        private List<Player> _players;
        private readonly IGameDataService _gameDataService;
        private readonly IPlayerValidator _playerValidator;

        public PlayerService(IGameDataService gameDataService, IPlayerValidator playerValidator)
        {
            _gameDataService = gameDataService;
            _gameDataService.LoadGameData();
            _playerValidator = playerValidator;
            _players = GameDataRepository.GetAllPlayers();
        }

        public void Add(Player player)
        {
            player.SetId(GetUniqueId());
            _playerValidator.ValidateForCreate(player);
            _players.Add(player);

            GameDataRepository.UpdateAllPlayers(_players);
            _gameDataService.UpdateGameData();
        }

        public void DeleteById(int id)
        {
            var player = GetById(id);
            _players.Remove(player);
            
            _gameDataService.UpdateGameData();
        }

        public void Update(int id, Player player)
        {
            _playerValidator.ValidateForUpdate(player);
            
            var playerToUpdate = GetById(id);
            
            playerToUpdate.Email = player.Email;
            playerToUpdate.DateOfBirth = player.DateOfBirth;

            _gameDataService.UpdateGameData();
        }

        public void UpdatePassword(int id, Player player)
        {
            _playerValidator.ValidateForPasswordUpdate(player);

            var playerToUpdate = GetById(id);

            playerToUpdate.Password = player.Password;

            _gameDataService.UpdateGameData();
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

        public int GetIdByLogin(string userName, string password)
        {
            var player = _players.FirstOrDefault(p => p.UserName == userName && p.Password == password);

            if (player != null)
            {
                return player.Id;
            }

            throw new NullReferenceException("Login data incorrect!");
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