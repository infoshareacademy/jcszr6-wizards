﻿using Wizards.Core.Model;

namespace Wizards.Core.Interfaces;

public interface IPlayerRepository
{
    Task<List<Player>> GetAll();
    Task<Player> Get(int id);
    Task Add(Player player);
    Task Remove(Player player);
    Task Update(Player player);
    Task<List<string>> GetAllUserNames();
    Task<List<string>> GetAllEmails();


    Task<List<Player>> GetByUserName(string userName);
    Task<List<Player>> GetByEmailAddress(string addressEmail);
    Task<List<Player>> GetByYearRange(int startYear, int endYear);
    Task<List<Player>> GetByRankPointsRange(int lowRankPoints, int highRankPoints);
}