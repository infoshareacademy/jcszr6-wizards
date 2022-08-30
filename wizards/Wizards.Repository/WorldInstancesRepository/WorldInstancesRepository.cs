using Wizards.Core.Model.WorldModels;

namespace Wizards.Repository.WorldInstancesRepository;

public static class WorldInstancesRepository
{
    private static Dictionary<int, CombatStage> CombatStages { get; set; }

    static WorldInstancesRepository()
    {
        CombatStages = new Dictionary<int, CombatStage>();
    }

    public static CombatStage GetCombatStageInstance(int playerId)
    {
        if (!CombatStages.ContainsKey(playerId))
        {
            throw new Exception("There is No Combat Stage instance opened for this player!");
        }

        var stage = CombatStages.SingleOrDefault(cs => cs.Key == playerId).Value;

        if (stage == null)
        {
            throw new ArgumentNullException(nameof(stage), "Stage is Null!");
        }

        return stage;
    }

    public static void RemoveCombatStageInstance(int playerId)
    {
        if (!CombatStages.ContainsKey(playerId))
        {
            throw new Exception("There is No Combat Stage instance opened for this player!");
        }

        CombatStages.Remove(playerId);
    }

    public static void AddCombatStageInstance(int playerId, CombatStage combatStage)
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
    }
}