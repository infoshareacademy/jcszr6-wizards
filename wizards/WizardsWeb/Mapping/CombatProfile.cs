using AutoMapper;
using Wizards.Core.Model.WorldModels;
using Wizards.Core.Model.WorldModels.ModelsDto;
using Wizards.Core.Model.WorldModels.ModelsDto.Properties;
using WizardsWeb.ModelViews.CombatModelViews;

namespace WizardsWeb.Mapping;

public class CombatProfile :Profile
{

    public CombatProfile()
    {
        CreateMap<CombatHeroSkillDto, HeroSkillModelView>();

        CreateMap<CombatHeroDto, HeroSectionModelView>()
            .ForMember(destination => destination.Skills, 
                expr => expr.MapFrom(source => source.Skills));

        CreateMap<CombatEnemyDto, EnemySectionModelView>()
            .ForMember(destination => destination.SelectedSkillType, 
                expr => expr.MapFrom(source => source.SelectedSkill.Type))
            .ForMember(destination => destination.SelectedSkillStunning, 
                expr => expr.MapFrom(source => source.SelectedSkill.Stunning));

        CreateMap<CombatStage, CombatStageModelView>()
            .ForMember(destination => destination.HeroSelectedSkillId, 
                expr => expr.MapFrom(source => source.CombatHero.SelectedSkill.Id))
            .ForMember(destination => destination.RoundLogs,
                expr => expr.MapFrom(source => source.RoundLogs))
            .ForMember(destination => destination.LastRoundResult,
                expr => expr.MapFrom(source => source.LastRoundResult))
            .ForMember(destination => destination.WasResultShown,
                expr => expr.MapFrom(source => (source.LastRoundResult == null)));
    }
}