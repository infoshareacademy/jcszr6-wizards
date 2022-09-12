using Wizards.Core.Model.UserModels;

namespace Wizards.Repository.InitialData.SeedFactories.Interfaces;

public interface IInitialDataSkillsFactory
{
    public List<Skill> GetSkills();
}