namespace Wizards.RankingAPI.Models.Dto
{
    public class RankingRecordDto
    {
        public int RankingPosition { get; set; }
        public string UserName { get; set; }
        public int HeroCount { get; set; }
        public int TotalRankPoints { get; set; }
        public int TotalGold { get; set; }
        public double PlayerWinRatio { get; set; }
        public double TotalMatchPlayed { get; set; }
        public double MaxItemTier { get; set; }
        public string BestHeroNickName { get; set; }
    }
}