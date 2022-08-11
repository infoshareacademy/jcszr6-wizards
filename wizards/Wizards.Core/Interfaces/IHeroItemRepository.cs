using Wizards.Core.Model;
using Wizards.Core.Model.ManyToManyTables;

namespace Wizards.Core.Interfaces;

public interface IHeroItemRepository
{
    Task<HeroItem> GetAsync(int id);
    Task<List<HeroItem>> GetAllAsync();
    Task AddItemToHeroAsync(Hero hero, HeroItem heroItem);
    Task AddAsync(HeroItem heroItem);
    Task Update(HeroItem heroItem);
    Task DeleteAsync(int id);
}