using Wizards.Core.Model;
using Wizards.Core.Model.Enums;
using Wizards.Core.Model.ManyToManyTables;
using Wizards.Repository.InitialData.SeedFactories.Interfaces;

namespace Wizards.Repository.InitialData.SeedFactories.Implementations;

public class InitialDataHeroesFactory : IInitialDataHeroesFactory
{
    public List<Hero> GetHeroes()
    {
        var result = new List<Hero>();

        result.Add(new Hero { PlayerId = 1, NickName = "Meroving", AvatarImageNumber = 2, Profession = HeroProfession.Sorcerer, Gold = 1,
            Attributes = new HeroAttributes() { DailyRewardEnergy = 10, Damage = 10, Precision = 5, Specialization = 0, MaxHealth = 0, CurrentHealth = 0, Defense = 0, Reflex = 0 },
            Statistics = new Statistics() { RankPoints = 259774, TotalMatchPlayed = 5500, TotalMatchLoose = 3750, TotalMatchWin = 5500 - 3750 } });

        return result;
    }

    public List<List<HeroItem>> GetInventories()
    {
        var result = new List<List<HeroItem>>();

        result.Add(new List<HeroItem>()
        {
            new HeroItem(){HeroId = 1, }
        });

        return result;
    }
}