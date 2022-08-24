using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizards.Core.Model.Properties
{
    public class EnemyAttributes
    {
        public Enemy Enemy { get; set; }

        public int Id { get; set; }
        // Offensive
        public int Damage { get; set; }
        public int Precision { get; set; }
        public int Specialization { get; set; }

        // Defensive
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int Reflex { get; set; }
        public int Defense { get; set; }
    }
}
