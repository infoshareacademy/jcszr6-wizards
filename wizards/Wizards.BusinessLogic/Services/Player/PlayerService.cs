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

        public void Delete(int id)
        {
            var player = Get(id);
            _players.Remove(player);
            
            _gameDataService.UpdateGameData();
        }

        public void Update(int id, Player player)
        {
            _playerValidator.ValidateForUpdate(player);
            
            var playerToUpdate = Get(id);
            
            playerToUpdate.Email = player.Email;
            playerToUpdate.DateOfBirth = player.DateOfBirth;

            _gameDataService.UpdateGameData();
        }

        public void UpdatePassword(int id, Player player)
        {
            _playerValidator.ValidateForPasswordUpdate(player);

            var playerToUpdate = Get(id);

            playerToUpdate.Password = player.Password;

            _gameDataService.UpdateGameData();
        }

        public IEnumerable<Player> GetAll()
        {
            return _players.AsEnumerable();
        }

        public Player Get(int id)
        {
            var player = _players.SingleOrDefault(p => p.Id == id);

            if (player != null)
            {
                return player;
            }

            throw new NullReferenceException($"There is no Player with id: {id}!");
        }

        private int GetUniqueId()
        {
            int newId;

            do
            {
                newId = BitConverter.ToInt32(Guid.NewGuid().ToByteArray());
            } 
            while (GameDataRepository.GetAllPlayers().Any(p => p.Id == newId) || newId <= 0);

            return newId;
        }
    }
}