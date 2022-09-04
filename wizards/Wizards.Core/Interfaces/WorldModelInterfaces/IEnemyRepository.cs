using Wizards.Core.Model.WorldModels;

namespace Wizards.Core.Interfaces.WorldModelInterfaces
{
    public interface IEnemyRepository
    {
        Task<List<Enemy>> GetAllAsync();
        Task<Enemy?> GetAsync(int id);
        Task AddAsync(Enemy enemy);
        Task UpdateAsync(Enemy enemy);
        Task RemoveAsync(Enemy enemy);
    }
}
