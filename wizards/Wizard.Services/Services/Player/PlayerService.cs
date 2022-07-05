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
        private readonly IGameDataRepository _gameDataRepository;
        private readonly IPlayerValidator _playerValidator;

        public PlayerService(IGameDataRepository gameDataRepository, IPlayerValidator playerValidator)
        {
            _gameDataRepository = gameDataRepository;
            _playerValidator = playerValidator;
            _players = _gameDataRepository.Get();
        }

        public void Add(Player player)
        {
            player.Id = GetUniqueId();
            _playerValidator.ValidateForCreate(player);
            
            _players.Add(player);
            
            _gameDataRepository.Update(_players);
        }

        public void Delete(int id)
        {
            var player = Get(id);
            _players.Remove(player);
            
            _gameDataRepository.Update(_players);
        }

        public void Update(int id, Player player)
        {
            _playerValidator.ValidateForUpdate(player);
            
            var playerToUpdate = Get(id);
            
            playerToUpdate.Email = player.Email;
            playerToUpdate.DateOfBirth = player.DateOfBirth;

            _gameDataRepository.Update(_players);
        }

        public void UpdatePassword(int id, Player player)
        {
            _playerValidator.ValidateForPasswordUpdate(player);

            var playerToUpdate = Get(id);

            playerToUpdate.Password = player.Password;

            _gameDataRepository.Update(_players);
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
            while (_players.Any(p => p.Id == newId) || newId <= 0);

            return newId;
        }
    }
}