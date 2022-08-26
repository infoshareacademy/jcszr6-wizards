using Wizards.Core.Model.WorldModels.Enums;
using Wizards.Core.Model.WorldModels.Properties;

namespace Wizards.Core.Model.WorldModels
{
    public class Enemy
    {
        // General
        public int Id { get; set; }
        public string Name { get; set; }
        public EnemyType EnemyType { get; set; }
        public string Description { get; set; }
        public int Tier { get; set; }
        public int AvatarImageEnemy { get; set; }
        public string EnemysStageName { get; set; }
        
        // Economy
        public int GoldReward { get; set; }
        
        
        // Combat and Behavior
        public EnemyAttributes EnemyAttributes { get; set; }
        public List<EnemySkill> Skills  { get; set; }
        public List<BehaviorPattern> BehaviorPatterns { get; set; }


        // Db relations properties
        public int AttributesId { get; set; }
    }
}
