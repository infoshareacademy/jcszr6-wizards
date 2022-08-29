using System.ComponentModel.DataAnnotations.Schema;
using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.WorldModels.Enums;
using Wizards.Core.Model.WorldModels.Properties;

namespace Wizards.Core.Model.WorldModels
{
    public class CombatStage
    {
        // General
        public int Id { get; set; }
        public string StageName { get; set; }
        public StageStatus Status { get; set; }

        // Actual Hero status in Combat
        [NotMapped]
        public Hero Hero { get; set; }
        public int HeroId { get; set; }
        public bool IsHeroStunned { get; set; }
        public int CurrentHeroHealth { get; set; }
        [NotMapped]
        public Skill HeroSelectedSkill { get; set; }
        public int HeroSelectedSkillId { get; set; }

        // Actual Enemy status in combat
        [NotMapped]
        public Enemy Enemy { get; set; }
        public int EnemyId { get; set; }
        public bool IsEnemyStunned { get; set; }
        public int CurrentEnemyHealth { get; set; }
        [NotMapped] 
        public EnemySkill EnemySelectedSkill { get; set; }
        public int EnemySelectedSkillId { get; set; }
        public int EnemyBehaviorPatternId { get; set; }
        public int EnemyPatternStepId { get; set; }

        // Rounds information
        public List<RoundLog> RoundLogs { get; set; }

        // Db relations properties
        public Player Player { get; set; }
        public int PlayerId { get; set; }
    }
}
