using System.Linq;
using AutoMapper;
using Wizards.Core.Model;
using WizardsWeb.ModelViews;
using WizardsWeb.ModelViews.RankingModelViews;


namespace WizardsWeb.Mapping;

public class PlayerProfile : Profile
{
    public PlayerProfile()
    {
        CreateMap<PlayerCreateModelView, Player>()
            .ForMember(dto => dto.Password,
                expr => expr.MapFrom(s => s.Password));

        CreateMap<Player, PlayerEditModelView>()
            .ReverseMap();

        CreateMap<PasswordChangeModelView, Player>()
            .ForMember(dto => dto.Password,
                expr => expr.MapFrom(s => s.NewPassword));

        CreateMap<Player, PasswordChangeModelView>()
            .ForMember(dto => dto.EnterOldPassword, expr => expr.Ignore())
            .ForMember(dto => dto.NewPassword, expr => expr.Ignore())
            .ForMember(dto => dto.ConfirmPassword, expr => expr.Ignore());

        CreateMap<Player, PlayerDeleteModelView>()
            .ForMember(dto => dto.HeroesCount,
                expr => expr.MapFrom(s => s.Heroes.Count))
            .ForMember(dto => dto.PasswordToConfirmDelete,
                expr => expr.Ignore());

        CreateMap<Player, PlayerDetailsDto>()
            .ForMember(dto => dto.Email, expr => expr.MapFrom(x => x.Email))
            .ForMember(dto => dto.UserName, expr => expr.MapFrom(x => x.UserName))
            .ForMember(dto => dto.HeroNumber, expr => expr.MapFrom(x => x.Heroes.Count))
            .ForMember(dto => dto.RankNumber, expr => expr.MapFrom(x => x.Heroes.Sum(x => x.Statistics.RankPoints)))
            .ForMember(dto => dto.GoldHeroNumber, expr => expr.MapFrom(x => x.Heroes.Sum(x => x.Gold)));

    }
}