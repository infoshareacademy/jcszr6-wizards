using Wizards.Core.Model.WorldModels.Enums;

namespace Wizards.Core.Model.WorldModels.Properties
{
    public class EnemySkill
    {
        public int Id { get; set; }
        public Enemy Enemy { get; set; }
        public int EnemyId { get; set; }
        public string SkillName { get; set; }
        public EnemySkillType SkillType { get; set; }

        public double DamageFactor { get; set; }
        public int BaseHitChange { get; set; }
        public int ArmorPenetrationPercent { get; set; }
        public double HealingFactor { get; set; }

        public bool Stunning { get; set; }
    }
}
