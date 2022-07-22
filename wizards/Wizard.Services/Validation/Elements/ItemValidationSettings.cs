using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizards.Services.Validation.ValidationTasks.Interfaces;

namespace Wizards.Services.Validation.Elements
{
    public class ItemValidationSettings
    {
        public List<IStringValidationTask> NameTasks { get; set; }
        public List<INumberValidationTask> TypeTasks { get; set; }
        public List<INumberValidationTask> RestrictionsTasks { get; set; }
        public List<INumberValidationTask> TierTasks { get; set; }
        public List<INumberValidationTask> BuyPriceTasks { get; set; }
        public List<INumberValidationTask> SellPriceTasks { get; set; }
        
        
        public List<INumberValidationTask> DamageTasks { get; set; }
        public List<INumberValidationTask> PrecisionTasks { get; set; }
        public List<INumberValidationTask> SpecjalizationTasks { get; set; }
        public List<INumberValidationTask> MaxHealthTasks { get; set; }
        public List<INumberValidationTask> CurrentHealthTasks { get; set; }
        public List<INumberValidationTask> ReflexTasks { get; set; }
        public List<INumberValidationTask> DefenseTasks { get; set; }

        public IStringAlredyInUse AlredyInUseTask { get; set; }
    }
}
