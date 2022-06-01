using System;
using Wizards.BusinessLogic;

namespace Wizards.GUI.Printers
{
    public class HeroPrinter
    {
        private Screen _screen;

        public HeroPrinter(Screen screen)
        {
            _screen = screen;
        }

        public void PrintPlayersHeroes(Player player)
        {
            var heroes = player.Heroes;

            _screen.AddMessage(new Message($"{TextRepository.Get(CreatorMsg.HeroesCount)}"));
            _screen.AddMessage(new Message($"{heroes.Count}", ConsoleColor.Green));

            for (int i = 0; i < heroes.Count; i++)
            {
                PrintHeroInfo(heroes[i], i + 1);
            }
            
            _screen.Refresh();
        }

        public void PrintHeroInfo(Hero hero, int index)
        {
            string heroText = String.Format("\n\t{0,-5} | {1,-20} | {2,-20} | {3,-30} |", $"{index}.", hero.NickName, $"Złoto: {hero.Gold}", $"Punkty rankingu: {hero.RankPoints}");
            _screen.AddMessage(new Message(heroText, ConsoleColor.Magenta));
        }
    }
}