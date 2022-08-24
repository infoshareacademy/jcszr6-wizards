using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizards.Core.Model.Enums;

namespace Wizards.Core.Model.Properties
{
    public class EnemySkill
    {
        public int Id { get; set; }
        public Enemy Enemy { get; set; }
        public int EnemyId { get; set; }
        public string SkillName { get; set; }
        public SkillType SkillType { get; set; }
        public double DamageFactor { get; set; }
        public int BaseHitChange { get; set; }
        public int ArmorPenetrationPercent { get; set; }
        public double HealingFactor { get; set; }
        public bool Stuning { get; set; }
    }
}
