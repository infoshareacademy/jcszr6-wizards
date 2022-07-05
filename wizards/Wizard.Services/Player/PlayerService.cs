using Wizards.Repository.FileOperations;
using Wizards.Services.Validation;

namespace Wizards.Services.Player
{
    public class PlayerService : IPlayerService
    {
        private List<Core.Model.Player> _players;
        private readonly IWizardsRepository _wizardsRepository;
        private readonly IPlayerValidator _playerValidator;

        public PlayerService(IWizardsRepository wizardsRepository, IPlayerValidator playerValidator)
        {
            _wizardsRepository = wizardsRepository;
            _playerValidator = playerValidator;
            _players = _wizardsRepository.GetAll();
        }

        public void Add(Core.Model.Player player)
        {
            player.Id = GetUniqueId();
            _playerValidator.ValidateForCreate(player);
            
            _players.Add(player);
            
            _wizardsRepository.Update(_players);
        }

        public void Delete(int id)
        {
            var player = Get(id);
            _players.Remove(player);
            
            _wizardsRepository.Update(_players);
        }

        public void Update(int id, Core.Model.Player player)
        {
            _playerValidator.ValidateForUpdate(player);
            
            var playerToUpdate = Get(id);
            
            playerToUpdate.Email = player.Email;
            playerToUpdate.DateOfBirth = player.DateOfBirth;

            _wizardsRepository.Update(_players);
        }

        public void UpdatePassword(int id, Core.Model.Player player)
        {
            _playerValidator.ValidateForPasswordUpdate(player);

            var playerToUpdate = Get(id);

            playerToUpdate.Password = player.Password;

            _wizardsRepository.Update(_players);
        }

        public IEnumerable<Core.Model.Player> GetAll()
        {
            return _players.AsEnumerable();
        }

        public Core.Model.Player Get(int id)
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