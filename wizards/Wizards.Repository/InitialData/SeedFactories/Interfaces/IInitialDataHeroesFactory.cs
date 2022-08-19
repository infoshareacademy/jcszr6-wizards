﻿using Wizards.Core.Model;

namespace Wizards.Repository.InitialData.SeedFactories.Interfaces;

public interface IInitialDataHeroesFactory
{
    List<Hero> GetRandomTestHeroesWithEquipment();
    List<Hero> GetAdminModeratorsHeroesWithEquipment();
}