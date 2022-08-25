using Wizards.Core.Model;
using Wizards.Core.Model.UserModels;

namespace Wizards.Core.Interfaces;

public interface IHeroRepository
{
    Task<List<Hero>> GetAll();
    Task<Hero?> Get(int id);
    Task Add(Player player, Hero hero);
    Task Update(Hero hero);
    Task Remove(Hero hero);
    Task<List<string>> GetAllNickNames();
    Task<bool> Exist(int id, string nickName);
}