using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizards.Core.Model.CombatStage
{
    public class CombatStage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool InUse { get; set; }
        public Player Player { get; set; }
        public int PlayerId { get; set; }
        public Hero Hero { get; set; }
        public int HeroID { get; set; }
        public bool IsHeroStuned { get; set; }
        public int CurrentHeroHealth { get; set; }
        public Enemy Enemy { get; set; }
        public int EnemyId { get; set; }
        public bool IsEnemyStuned { get; set; }
        public int CurrentEnemyHealth { get; set; }
        public string RoundOneBack{ get; set; }
        public string RoundTwoBack { get; set; }
        public string RoundThreeBack { get; set; }
        public string RoundFourBack { get; set; }
        public string RoundFiveBack { get; set; }
    }
}
