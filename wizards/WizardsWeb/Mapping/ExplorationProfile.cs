using AutoMapper;
using Wizards.Core.Model.WorldModels;
using WizardsWeb.ModelViews.ExplorationModelViews;

namespace WizardsWeb.Mapping;

public class ExplorationProfile : Profile
{
    public ExplorationProfile()
    {
        CreateMap<Enemy, EnemyIndexModelView>();
    }
}