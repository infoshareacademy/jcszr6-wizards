using Wizards.Core.Model.UserModels;

namespace Wizards.Services.SearchService;
public class PlayerForRankingDto
{
    public int RankingNumber { get; set; }
    public Player Player { get; set; }
}