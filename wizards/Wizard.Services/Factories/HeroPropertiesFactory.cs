using Wizards.Core.Model.Enums;
using Wizards.Core.Model.Properties;

namespace Wizards.Services.Factories;

public class HeroPropertiesFactory : IHeroPropertiesFactory
{
    public Statistics GetStatistics()
    {
        return new Statistics()
        {
            RankPoints = 0,
            TotalMatchPlayed = 0,
            TotalMatchLoose = 0,
            TotalMatchWin = 0
        };
    }

    public HeroAttributes GetHeroAttributes(HeroProfession profession)
    {
        HeroAttributes result;

        switch (profession)
        {
            case HeroProfession.Sorcerer:
                result = CreateSorcerersAttributes();
                break;
            case HeroProfession.Necromancer:
                result = CreateNecromancersAttributes();
                break;
            default:
                result = CreateDefaultAttributes();
                break;
        }

        return result;
    }

    private HeroAttributes CreateSorcerersAttributes()
    {
        return new HeroAttributes()
        {
            DailyRewardEnergy = 10,
            Damage = 10,
            Precision = 5,
            Specialization = 0,
            MaxHealth = 25,
            CurrentHealth = 25,
            Reflex = 0,
            Defense = 0
        };
    }
    private HeroAttributes CreateNecromancersAttributes()
    {
        return new HeroAttributes()
        {
            DailyRewardEnergy = 10,
            Damage = 5,
            Precision = 0,
            Specialization = 10,
            MaxHealth = 25,
            CurrentHealth = 25,
            Reflex = 0,
            Defense = 0
        };
    }

    private HeroAttributes CreateDefaultAttributes()
    {
        return new HeroAttributes()
        {
            DailyRewardEnergy = 0,
            Damage = 0,
            Precision = 0,
            Specialization = 0,
            MaxHealth = 0,
            CurrentHealth = 0,
            Reflex = 0,
            Defense = 0
        };
    }
}