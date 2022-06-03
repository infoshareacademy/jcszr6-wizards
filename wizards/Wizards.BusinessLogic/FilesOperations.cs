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
            ////var list = Heros.GetContacts();
            //foreach (var c in list)
            //{
            //    File.AppendAllText("hero.csv", $"{c.Name},{c.Phone}\n");
            //}
            Console.WriteLine("Dodano na koniec");
            Console.WriteLine("Wciśnij dowolny przycisk, aby wrócić do poprzedniego okna.");
            Console.ReadKey();

        }
        public static void ReadCSVFile()
        {
            //var lines = File.ReadAllLines("hero.csv");
            //var list = new List<Hero>();
            //foreach (var line in lines)
            //{
            //    var values = line.Split(',');
            //    if (values.Length == 2)
            //    {
            //        var contact = new Hero() { Name = values[0], Phone = values[1] };
            //        list.Add(contact);
            //    }
            //}
            //Console.Clear();
            //Console.WriteLine("Lista bohaterów w Wizards:");
            //Console.WriteLine();
            //list.ForEach(x => Console.WriteLine($"{x.Name}\t{x.Phone}"));
            Console.WriteLine("Przeczytano plik");
            Console.WriteLine("Wciśnij dowolny przycisk, aby wrócić do poprzedniego okna.");
            Console.ReadKey();
        }
    }

}

