using AutoMapper;
using Wizards.Core.Model;
using WizardsWeb.ModelViews;

namespace WizardsWeb.Mapping;

public class PlayerProfile : Profile
{
    public PlayerProfile()
    {
        CreateMap<PlayerCreateModelView, Player>()
            .ForMember(dto => dto.Password, 
                expr =>expr.MapFrom(s => s.Password));

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

        CreateMap<Player, PlayerDetailsModelView>();
    }
}