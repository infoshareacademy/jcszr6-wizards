using Wizards.Core.Model.WorldModels.Enums;
using Wizards.Core.Model.WorldModels.Properties;

namespace Wizards.Core.Model.WorldModels
{
    public class Enemy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AvatarImageEnemy { get; set; }
        public EnemyType EnemyType { get; set; }
        public int Tier { get; set; }
        
        public EnemyAttributes EnemyAttributes { get; set; }
        public object AttributesId { get; set; }
        
        public int GoldReward { get; set; }
        
        public List<EnemySkill> Skills  { get; set; }
        public List<BehaviorPattern> BehaviorPatterns { get; set; }
    }
}
