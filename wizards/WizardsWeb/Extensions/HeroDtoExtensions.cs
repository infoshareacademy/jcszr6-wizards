using System.Linq;
using Wizards.Core.Model.UserModels;


namespace WizardsWeb.Extensions
{
    public static class HeroDtoExtensions
    {
        public static double GetWinRatio(this Hero hero)
        {
            if (hero.Statistics.TotalMatchPlayed != 0)
            {
                return hero.Statistics.TotalMatchWin / (double)hero.Statistics.TotalMatchPlayed;
            }
            return 0;
        }

        public static string GetBestHeroNickName(this Player player)
        {
            if (player.Heroes != null && player.Heroes.Count != 0)
            {
                return player.Heroes.MaxBy(x => x.Statistics.RankPoints).NickName;
            }
            return "----";
        }

    }
}
