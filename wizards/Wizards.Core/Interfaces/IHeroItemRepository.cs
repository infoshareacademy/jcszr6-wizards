﻿using Wizards.Core.Model;

namespace Wizards.Core.Interfaces;

public interface IHeroItemRepository
{
    Task<HeroItem?> GetAsync(int id);
    Task<List<HeroItem>> GetAllAsync();
    Task AddAsync(HeroItem heroItem);
    Task UpdateAsync(HeroItem heroItem);
    Task DeleteAsync(HeroItem heroItem);
}