using Wizards.Core.Model.UserModels;

namespace Wizards.Core.Model.WorldModels
{
    public class CombatStage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool InUse { get; set; }
        public Player Player { get; set; }
        public int PlayerId { get; set; }


        public Hero Hero { get; set; }
        public int HeroId { get; set; }
        public bool IsHeroStunned { get; set; }
        public int CurrentHeroHealth { get; set; }
        public int HeroSelectedSkillId { get; set; }


        public Enemy Enemy { get; set; }
        public int EnemyId { get; set; }
        public bool IsEnemyStunned { get; set; }
        public int CurrentEnemyHealth { get; set; }
        public int EnemySelectedSkillId { get; set; }


        public List<string> RoundLogs { get; set; }
    }
}
