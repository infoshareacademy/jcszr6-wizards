using AutoMapper;
using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.ModelsDto;
using Wizards.Core.Model.WorldModels.ModelsDto.Properties;
using WizardsWeb.ModelViews.CombatModelViews;

namespace WizardsWeb.Mapping;

public class CombatProfile : Profile
{

    public CombatProfile()
    {
        CreateMap<CombatHeroSkillDto, HeroSkillModelView>();

        CreateMap<CombatHeroDto, HeroSectionModelView>()
            .ForMember(destination => destination.Skills,
                expr => expr.MapFrom(source => source.Skills))
            .ForMember(destination => destination.MaxHealth, 
                expr => expr.MapFrom(source => source.Attributes.MaxHealth))
            .ForMember(destination => destination.DailyRewardEnergy, 
                expr => expr.MapFrom(source => source.Attributes.DailyRewardEnergy));

        CreateMap<CombatEnemyDto, EnemySectionModelView>()
            .ForMember(destination => destination.SelectedSkillType,
                expr => expr.MapFrom(source => source.SelectedSkill.Type))
            .ForMember(destination => destination.MaxHealth, 
                expr => expr.MapFrom(source => source.Attributes.MaxHealth));

        CreateMap<CombatStage, CombatStageModelView>()
            .ForMember(destination => destination.HeroSelectedSkillId,
                expr => expr.MapFrom(source => source.CombatHero.SelectedSkill.Id))
            .ForMember(destination => destination.RoundLogs,
                expr => expr.MapFrom(source => source.RoundLogs))
            .ForMember(destination => destination.LastRoundResult,
                expr => expr.MapFrom(source => source.LastRoundResult))
            .ForMember(destination => destination.WasResultShown,
                expr => expr.MapFrom(source => (source.LastRoundResult == null)))
            .ForMember(dto => dto.HeroSection,
                expr => expr.MapFrom(source => source.CombatHero))
            .ForMember(dto => dto.EnemySection,
                expr => expr.MapFrom(source => source.CombatEnemy));
    }

}