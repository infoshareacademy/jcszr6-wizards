using System.ComponentModel.DataAnnotations.Schema;
using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.WorldModels.Enums;
using Wizards.Core.Model.WorldModels.ModelsDto;
using Wizards.Core.Model.WorldModels.Properties;

namespace Wizards.Core.Model.WorldModels
{
    public class CombatStage
    {
        // General
        public string StageName { get; set; }
        public StageStatus Status { get; set; }
        public bool IsTraining { get; set; }

        // Actual Hero status in Combat
        public CombatHeroDto CombatHero { get; set; }

        //TODO: Delete props after mapping
        public Hero Hero { get; set; }
        public bool IsHeroStunned { get; set; }
        public int CurrentHeroHealth { get; set; }
        public Skill HeroSelectedSkill { get; set; }
        public int HeroSelectedSkillId { get; set; }

        // Actual Enemy status in combat
        public CombatEnemyDto CombatEnemy { get; set; }
        
        //TODO: Delete props after mapping
        public Enemy Enemy { get; set; }
        public bool IsEnemyStunned { get; set; }
        public int CurrentEnemyHealth { get; set; }

        public EnemySkill EnemySelectedSkill { get; set; }
        public int EnemySelectedSkillId { get; set; }
        public int EnemyBehaviorPatternId { get; set; }
        public int EnemyPatternSequenceStepId { get; set; }

        // Rounds information
        public RoundResult LastResult { get; set; }
        public List<RoundLog> RoundLogs { get; set; }
    }
}
