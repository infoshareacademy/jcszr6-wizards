using AutoMapper;
using Wizards.Core.Model;
using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.UserModels.Properties;
using Wizards.Services.Helpers;
using WizardsWeb.ModelViews.HeroModelViews;
using WizardsWeb.ModelViews.HeroModelViews.Properties;

namespace WizardsWeb.Mapping;

public class HeroProfile : Profile
{
    public HeroProfile()
    {
        CreateMap<HeroAttributes, HeroAttributesModelView>();
        CreateMap<Statistics, StatisticsModelView>();
        CreateMap<Hero, HeroBasicsModelView>();
        CreateMap<Hero, HeroSummaryModelView>()
            .ForMember(dto => dto.Gold,
                exp=>exp.MapFrom(s=>s.Gold))
            .ForMember(dto => dto.HerosAvargeItemTier,
                exp=>exp.MapFrom(s=>s.GetAvargeItemTier()));

        CreateMap<HeroCreateModelView, Hero>();
        
        CreateMap<Hero, HeroDetailsModelView>()
            .ForMember(dto => dto.Attributes, 
                exp => exp.MapFrom(s => s.GetCalculatedAttributes()))
            .ForMember(dto => dto.Basics, 
                exp => exp.MapFrom(s => s))
            .ForMember(dto => dto.Summary, 
                exp => exp.MapFrom(s => s));

        CreateMap<Hero, HeroDeleteModelView>()
            .ForMember(dto => dto.Basics,
                exp => exp.MapFrom(s => s))
            .ForMember(dto => dto.Summary,
                exp => exp.MapFrom(s => s));
        
        CreateMap<Hero, HeroEditModelView>().ReverseMap();
    }
}