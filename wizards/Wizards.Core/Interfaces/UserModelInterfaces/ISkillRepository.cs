using Wizards.Core.Model.UserModels;

namespace Wizards.Core.Interfaces.UserModelInterfaces
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetAllAsync();
        Task<Skill?> GetAsync(int id);
        Task AddAsync(Skill skill);
        Task UpdateAsync(Skill skill);
        Task RemoveAsync(Skill skill);
    }
}
