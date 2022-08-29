﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizards.Core.Model.UserModels;

namespace Wizards.Core.Interfaces
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