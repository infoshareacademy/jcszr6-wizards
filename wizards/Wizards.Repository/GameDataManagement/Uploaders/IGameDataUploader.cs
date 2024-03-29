﻿namespace Wizards.Repository.GameDataManagement.Uploaders;

public interface IGameDataUploader
{
    public Task AddOrUpdateSkillsFromFileAsync(bool forceUpdate = false);
    public Task AddOrUpdateItemsFromFileAsync(bool forceUpdate = false);
    public Task AddOrUpdateEnemiesFromFileAsync(bool forceUpdate = false);
    public Task UpdateHeroAttributes(bool fixOrBalanceUpdate, bool resetDailyRewards = true);
}