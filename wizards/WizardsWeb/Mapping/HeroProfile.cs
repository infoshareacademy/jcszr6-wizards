using AutoMapper;
using Wizards.Core.Model;
using WizardsWeb.ModelViews;
using WizardsWeb.ModelViews.Properties;

namespace WizardsWeb.Mapping;

public class HeroProfile : Profile
{
    public HeroProfile()
    {
        CreateMap<HeroAttributes, HeroAttributesModelView>();
        CreateMap<Statistics, StatisticsModelView>();
        
        CreateMap<HeroCreateModelView, Hero>();

        CreateMap<Hero, HeroDeleteModelView>();
        CreateMap<Hero, HeroDetailsModelView>();
        CreateMap<Hero, HeroBasicsModelView>();

        CreateMap<Hero, HeroEditModelView>().ReverseMap();
    }
}