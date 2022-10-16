using Microsoft.EntityFrameworkCore;
using Wizards.Core.Interfaces.WorldModelInterfaces;
using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Properties;

namespace Wizards.Repository.Repository.WorldModel;
public class EnemySkillsRepository : IEnemySkillsRepository
{
    private readonly WizardsContext _wizardsContext;
    public EnemySkillsRepository(WizardsContext wizardsContext)
    {
        _wizardsContext = wizardsContext;
    }

    public async Task AddAsync(Enemy enemy, EnemySkill enemySkill)
    {
        await _wizardsContext.EnemiesSkills.AddAsync(enemySkill);
        await _wizardsContext.SaveChangesAsync();
    }

    public async Task<EnemySkill?> GetAsync(int id)
    {
        return await _wizardsContext.EnemiesSkills
        .SingleOrDefaultAsync(es => es.Id == id);
    }

    public async Task<List<EnemySkill>> GetAllAsync()
    {
        return await _wizardsContext.EnemiesSkills.ToListAsync();
    }

    public async Task RemoveAsync(EnemySkill enemySkill)
    {
        _wizardsContext.EnemiesSkills.Remove(enemySkill);
        await _wizardsContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(EnemySkill enemySkill)
    {
        _wizardsContext.EnemiesSkills.Update(enemySkill);
        await _wizardsContext.SaveChangesAsync();
    }
}