using DustInTheWind.ConsoleTools.Controls.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wizards.BusinessLogic;
using Wizards.GUI.Creators;
using Wizards.GUI.Printers;
using Wizards.GUI.Selectors;


namespace Wizards.GUI
{
    internal class MenuClassItems
    {

        public static void ShowAuthors()
        {
            Console.Clear();
            Console.WriteLine("Zespół Wizards w składzie:\n");
            Console.WriteLine("Adrian Zamysłowski:");
            Console.WriteLine("Jakub Oczko:");
            Console.WriteLine("Paweł Grajnert,");
            Console.WriteLine("Paweł Dawicki\n");
            Console.WriteLine("Wciśnij dowolny przycisk, aby wrócić do poprzedniego okna.");
            Console.ReadKey();
            Console.Clear();
        }

    }

    internal class RefreshData : ICommand
    {
        bool ICommand.IsActive => true;

        void ICommand.Execute()
        {
            Console.Clear();
            Console.WriteLine("Uaktualnij dane");
            Console.ReadKey();
            ScrollMainMenu.DisplayScrollMenu();
        }
    }

    internal class AddElement : ICommand
    {
        bool ICommand.IsActive => true;

        void ICommand.Execute()
        {
            Console.Clear();
            Console.WriteLine("Dodaj element");

            Menu.ScrollSubMenuAdd.DisplayScrollSubMenuAdd();

            Console.ReadKey();
            ScrollMainMenu.DisplayScrollMenu();
        }
    }

    internal class EditElement : ICommand
    {
        bool ICommand.IsActive => true;

        void ICommand.Execute()
        {
            Console.Clear();
            Console.WriteLine("Edytuj element");

            Menu.ScrollSubMenuEdit.DisplayScrollSubMenuEdit();

            Console.ReadKey();
            ScrollMainMenu.DisplayScrollMenu();
        }
    }

    internal class Search : ICommand
    {
        bool ICommand.IsActive => true;

        void ICommand.Execute()
        {
            Console.Clear();
            Console.WriteLine("Wyszukiwanie");

            Menu.ScrollSubMenuSearch.DisplayScrollSubMenuSearch();

            Console.ReadKey();
            ScrollMainMenu.DisplayScrollMenu();
        }
    }



    public class Exit : ICommand
    {
        bool ICommand.IsActive => true;

        void ICommand.Execute()
        {
            Console.Clear();
            Console.WriteLine("A więc żegnaj.");
            Console.WriteLine();
            Console.Write("Zwalnianie zasobów systemowych: ");
            ProgressBar.DisplayProgressBar();

        }
    }

    internal class ShowAuthors : ICommand
    {
        bool ICommand.IsActive => true;

        void ICommand.Execute()
        {

            MenuClassItems.ShowAuthors();
            ScrollMainMenu.DisplayScrollMenu();
        }
    }

    internal class ToMainMenu : ICommand
    {
        bool ICommand.IsActive => true;

        void ICommand.Execute()
        {
            ScrollMainMenu.DisplayScrollMenu();
        }
    }

    internal class AddPlayerMenuClassItem : ICommand
    {
        bool ICommand.IsActive => true;

        void ICommand.Execute()
        {
            new PlayerCreator().Run();
            Menu.ScrollSubMenuAdd.DisplayScrollSubMenuAdd();
        }
    }

    internal class AddHeroMenuClassItem : ICommand
    {
        bool ICommand.IsActive => true;

        void ICommand.Execute()
        { 
            var playerSelector = new PlayerSelector();
            playerSelector.Select();

            char userKey;
            var screen = new Screen();
            var inputer = new UserInput(){Validator = new ValueValidator()};

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

            Menu.ScrollSubMenuAdd.DisplayScrollSubMenuAdd();
        }
    }

    internal class AddItemMenuCLassItem : ICommand
    {
        bool ICommand.IsActive => true;

        void ICommand.Execute()
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
            
            Menu.ScrollSubMenuAdd.DisplayScrollSubMenuAdd();
        }
    }

    internal class EditPlayerMenuClassItem : ICommand
    {
        bool ICommand.IsActive => true;

        void ICommand.Execute()
        {
            Console.Clear();
            Console.WriteLine("Edytuj gracza");
            Console.ReadKey();
            Menu.ScrollSubMenuEdit.DisplayScrollSubMenuEdit();
        }
    }

    internal class EditHeroMenuClassItem : ICommand
    {
        bool ICommand.IsActive => true;

        void ICommand.Execute()
        {
            Console.Clear();
            Console.WriteLine("Edytuj bohatera");
            Console.ReadKey();
            Menu.ScrollSubMenuEdit.DisplayScrollSubMenuEdit();
        }
    }

    internal class EditItemMenuCLassItem : ICommand
    {
        bool ICommand.IsActive => true;

        void ICommand.Execute()
        {
            Console.Clear();
            Console.WriteLine("Edytuj przedmiot");
            Console.ReadKey();
            Menu.ScrollSubMenuEdit.DisplayScrollSubMenuEdit();
        }
    }
    internal class SearchPlayerByNameMenuClassItem : ICommand
    {
        bool ICommand.IsActive => true;

        void ICommand.Execute()
        {
            Console.Clear();
            Console.WriteLine("Wyszukaj gracza po nazwie");
            Console.ReadKey();
            Menu.ScrollSubMenuSearch.DisplayScrollSubMenuSearch();
        }
    }
    internal class SearchPalyerByDateHeroMenuClassItem : ICommand
    {
        bool ICommand.IsActive => true;

        void ICommand.Execute()
        {
            Console.Clear();
            Console.WriteLine("Wyszukaj gracza po dacie");
            Console.ReadKey();
            Menu.ScrollSubMenuSearch.DisplayScrollSubMenuSearch();
        }
    }

    internal class SearchItemsByTypeItemMenuCLassItem : ICommand
    {
        bool ICommand.IsActive => true;

        void ICommand.Execute()
        {
            Console.Clear();
            Console.WriteLine("Wyszukiwanie przedmiot po jego rodzaju");
            Console.ReadKey();
            Menu.ScrollSubMenuSearch.DisplayScrollSubMenuSearch();
        }
    }

    internal class SearchPlayerItemsMenuCLassItem : ICommand
    {
        bool ICommand.IsActive => true;

        void ICommand.Execute()
        {
            Console.Clear();
            Console.WriteLine("Wyszukiwanie przedmiotow należących do gracza");
            Console.ReadKey();
            Menu.ScrollSubMenuSearch.DisplayScrollSubMenuSearch();
        }
    }
}

