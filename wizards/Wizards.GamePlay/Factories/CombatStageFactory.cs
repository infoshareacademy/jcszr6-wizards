using AutoMapper;
using Wizards.Core.Interfaces.UserModelInterfaces;
using Wizards.Core.Interfaces.WorldModelInterfaces;
using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Enums;
using Wizards.Core.Model.WorldModels.ModelsDto;
using Wizards.Core.Model.WorldModels.Properties;

namespace Wizards.GamePlay.Factories;

public class CombatStageFactory : ICombatStageFactory
{
    private readonly IHeroRepository _heroRepository;
    private readonly IEnemyRepository _enemyRepository;
    private readonly IMapper _mapper;
   

    public CombatStageFactory(IHeroRepository heroRepository, IEnemyRepository enemyRepository, IMapper mapper)
    {
        _heroRepository = heroRepository;
        _enemyRepository = enemyRepository;
        _mapper = mapper;
    }

    public async Task<CombatStage> CreateCombatStageAsync(int heroId, int enemyId)
    {
        var combatStage = new CombatStage();

        var hero = await _heroRepository.Get(heroId);
        var enemy = await _enemyRepository.GetAsync(enemyId);

        if (hero == null || enemy == null)
        {
            throw new NullReferenceException("Invalid models of participants");
        }

        var combatEnemy = _mapper.Map<CombatEnemyDto>(enemy);
        var combatHero = _mapper.Map<CombatHeroDto>(hero);

        combatStage.CombatHero = combatHero;
        combatStage.CombatEnemy = combatEnemy;

        combatStage.IsTraining = enemy.TrainingEnemy;
        combatStage.Name = enemy.EnemyStageName;
        combatStage.BackgroundImageNumber = enemy.StageBackgroundImageNumber;
        combatStage.Status = StageStatus.FreshOpened;
        combatStage.RoundLogs = new List<RoundLog>();

        return combatStage;
    }
}