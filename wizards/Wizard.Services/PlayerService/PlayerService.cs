using Wizards.Core.Interfaces;
using Wizards.Core.Model;
using Wizards.Services.Validation;

namespace Wizards.Services.PlayerService
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IPlayerValidator _playerValidator;

        public PlayerService(IPlayerRepository playerRepository, IPlayerValidator playerValidator)
        {
            _playerRepository = playerRepository;
            _playerValidator = playerValidator;
        }

        public async Task Add(Player player)
        {
            await _playerValidator.ValidateForCreate(player);
            await _playerRepository.Add(player);
        }

        public async Task Delete(int id)
        {
            var player = await Get(id);
            await _playerRepository.Remove(player);
        }

        public async Task Update(int id, Player player)
        {
            await _playerValidator.ValidateForUpdate(player);
            
            var playerToUpdate = await Get(id);
            
            playerToUpdate.Email = player.Email;
            playerToUpdate.DateOfBirth = player.DateOfBirth;

            await _playerRepository.Update(playerToUpdate);
        }

        public async Task UpdatePassword(int id, Player player)
        {
            _playerValidator.ValidateForPasswordUpdate(player);

            var playerToUpdate = await Get(id);

            playerToUpdate.Password = player.Password;

            await _playerRepository.Update(playerToUpdate);
        }

        public async Task<Player> Get(int id)
        {
            var player = await _playerRepository.Get(id);

            if (player != null)
            {
                return player;
            }

            throw new NullReferenceException($"There is no Player with id: {id}!");
        }

    }
}