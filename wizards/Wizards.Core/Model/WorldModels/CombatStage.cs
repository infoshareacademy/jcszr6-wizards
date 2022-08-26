using Wizards.Core.Model.UserModels;

namespace Wizards.Core.Model.WorldModels
{
    public class CombatStage
    {
        public int Id { get; set; }
        public string StageName { get; set; }
        public bool InUse { get; set; }
        public Player Player { get; set; }
        public int PlayerId { get; set; }

        // Actual Hero status in Combat
        public Hero Hero { get; set; }
        public int HeroId { get; set; }
        public bool IsHeroStunned { get; set; }
        public int CurrentHeroHealth { get; set; }
        public int HeroSelectedSkillId { get; set; }

        // Actual Enemy status in combat
        public Enemy Enemy { get; set; }
        public int EnemyId { get; set; }
        public bool IsEnemyStunned { get; set; }
        public int CurrentEnemyHealth { get; set; }
        public int EnemySelectedSkillId { get; set; }


        // Rounds information
        public List<string> RoundLogs { get; set; }
    }
}
