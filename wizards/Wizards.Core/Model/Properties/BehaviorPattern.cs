using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizards.Core.Model.Properties
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
