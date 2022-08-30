using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.Enums;

namespace Wizards.Repository.WorldInstancesRepository;

public static class CombatStageInstancesRepository
{
    private static Dictionary<int, CombatStage> CombatStages { get; set; }

    static CombatStageInstancesRepository()
    {
        CombatStages = new Dictionary<int, CombatStage>();
    }

    public static Task<CombatStage> Get(int playerId)
    {
        if (!CombatStages.ContainsKey(playerId))
        {
            throw new Exception("There is No Combat Stage instance opened for this player!");
        }

        var stage = CombatStages.SingleOrDefault(cs => cs.Key == playerId).Value;

        return Task.FromResult(stage);
    }

    public static Task Add(int playerId, CombatStage combatStage)
    {
        if (CombatStages.ContainsKey(playerId))
        {
            throw new Exception("Player already has registered Combat Stage instance!");
        }

        if (combatStage == null)
        {
            throw new ArgumentNullException(nameof(combatStage), "Stage cannot be null!");
        }

        CombatStages.Add(playerId, combatStage);

        return Task.CompletedTask;
    }

    public static Task Remove(int playerId)
    {
        if (!CombatStages.ContainsKey(playerId))
        {
            throw new Exception("There is No Combat Stage instance opened for this player!");
        }

        if (CombatStages[playerId].Status == StageStatus.ReadyToClose)
        {
            throw new Exception($"Cannot remove CombatStage with status: {CombatStages[playerId].Status}");
        }
        
        CombatStages.Remove(playerId);

        return Task.CompletedTask;
    }
}