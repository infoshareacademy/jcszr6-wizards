using Wizards.Core.Model.UserModels;

namespace Wizards.Core.Interfaces.UserModelInterfaces
{
    public interface IHeroSkillsRepository
    {
        Task<List<HeroSkill>> GetAllAsync();
        Task<HeroSkill?> GetAsync(int id);
        Task AddAsync(HeroSkill heroSkill);
        Task UpdateAsync(HeroSkill heroSkill);
        Task RemoveAsync(HeroSkill heroSkill);
    }
}
