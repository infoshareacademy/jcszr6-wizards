using Microsoft.EntityFrameworkCore;
using Wizards.Core.Interfaces.WorldModelInterfaces;
using Wizards.Core.Model.WorldModels;

namespace Wizards.Repository.Repository.WorldModel;
public class EnemyRepository : IEnemyRepository
{
    private readonly WizardsContext _wizardsContext;
    public EnemyRepository(WizardsContext wizardsContext)
    {
        _wizardsContext = wizardsContext;
    }

    public async Task AddAsync(Enemy enemy)
    {
        await _wizardsContext.Enemies.AddAsync(enemy);
        await _wizardsContext.SaveChangesAsync();
    }

    public async Task<Enemy?> GetAsync(int id)
    {
        return await _wizardsContext.Enemies
        .Include(e => e.Skills)
        .Include(e => e.Attributes)
        .Include(e => e.BehaviorPatterns)
        .SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task<List<Enemy>> GetAllAsync()
    {
        return await _wizardsContext.Enemies
            .Include(e => e.Attributes)
            .Include(e => e.Skills)
            .Include(e => e.BehaviorPatterns)
            .ToListAsync();
    }

    public async Task RemoveAsync(Enemy enemy)
    {
        _wizardsContext.Enemies.Remove(enemy);
        await _wizardsContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Enemy enemy)
    {
        _wizardsContext.Enemies.Update(enemy);
        await _wizardsContext.SaveChangesAsync();
    }
}