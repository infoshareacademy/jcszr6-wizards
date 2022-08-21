using Wizards.Core.Model;
using Wizards.Core.Model.Enums;
using Wizards.Core.Model.Properties;
using Wizards.Repository.InitialData.SeedFactories.Interfaces;

namespace Wizards.Repository.InitialData.SeedFactories.Implementations;

public class InitialDataUsersFactory : IInitialDataUsersFactory
{
    public Dictionary<Player, string> GetAdminUsers()
    {
        var result = new Dictionary<Player, string>();

        // TODO: This content should be loaded from JSON file:
        result.Add(new Player() { UserName = "Pawel-Dawicki", Email = "pawel.dawicki@wizard.com", DateOfBirth = new DateTime(1900,01,01) }, "Pa$$word2022");
        result.Add(new Player() { UserName = "Pawel-Grajnert", Email = "pawel.grajnert@wizard.com", DateOfBirth = new DateTime(1900,01,01) }, "Pa$$word2022");
        result.Add(new Player() { UserName = "Jakub-Oczko", Email = "jakub.oczko@wizard.com", DateOfBirth = new DateTime(1900,01,01) }, "Pa$$word2022");
        result.Add(new Player() { UserName = "Adrian-Zamyslowski", Email = "adrian.zamyslowski@wizard.com", DateOfBirth = new DateTime(1900, 01, 01) }, "Pa$$word2022");
        
        return result;
    }

    public Dictionary<Player, string> GetModeratorUsers()
    {
        var result = new Dictionary<Player, string>();

        // TODO: This content should be loaded from JSON file:
        result.Add(new Player() { UserName = "Moderator", Email = "moderator@wizard.com", DateOfBirth = new DateTime(1900, 01, 01) }, "Pa$$word2022");

        return result;
    }

    public Dictionary<Player, string> GetTesterUsers()
    {
        var result = new Dictionary<Player, string>();

        result.Add(new Player()
        {
            UserName = "Tester", Email = "tester@wizard.com", DateOfBirth = new DateTime(1999, 09, 27), Heroes = new List<Hero>()
            {
                new Hero(){NickName = "Diablo Pablo", Gold = 25000, AvatarImageNumber = 4, Profession = HeroProfession.Sorcerer, 
                    Attributes = new HeroAttributes(){DailyRewardEnergy = 10, Damage = 10, Precision = 5, Specialization = 0, CurrentHealth = 25, MaxHealth = 25, Reflex = 0, Defense = 0},
                    Statistics = new Statistics(){ RankPoints = 7200, TotalMatchPlayed = 943, TotalMatchWin = 672, TotalMatchLoose = 943-672},
                    Inventory = new List<HeroItem>()
                    {
                        new HeroItem(){ItemId = 5, InUse = true, ItemEndurance = 99.00d},
                        new HeroItem(){ItemId = 20, InUse = true, ItemEndurance = 98.99d},
                        new HeroItem(){ItemId = 10, InUse = false, ItemEndurance = 72.52d},
                        new HeroItem(){ItemId = 15, InUse = false, ItemEndurance = 37.00d},
                        new HeroItem(){ItemId = 25, InUse = false, ItemEndurance = 2.91d},
                        new HeroItem(){ItemId = 30, InUse = false, ItemEndurance = 4.99d},
                        new HeroItem(){ItemId = 4, InUse = false, ItemEndurance = 100.00d},
                        new HeroItem(){ItemId = 4, InUse = false, ItemEndurance = 99.00d},
                        new HeroItem(){ItemId = 4, InUse = false, ItemEndurance = 98.99d},
                        new HeroItem(){ItemId = 4, InUse = false, ItemEndurance = 66.00d},
                        new HeroItem(){ItemId = 4, InUse = false, ItemEndurance = 65.99d},
                        new HeroItem(){ItemId = 4, InUse = false, ItemEndurance = 33.00d},
                        new HeroItem(){ItemId = 4, InUse = false, ItemEndurance = 32.99d},
                        new HeroItem(){ItemId = 4, InUse = false, ItemEndurance = 0.01d},
                    }
                }
            }
        }, "Pa$$word2022");

        return result;
    }

