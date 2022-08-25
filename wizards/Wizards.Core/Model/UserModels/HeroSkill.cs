using Wizards.Core.Model.UserModels.Properties;

namespace Wizards.Core.Model.UserModels;

public class HeroSkill
{
    public int Id { get; set; }

    public int HeroId { get; set; }
    public Hero Hero { get; set; }

    public int SkillId { get; set; }
    public Skill Item { get; set; }
}