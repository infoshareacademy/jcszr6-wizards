using System.Linq;
using AutoMapper;
using Wizards.Core.Model;
using Wizards.Core.Model.UserModels;
using WizardsWeb.ModelViews.PlayerModelViews;
using WizardsWeb.ModelViews;
using WizardsWeb.ModelViews.RankingModelViews;

namespace WizardsWeb.Mapping;

public class PlayerProfile : Profile
{
    public PlayerProfile()
    {
        CreateMap<PlayerCreateModelView, Player>();

        CreateMap<Player, PlayerEditModelView>()
            .ReverseMap();

        CreateMap<Player, PasswordChangeModelView>()
            .ForMember(dto => dto.CurrentPassword, expr => expr.Ignore())
            .ForMember(dto => dto.NewPassword, expr => expr.Ignore())
            .ForMember(dto => dto.ConfirmPassword, expr => expr.Ignore());

        CreateMap<Player, PlayerDeleteModelView>()
            .ForMember(dto => dto.HeroesCount,
                expr => expr.MapFrom(s => s.Heroes.Count))
            .ForMember(dto => dto.PasswordConfirm, 
                expr => expr.Ignore());
        
        CreateMap<Player, PlayerDetailsModelView>();

        CreateMap<Player, PlayerDetailsDto>()
            .ForMember(dto => dto.Email, expr => expr.MapFrom(x => x.Email))
            .ForMember(dto => dto.UserName, expr => expr.MapFrom(x => x.UserName))
            .ForMember(dto => dto.HeroNumber, expr => expr.MapFrom(x => x.Heroes.Count))
            .ForMember(dto => dto.RankNumber, expr => expr.MapFrom(x => x.Heroes.Sum(x => x.Statistics.RankPoints)))
            .ForMember(dto => dto.GoldHeroNumber, expr => expr.MapFrom(x => x.Heroes.Sum(x => x.Gold)));
    }
}