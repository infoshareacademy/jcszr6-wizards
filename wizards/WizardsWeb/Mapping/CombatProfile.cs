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
            .ForMember(destination => destination.HeroSkills, 
                expr => expr.MapFrom(source => source.HeroSkills));

        CreateMap<CombatEnemyDto, EnemySectionModelView>()
            .ForMember(destination => destination.EnemySelectedSkillType, 
                expr => expr.MapFrom(source => source.EnemySelectedSkill.Type))
            .ForMember(destination => destination.EnemySelectedSkillStunning, 
                expr => expr.MapFrom(source => source.EnemySelectedSkill.Stunning));

        CreateMap<CombatStage, CombatStageModelView>()
            .ForMember(destination => destination.HeroSelectedSkillId, 
                expr => expr.MapFrom(source => source.CombatHero.HeroSelectedSkill.Id))
            .ForMember(destination => destination.RoundLogs,
                expr => expr.MapFrom(source => source.RoundLogs))
            .ForMember(destination => destination.LastRoundResult,
                expr => expr.MapFrom(source => source.LastRoundResult))
            .ForMember(destination => destination.WasResultShown,
                expr => expr.MapFrom(source => (source.LastRoundResult == null)));
            ;

    }

}