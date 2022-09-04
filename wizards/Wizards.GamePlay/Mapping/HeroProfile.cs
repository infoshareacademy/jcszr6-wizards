using AutoMapper;
using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.UserModels.Properties;
using Wizards.Core.Model.WorldModels.ModelsDto;
using Wizards.Core.Model.WorldModels.ModelsDto.Properties;

namespace Wizards.GamePlay.Mapping;

public class HeroProfile : Profile
{
    public HeroProfile()
    {
        CreateMap<HeroAttributes, CombatHeroAttributesDto>();

        CreateMap<HeroSkill, CombatHeroSkillDto>();

        CreateMap<Hero, CombatHeroDto>();
    }
}