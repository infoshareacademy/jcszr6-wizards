using AutoMapper;
using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.ModelsDto;
using Wizards.Core.Model.WorldModels.ModelsDto.Properties;
using Wizards.Core.Model.WorldModels.Properties;
using Wizards.Core.ModelExtensions;

namespace Wizards.GamePlay.Mapping;

public class EnemyProfile : Profile
{
    public EnemyProfile()
    {
        CreateMap<EnemyAttributes, CombatEnemyAttributesDto>();

        CreateMap<Enemy, CombatEnemyDto>()
            .ForMember(dto => dto.CurrentEnemyHealth, expr => expr.MapFrom(s => s.Attributes.MaxHealth))
            .ForMember(dto => dto.IsEnemyStunned, expr => expr.MapFrom(s => false))
            .ForMember(dto => dto.Attributes, expr => expr.MapFrom(s => s.Attributes))
            .ForMember(dto => dto.BehaviorPatterns, expr => expr.MapFrom(s => s.BehaviorPatterns))
            .ForMember(dto => dto.Skills, expr => expr.MapFrom(s => s.GetEnemyCombatSkills()))
            .ForMember(dto => dto.EnemySelectedSkill, expr => expr.Ignore())
            .ForMember(dto => dto.EnemySelectedSkillId, expr => expr.Ignore())
            .ForMember(dto => dto.EnemyPatternSequenceStepId, expr => expr.Ignore())
            .ForMember(dto => dto.EnemyBehaviorPatternId, expr => expr.Ignore());
    }
}