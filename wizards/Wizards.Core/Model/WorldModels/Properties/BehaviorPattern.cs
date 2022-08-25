namespace Wizards.Core.Model.WorldModels.Properties
{
    public class BehaviorPattern
    {
        public int Id { get; set; }

        public Enemy Enemy { get; set; }
        public int EnemyId{ get; set; }

        public List<int> EnemySkillId { get; set; }

        public int TriggerHealthIntervalMin { get; set; }
        public int TriggerHealthIntervalMax { get; set; }
    }
}
