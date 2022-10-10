using AutoMapper;
using Wizards.Core.ModelExtensions;
using Wizards.RankingAPI.Models.Dto;
using Wizards.Services.SearchService;

namespace Wizards.RankingAPI.Mapping
{
    public class RankingProfile : Profile
    {
        public RankingProfile()
        {
            CreateMap<PlayerForRankingDto, RankingRecordDto>()
            .ForMember(dto => dto.RankingPosition, expr => expr.MapFrom(x => x.RankingNumber))
            .ForMember(dto => dto.UserName, expr => expr.MapFrom(x => x.Player.UserName))
            .ForMember(dto => dto.HeroCount, expr => expr.MapFrom(x => x.Player.Heroes.Count))
            .ForMember(dto => dto.TotalRankPoints, expr => expr.MapFrom(x => x.Player.Heroes.Sum(x => x.Statistics.RankPoints)))
            .ForMember(dto => dto.TotalGold, expr => expr.MapFrom(x => x.Player.Heroes.Sum(x => x.Gold)))
            .ForMember(dto => dto.PlayerWinRatio, expr => expr.MapFrom(x => x.Player.Heroes.Average(x => x.GetWinRatio())))
            .ForMember(dto => dto.TotalMatchPlayed, expr => expr.MapFrom(x => x.Player.Heroes.Sum(x => x.Statistics.TotalMatchPlayed)))
            .ForMember(dto => dto.MaxItemTier, expr => expr.MapFrom(x => x.Player.Heroes.Max(x => x.GetAverageItemTier())))
            .ForMember(dto => dto.BestHeroNickName, expr => expr.MapFrom(p => p.Player.GetBestHeroNickName()))
            ;
        }
    }
}