    public Dictionary<Player, string> GetRandomUsersForTests()
    {
        var result = new Dictionary<Player, string>();

        // TODO: This content should be loaded from JSON file:
        result.Add(new Player() { UserName = "Meroving", Email = "meroving@wizards.com", DateOfBirth = new DateTime(1983, 2, 26) }, "Meroving_123");
        result.Add(new Player() { UserName = "Ectelion", Email = "ectelion@wizards.com", DateOfBirth = new DateTime(1997, 4, 10) }, "Ectelion_123");
        result.Add(new Player() { UserName = "Tirion", Email = "tirion@wizards.com", DateOfBirth = new DateTime(2006, 6, 27) }, "Tirion_123");
        result.Add(new Player() { UserName = "Maluszek", Email = "maluszek@wizards.com", DateOfBirth = new DateTime(1999, 10, 6) }, "Maluszek_123");
        result.Add(new Player() { UserName = "Krzychu11", Email = "krzychu11@wizards.com", DateOfBirth = new DateTime(2007, 4, 3) }, "Krzychu11_123");
        result.Add(new Player() { UserName = "Gandalf", Email = "gandalf@wizards.com", DateOfBirth = new DateTime(1981, 2, 15) }, "Gandalf_123");
        result.Add(new Player() { UserName = "Heros", Email = "heros@wizards.com", DateOfBirth = new DateTime(2002, 1, 2) }, "Heros_123");
        result.Add(new Player() { UserName = "MonsterTrack", Email = "monstertrack@wizards.com", DateOfBirth = new DateTime(2009, 10, 16) }, "MonsterTrack_123");
        result.Add(new Player() { UserName = "Diablo", Email = "diablo@wizards.com", DateOfBirth = new DateTime(1999, 3, 1) }, "Diablo_123");
        result.Add(new Player() { UserName = "Hektor", Email = "hektor@wizards.com", DateOfBirth = new DateTime(1999, 12, 20) }, "Hektor_123");
        result.Add(new Player() { UserName = "Demokles", Email = "demokles@wizards.com", DateOfBirth = new DateTime(2007, 3, 15) }, "Demokles_123");
        result.Add(new Player() { UserName = "Adam17", Email = "adam17@wizards.com", DateOfBirth = new DateTime(2007, 1, 1) }, "Adam17_123");
        result.Add(new Player() { UserName = "Komandos99", Email = "komandos99@wizards.com", DateOfBirth = new DateTime(1985, 7, 5) }, "Komandos99_123");
        result.Add(new Player() { UserName = "Kajtek", Email = "kajtek@wizards.com", DateOfBirth = new DateTime(2006, 9, 23) }, "Kajtek_123");
        result.Add(new Player() { UserName = "KingAtrur", Email = "kingatrur@wizards.com", DateOfBirth = new DateTime(2006, 2, 10) }, "KingAtrur_123");
        result.Add(new Player() { UserName = "Lamusek", Email = "lamusek@wizards.com", DateOfBirth = new DateTime(1993, 9, 11) }, "Lamusek_123");
        result.Add(new Player() { UserName = "Mordeczka11", Email = "mordeczka11@wizards.com", DateOfBirth = new DateTime(2009, 11, 28) }, "Mordeczka11_123");
        result.Add(new Player() { UserName = "Bartosz28", Email = "bartosz28@wizards.com", DateOfBirth = new DateTime(1982, 10, 5) }, "Bartosz28_123");
        result.Add(new Player() { UserName = "Seba", Email = "seba@wizards.com", DateOfBirth = new DateTime(1994, 10, 7) }, "Seba_123");
        result.Add(new Player() { UserName = "Kobra17", Email = "kobra17@wizards.com", DateOfBirth = new DateTime(1999, 12, 21) }, "Kobra17_123");
        result.Add(new Player() { UserName = "KapitanKlos", Email = "kapitanklos@wizards.com", DateOfBirth = new DateTime(1999, 7, 9) }, "KapitanKlos_123");
        result.Add(new Player() { UserName = "Frodo", Email = "frodo@wizards.com", DateOfBirth = new DateTime(1993, 11, 14) }, "Frodo_123");
        result.Add(new Player() { UserName = "Morfeusz", Email = "morfeusz@wizards.com", DateOfBirth = new DateTime(1983, 10, 14) }, "Morfeusz_123");
        result.Add(new Player() { UserName = "JuliuszCezar", Email = "juliuszcezar@wizards.com", DateOfBirth = new DateTime(1980, 4, 8) }, "JuliuszCezar_123");
        result.Add(new Player() { UserName = "Praktykant", Email = "praktykant@wizards.com", DateOfBirth = new DateTime(2009, 1, 25) }, "Praktykant_123");
        result.Add(new Player() { UserName = "MokraJolka99", Email = "mokrajolka99@wizards.com", DateOfBirth = new DateTime(2005, 3, 9) }, "MokraJolka99_123");
        result.Add(new Player() { UserName = "FanGothicka", Email = "fangothicka@wizards.com", DateOfBirth = new DateTime(1998, 6, 21) }, "FanGothicka_123");
        result.Add(new Player() { UserName = "Aurene", Email = "aurene@wizards.com", DateOfBirth = new DateTime(2009, 3, 22) }, "Aurene_123");
        result.Add(new Player() { UserName = "Master", Email = "master@wizards.com", DateOfBirth = new DateTime(1987, 1, 13) }, "Master_123");
        result.Add(new Player() { UserName = "Palacz22", Email = "palacz22@wizards.com", DateOfBirth = new DateTime(1987, 5, 15) }, "Palacz22_123");
        result.Add(new Player() { UserName = "Krzychu27", Email = "krzychu27@wizards.com", DateOfBirth = new DateTime(1990, 9, 28) }, "Krzychu27_123");
        result.Add(new Player() { UserName = "Zeus", Email = "zeus@wizards.com", DateOfBirth = new DateTime(1980, 12, 8) }, "Zeus_123");
        result.Add(new Player() { UserName = "Katapulta", Email = "katapulta@wizards.com", DateOfBirth = new DateTime(2003, 3, 26) }, "Katapulta_123");
        result.Add(new Player() { UserName = "Vergiliusz", Email = "vergiliusz@wizards.com", DateOfBirth = new DateTime(1999, 12, 13) }, "Vergiliusz_123");
        result.Add(new Player() { UserName = "Mozart21", Email = "mozart21@wizards.com", DateOfBirth = new DateTime(1983, 1, 11) }, "Mozart21_123");
        result.Add(new Player() { UserName = "Kozak12", Email = "kozak12@wizards.com", DateOfBirth = new DateTime(1995, 10, 1) }, "Kozak12_123");
        result.Add(new Player() { UserName = "LubiePlacki", Email = "lubieplacki@wizards.com", DateOfBirth = new DateTime(1994, 3, 26) }, "LubiePlacki_123");
        result.Add(new Player() { UserName = "Barbara", Email = "barbara@wizards.com", DateOfBirth = new DateTime(1998, 10, 10) }, "Barbara_123");
        result.Add(new Player() { UserName = "ArianaGrande", Email = "arianagrande@wizards.com", DateOfBirth = new DateTime(2001, 5, 2) }, "ArianaGrande_123");
        result.Add(new Player() { UserName = "Polemik", Email = "polemik@wizards.com", DateOfBirth = new DateTime(1981, 9, 25) }, "Polemik_123");
        result.Add(new Player() { UserName = "Gruby", Email = "gruby@wizards.com", DateOfBirth = new DateTime(2003, 9, 26) }, "Gruby_123");
        result.Add(new Player() { UserName = "Komornik", Email = "komornik@wizards.com", DateOfBirth = new DateTime(2005, 11, 24) }, "Komornik_123");
        result.Add(new Player() { UserName = "YakushiMamushi", Email = "yakushimamushi@wizards.com", DateOfBirth = new DateTime(1996, 7, 19) }, "YakushiMamushi_123");
        result.Add(new Player() { UserName = "Laleczka", Email = "laleczka@wizards.com", DateOfBirth = new DateTime(1995, 12, 11) }, "Laleczka_123");
        result.Add(new Player() { UserName = "Calineczka", Email = "calineczka@wizards.com", DateOfBirth = new DateTime(2005, 7, 28) }, "Calineczka_123");
        result.Add(new Player() { UserName = "Puchatek-Bear", Email = "puchatek-bear@wizards.com", DateOfBirth = new DateTime(1995, 3, 24) }, "Puchatek-Bear_123");
        result.Add(new Player() { UserName = "London-Magazynier", Email = "london-magazynier@wizards.com", DateOfBirth = new DateTime(1984, 5, 16) }, "London-Magazynier_123");
        result.Add(new Player() { UserName = "Kopacz", Email = "kopacz@wizards.com", DateOfBirth = new DateTime(1986, 7, 11) }, "Kopacz_123");
        result.Add(new Player() { UserName = "BialyKogut", Email = "bialykogut@wizards.com", DateOfBirth = new DateTime(1995, 3, 22) }, "BialyKogut_123");
        result.Add(new Player() { UserName = "Grabarz", Email = "grabarz@wizards.com", DateOfBirth = new DateTime(1999, 2, 23) }, "Grabarz_123");
        result.Add(new Player() { UserName = "Anastazja", Email = "anastazja@wizards.com", DateOfBirth = new DateTime(1991, 5, 27) }, "Anastazja_123");
        result.Add(new Player() { UserName = "Mareczek", Email = "mareczek@wizards.com", DateOfBirth = new DateTime(1985, 8, 18) }, "Mareczek_123");
        result.Add(new Player() { UserName = "Wariacik", Email = "wariacik@wizards.com", DateOfBirth = new DateTime(2009, 9, 25) }, "Wariacik_123");
        result.Add(new Player() { UserName = "Kobra", Email = "kobra@wizards.com", DateOfBirth = new DateTime(1994, 12, 10) }, "Kobra_123");
        result.Add(new Player() { UserName = "Waldek", Email = "waldek@wizards.com", DateOfBirth = new DateTime(1987, 9, 14) }, "Waldek_123");
        result.Add(new Player() { UserName = "Kubeusz", Email = "kubeusz@wizards.com", DateOfBirth = new DateTime(1993, 11, 11) }, "Kubeusz_123");
        result.Add(new Player() { UserName = "Koxiarz", Email = "koxiarz@wizards.com", DateOfBirth = new DateTime(2001, 8, 17) }, "Koxiarz_123");
        result.Add(new Player() { UserName = "Quarior", Email = "quarior@wizards.com", DateOfBirth = new DateTime(1998, 9, 21) }, "Quarior_123");
        result.Add(new Player() { UserName = "ElrondZRivendell", Email = "elrondzrivendell@wizards.com", DateOfBirth = new DateTime(1993, 11, 4) }, "ElrondZRivendell_123");
        result.Add(new Player() { UserName = "Maciek", Email = "maciek@wizards.com", DateOfBirth = new DateTime(1981, 5, 10) }, "Maciek_123");
        result.Add(new Player() { UserName = "Aragorn", Email = "aragorn@wizards.com", DateOfBirth = new DateTime(1995, 11, 16) }, "Aragorn_123");
        result.Add(new Player() { UserName = "SarumanMondry", Email = "sarumanmondry@wizards.com", DateOfBirth = new DateTime(1984, 10, 22) }, "SarumanMondry_123");
        result.Add(new Player() { UserName = "Luzak22", Email = "luzak22@wizards.com", DateOfBirth = new DateTime(1987, 5, 16) }, "Luzak22_123");
        result.Add(new Player() { UserName = "TaniaBenzyna", Email = "taniabenzyna@wizards.com", DateOfBirth = new DateTime(1988, 5, 3) }, "TaniaBenzyna_123");
        result.Add(new Player() { UserName = "SkrzypekNaDachu", Email = "skrzypeknadachu@wizards.com", DateOfBirth = new DateTime(2001, 1, 23) }, "SkrzypekNaDachu_123");
        result.Add(new Player() { UserName = "Szparka29", Email = "szparka29@wizards.com", DateOfBirth = new DateTime(1985, 11, 3) }, "Szparka29_123");
        result.Add(new Player() { UserName = "Lemur", Email = "lemur@wizards.com", DateOfBirth = new DateTime(2001, 5, 8) }, "Lemur_123");
        result.Add(new Player() { UserName = "KingJulian", Email = "kingjulian@wizards.com", DateOfBirth = new DateTime(2002, 3, 9) }, "KingJulian_123");
        result.Add(new Player() { UserName = "Merlin", Email = "merlin@wizards.com", DateOfBirth = new DateTime(2001, 4, 13) }, "Merlin_123");
        result.Add(new Player() { UserName = "Merlin19", Email = "merlin19@wizards.com", DateOfBirth = new DateTime(2002, 10, 12) }, "Merlin19_123");
        result.Add(new Player() { UserName = "PapaLeonVI", Email = "papaleonvi@wizards.com", DateOfBirth = new DateTime(1998, 4, 12) }, "PapaLeonVI_123");
        result.Add(new Player() { UserName = "Dastan", Email = "dastan@wizards.com", DateOfBirth = new DateTime(2007, 1, 24) }, "Dastan_123");
        result.Add(new Player() { UserName = "Wolontariusz", Email = "wolontariusz@wizards.com", DateOfBirth = new DateTime(2004, 4, 1) }, "Wolontariusz_123");
        result.Add(new Player() { UserName = "Kabanosek77", Email = "kabanosek77@wizards.com", DateOfBirth = new DateTime(1984, 9, 22) }, "Kabanosek77_123");
        result.Add(new Player() { UserName = "KauasznikXD", Email = "kauasznikxd@wizards.com", DateOfBirth = new DateTime(2005, 8, 3) }, "KauasznikXD_123");
        result.Add(new Player() { UserName = "Mistrzunio", Email = "mistrzunio@wizards.com", DateOfBirth = new DateTime(1999, 11, 19) }, "Mistrzunio_123");
        result.Add(new Player() { UserName = "WielkiDrag19", Email = "wielkidrag19@wizards.com", DateOfBirth = new DateTime(2007, 1, 10) }, "WielkiDrag19_123");
        result.Add(new Player() { UserName = "Gargamel", Email = "gargamel@wizards.com", DateOfBirth = new DateTime(1992, 1, 24) }, "Gargamel_123");
        result.Add(new Player() { UserName = "UrukHai", Email = "urukhai@wizards.com", DateOfBirth = new DateTime(1993, 12, 4) }, "UrukHai_123");
        result.Add(new Player() { UserName = "Artemida", Email = "artemida@wizards.com", DateOfBirth = new DateTime(1980, 9, 3) }, "Artemida_123");
        result.Add(new Player() { UserName = "Atena", Email = "atena@wizards.com", DateOfBirth = new DateTime(1990, 6, 7) }, "Atena_123");
        result.Add(new Player() { UserName = "Galadriela", Email = "galadriela@wizards.com", DateOfBirth = new DateTime(1993, 11, 12) }, "Galadriela_123");
        result.Add(new Player() { UserName = "Orfeusz", Email = "orfeusz@wizards.com", DateOfBirth = new DateTime(2000, 2, 28) }, "Orfeusz_123");
        result.Add(new Player() { UserName = "Persefona", Email = "persefona@wizards.com", DateOfBirth = new DateTime(1983, 1, 18) }, "Persefona_123");
        result.Add(new Player() { UserName = "Kijanka", Email = "kijanka@wizards.com", DateOfBirth = new DateTime(2008, 6, 10) }, "Kijanka_123");
        result.Add(new Player() { UserName = "Kruk", Email = "kruk@wizards.com", DateOfBirth = new DateTime(2000, 5, 18) }, "Kruk_123");
        result.Add(new Player() { UserName = "Witkacy", Email = "witkacy@wizards.com", DateOfBirth = new DateTime(1983, 12, 18) }, "Witkacy_123");
        result.Add(new Player() { UserName = "Wokulski", Email = "wokulski@wizards.com", DateOfBirth = new DateTime(1990, 3, 23) }, "Wokulski_123");
        result.Add(new Player() { UserName = "Maro", Email = "maro@wizards.com", DateOfBirth = new DateTime(2005, 8, 8) }, "Maro_123");
        result.Add(new Player() { UserName = "Jan-Pawel-II", Email = "jan-pawel-ii@wizards.com", DateOfBirth = new DateTime(1991, 8, 8) }, "Jan-Pawel-II_123");
        result.Add(new Player() { UserName = "Szymonek", Email = "szymonek@wizards.com", DateOfBirth = new DateTime(2001, 4, 27) }, "Szymonek_123");
        result.Add(new Player() { UserName = "Cyklop", Email = "cyklop@wizards.com", DateOfBirth = new DateTime(1997, 1, 27) }, "Cyklop_123");
        result.Add(new Player() { UserName = "Krystian", Email = "krystian@wizards.com", DateOfBirth = new DateTime(2002, 3, 1) }, "Krystian_123");
        result.Add(new Player() { UserName = "FryderykChopin", Email = "fryderykchopin@wizards.com", DateOfBirth = new DateTime(2002, 3, 25) }, "FryderykChopin_123");
        result.Add(new Player() { UserName = "JadeUrsusem", Email = "jadeursusem@wizards.com", DateOfBirth = new DateTime(2002, 7, 23) }, "JadeUrsusem_123");
        result.Add(new Player() { UserName = "Niobe", Email = "niobe@wizards.com", DateOfBirth = new DateTime(1998, 9, 23) }, "Niobe_123");
        result.Add(new Player() { UserName = "Gagarin", Email = "gagarin@wizards.com", DateOfBirth = new DateTime(1990, 10, 9) }, "Gagarin_123");
        result.Add(new Player() { UserName = "Kurczaaaak", Email = "kurczaaaak@wizards.com", DateOfBirth = new DateTime(2000, 8, 10) }, "Kurczaaaak_123");
        result.Add(new Player() { UserName = "Wojownik", Email = "wojownik@wizards.com", DateOfBirth = new DateTime(1998, 1, 10) }, "Wojownik_123");
        result.Add(new Player() { UserName = "JohnyWalker", Email = "johnywalker@wizards.com", DateOfBirth = new DateTime(2006, 5, 25) }, "JohnyWalker_123");

        return result;
    }
}