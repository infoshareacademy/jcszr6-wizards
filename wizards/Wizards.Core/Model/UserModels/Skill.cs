using Wizards.Core.Model.UserModels.Enums;

namespace Wizards.Core.Model.UserModels;

public class Skill
{
        // General
        public int Id { get; set; }
        public string Name { get; set; }
        public HeroSkillType Type { get; set; }
        public ProfessionRestriction ProfessionRestriction { get; set; }
        public string Description { get; set; }

        // Combat
        public double DamageFactor { get; set; }
        public int BaseHitChance { get; set; }
        public int ArmorPenetrationPercent { get; set; }
        public double HealingFactor { get; set; }
        
        // Db relations properties
        public List<HeroSkill> Hero { get; set; }
}