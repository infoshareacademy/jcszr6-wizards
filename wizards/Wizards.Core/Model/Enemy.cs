using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizards.Core.Model.Enums;
using Wizards.Core.Model.Properties;

namespace Wizards.Core.Model
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
        public int GoldReward { get; set; }
        public List<EnemySkill> Skills  { get; set; }
        public List<BehaviorPattern> BehaviorPatterns { get; set; }
    }
}
