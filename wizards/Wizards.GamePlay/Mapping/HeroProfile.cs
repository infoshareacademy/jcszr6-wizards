using AutoMapper;
using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.UserModels.Enums;
using Wizards.Core.Model.UserModels.Properties;
using Wizards.Core.Model.WorldModels.ModelsDto;
using Wizards.Core.Model.WorldModels.ModelsDto.Properties;
using Wizards.Core.ModelExtensions;

namespace Wizards.GamePlay.Mapping;

public class HeroProfile : Profile
{
    public HeroProfile()
    {
        CreateMap<HeroAttributes, CombatHeroAttributesDto>();

        CreateMap<Hero, CombatHeroDto>()
            .ForMember(dto => dto.CurrentHeroHealth, expr => expr.MapFrom(s => s.GetCalculatedAttributes().MaxHealth))
            .ForMember(dto => dto.IsHeroStunned, expr => expr.MapFrom(s => false))
            .ForMember(dto => dto.HeroSelectedSkill, expr => expr.Ignore())
            .ForMember(dto => dto.HeroSelectedSkillId, expr => expr.Ignore())
            .ForMember(dto => dto.ArmorUsage, expr => expr.MapFrom(s => 0d))
            .ForMember(dto => dto.WeaponUsage, expr => expr.MapFrom(s => 0d))
            .ForMember(dto => dto.EquippedArmorId,
                expr => expr.MapFrom(s =>
                    s.Inventory.SingleOrDefault(hi => hi.Item.Type == ItemType.Armor && hi.InUse).Id))
            .ForMember(dto => dto.EquippedWeaponId,
                expr => expr.MapFrom(s =>
                    s.Inventory.SingleOrDefault(hi => hi.Item.Type == ItemType.Weapon && hi.InUse).Id))
            .ForMember(dto => dto.HeroSkills, expr => expr.MapFrom(s => s.GetCombatHeroSkills()))
            .ForMember(dto => dto.Attributes, expr => expr.MapFrom(s => s.GetCalculatedAttributes()));
    }
}