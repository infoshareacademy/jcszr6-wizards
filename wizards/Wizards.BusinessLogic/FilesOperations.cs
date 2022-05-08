using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizards.BusinessLogic
{
    public class FilesOperations
    {
        public static void AppendToCSV()
        {
            var list = Heros.GetContacts();
            foreach (var c in list)
            {
                File.AppendAllText("hero.csv", $"{c.Name},{c.Phone}\n");
            }
        }
        public static void ReadCSVFile()
        {
            var lines = File.ReadAllLines("hero.csv");
            var list = new List<Hero>();
            foreach (var line in lines)
            {
                var values = line.Split(',');
                if (values.Length == 2)
                {
                    var contact = new Hero() { Name = values[0], Phone = values[1] };
                    list.Add(contact);
                }
            }
            Console.Clear();
            Console.WriteLine("Lista bohaterów w Wizards:");
            Console.WriteLine();
            list.ForEach(x => Console.WriteLine($"{x.Name}\t{x.Phone}"));
            Console.WriteLine();
            Console.WriteLine("Wciśnij dowolny przycisk, aby wrócić do poprzedniego okna.");
            Console.ReadKey();
        }
    }
    public class Heros
    {
        public static List<Hero> GetContacts()
        {
            return new List<Hero>()
            {
                new Hero(){Name="Adrian Zamysłowski", Phone="333-444-555"},
                new Hero(){Name="Jakub Oczko", Phone="669-444-777"},
                new Hero(){Name="Paweł Grajnert", Phone="222-444-888"},
                new Hero(){Name="Paweł Dawicki", Phone="000-111-222"},
            };
        }
    }
    public class Hero
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}

