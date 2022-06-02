using System;
using Wizards.BusinessLogic;
using Wizards.GUI.Creators;
using Wizards.GUI.Printers;
using Wizards.GUI.Selectors;

namespace Wizards.GUI.AddElements
{
    public class AddElement
    {
        public void AddPlayer()
        {
            new PlayerCreator().Run();
        }

        public void AddHero()
        {
            var playerSelector = new PlayerSelector();
            playerSelector.Select();

            char userKey;
            var screen = new Screen();
            var inputer = new UserInput() { Validator = new ValueValidator() };

            screen.AddMessage(new Message($"Gracz: {playerSelector.ReturnPlayer().UserName}"));

            do
            {
                new HeroCreator(playerSelector.ReturnPlayer()).Run();

                new HeroPrinter(screen).PrintPlayersHeroes(playerSelector.ReturnPlayer());

                screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.WantToAddAnotherHero)));
                screen.Refresh();
                userKey = inputer.GetKey(new[] { 'y', 'n' });

                screen.RemoveLastMessages(3 + playerSelector.ReturnPlayer().Heroes.Count);

            } while (userKey == 'y');

            screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.PressKeyToExit), ConsoleColor.Cyan));
            screen.Refresh();
            inputer.WaitForKey();
        }

        public void AddItem()
        {
            var playerSelector = new PlayerSelector();
            playerSelector.Select();

            var heroSelector = new HeroSelector(playerSelector.ReturnPlayer());
            heroSelector.Select();


            char userKey;
            var screen = new Screen();
            var inputer = new UserInput() { Validator = new ValueValidator() };

            screen.AddMessage(new Message($"Bohater: {heroSelector.ReturnHero().NickName}"));
            do
            {
                new ItemCreator(heroSelector.ReturnHero()).Run();

                new ItemPrinter(screen).PrintAllHeroesItems(heroSelector.ReturnHero());

                screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.WantToAddAnotherItem)));
                screen.Refresh();
                userKey = inputer.GetKey(new[] { 'y', 'n' });

                screen.RemoveLastMessages(5 + heroSelector.ReturnHero().Inventory.Count + heroSelector.ReturnHero().Equipped.Count);

            } while (userKey == 'y');

            screen.AddMessage(new Message(TextRepository.Get(CreatorMsg.PressKeyToExit), ConsoleColor.Cyan));
            screen.Refresh();
            inputer.WaitForKey();
        }
    }
}