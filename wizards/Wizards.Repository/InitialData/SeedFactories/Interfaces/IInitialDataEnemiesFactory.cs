using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Properties;

namespace Wizards.Repository.InitialData.SeedFactories.Interfaces;

public interface IInitialDataEnemiesFactory
{
    public List<EnemyAttributes> GetEnemiesAttributes();
    public List<EnemySkill> GetEnemiesSkills();
    public List<BehaviorPattern> GetEnemiesBehaviorPatterns();
    public List<Enemy> GetEnemies();
}