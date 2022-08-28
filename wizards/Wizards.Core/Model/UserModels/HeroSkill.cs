namespace Wizards.Core.Model.UserModels;

public class HeroSkill
{
    // General
    public int Id { get; set; }

    // Db relations properties
    public Hero Hero { get; set; }
    public int HeroId { get; set; }
    
    public Skill Skill { get; set; }
    public int SkillId { get; set; }
}