using Wizards.Core.Model.UserModels.Enums;

namespace Wizards.Core.Model.UserModels;

public class Skill
{
        public int Id { get; set; }
        
        public List<HeroSkill> Hero { get; set; }
        public int HeroId { get; set; }
        
        public string SkillName { get; set; }
        public HeroSkillType SkillType { get; set; }
        public ProfessionRestriction ProfessionRestriction { get; set; }
        
        public double DamageFactor { get; set; }
        public int BaseHitChange { get; set; }
        public int ArmorPenetrationPercent { get; set; }
        public double HealingFactor { get; set; }
}