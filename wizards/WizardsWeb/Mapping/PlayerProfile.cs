using AutoMapper;
using Wizards.Core.Model;
using WizardsWeb.ModelViews;

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
    }
}