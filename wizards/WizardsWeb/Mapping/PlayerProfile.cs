using System.Linq;
using AutoMapper;
using Wizards.Core.Model.UserModels;
using Wizards.Core.ModelExtensions;
using Wizards.Services.SearchService;
using WizardsWeb.ModelViews.PlayerModelViews;
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

        CreateMap<PlayerForRankingDto, PlayerDetailsDto>()
            .ForMember(dto => dto.RankingPosition, expr => expr.MapFrom(x => x.RankingNumber))
            .ForMember(dto => dto.Email, expr => expr.MapFrom(x => x.Player.Email))
            .ForMember(dto => dto.UserName, expr => expr.MapFrom(x => x.Player.UserName))
            .ForMember(dto => dto.HeroNumber, expr => expr.MapFrom(x => x.Player.Heroes.Count))
            .ForMember(dto => dto.RankNumber, expr => expr.MapFrom(x => x.Player.Heroes.Sum(x => x.Statistics.RankPoints)))
            .ForMember(dto => dto.GoldHeroNumber, expr => expr.MapFrom(x => x.Player.Heroes.Sum(x => x.Gold)))
            .ForMember(dto => dto.PlayerWinRatio, expr => expr.MapFrom(x => x.Player.Heroes.Average(x => x.GetWinRatio())))
            .ForMember(dto => dto.TotalMatchPlayed, expr => expr.MapFrom(x => x.Player.Heroes.Sum(x => x.Statistics.TotalMatchPlayed)))
            .ForMember(dto => dto.MaxTier, expr => expr.MapFrom(x => x.Player.Heroes.Max(x => x.GetAverageItemTier())))
            .ForMember(dto => dto.BestHero, expr => expr.MapFrom(p => p.Player.GetBestHeroNickName()))
            ;
    }
}