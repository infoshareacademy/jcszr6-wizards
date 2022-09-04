using Wizards.Core.Model.UserModels.Enums;

namespace Wizards.Core.Model.UserModels;

public class HeroSkill
{
    // General
    public int Id { get; set; }

    // Usage
    public bool InUse { get; set; }
    public SkillSlotNumber SlotNumber { get; set; }

    // Db relations properties
    public Hero Hero { get; set; }
    public int HeroId { get; set; }
    
    public Skill Skill { get; set; }
    public int SkillId { get; set; }
}