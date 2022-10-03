using Wizards.Core.Interfaces;
using Wizards.Core.Interfaces.UserModelInterfaces;
using Wizards.Core.Model;
using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.UserModels.Enums;
using Wizards.Core.Model.UserModels.Properties;

namespace Wizards.Services.Factories;

public class HeroPropertiesFactory : IHeroPropertiesFactory
{
    private readonly IItemRepository _itemRepository;

    public HeroPropertiesFactory(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

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

    public List<HeroItem> GetStartupEquipment(HeroProfession profession)
    {
        List<HeroItem> result;

        switch (profession)
        {
            case HeroProfession.Sorcerer:
                result = GetSorcererStartupEquipment();
                break;
            case HeroProfession.Necromancer:
                result = GetNecromancerStartupEquipment();
                break;
            default:
                result = new List<HeroItem>();
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
            Reflex = 0,
            Defense = 0
        };
    }

    private List<HeroItem> GetSorcererStartupEquipment()
    {
        var sorcerersBasicItems = _itemRepository.GetAll(ProfessionRestriction.Sorcerer).Result.Where(hi => hi.Tier == 1);

        var EquippedStartupWeaponId = sorcerersBasicItems.SingleOrDefault(hi => hi.Name.ToLower().Contains("staff")).Id;
        var EquippedStartupArmorId = sorcerersBasicItems.SingleOrDefault(hi => hi.Name.ToLower().Contains("vestments")).Id;
        var AdditionalWeaponId = sorcerersBasicItems.SingleOrDefault(hi => hi.Name.ToLower().Contains("book")).Id;

        return new List<HeroItem>()
        {
            new(){ItemId = EquippedStartupWeaponId, InUse = true, ItemEndurance = 100d},
            new(){ItemId = EquippedStartupArmorId, InUse = true, ItemEndurance = 100d},
            new(){ItemId = AdditionalWeaponId, InUse = false, ItemEndurance = 100d},
        };
    }
    private List<HeroItem> GetNecromancerStartupEquipment()
    {
        var necromancersBasicItems = _itemRepository.GetAll(ProfessionRestriction.Necromancer).Result.Where(hi => hi.Tier == 1);

        var EquippedStartupWeaponId = necromancersBasicItems.SingleOrDefault(hi => hi.Name.ToLower().Contains("scythe")).Id;
        var EquippedStartupArmorId = necromancersBasicItems.SingleOrDefault(hi => hi.Name.ToLower().Contains("hood")).Id;
        var AdditionalWeaponId = necromancersBasicItems.SingleOrDefault(hi => hi.Name.ToLower().Contains("urn")).Id;

        return new List<HeroItem>()
        {
            new(){ItemId = EquippedStartupWeaponId, InUse = true, ItemEndurance = 100d},
            new(){ItemId = EquippedStartupArmorId, InUse = true, ItemEndurance = 100d},
            new(){ItemId = AdditionalWeaponId, InUse = false, ItemEndurance = 100d},
        };
    }
}