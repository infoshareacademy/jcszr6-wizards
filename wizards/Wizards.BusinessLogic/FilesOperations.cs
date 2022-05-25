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
        public static void IsJson()
        {
            string dataDirectory;
            var directory = new DirectoryInfo(Environment.CurrentDirectory);
            var jsonFile = "data.json";

            while (!directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }
            dataDirectory = Path.Combine(directory.FullName, "Wizards.BusinessLogic", "Data");
            Console.WriteLine($"{dataDirectory}");
            var path = Path.Combine($"{dataDirectory}", $"{jsonFile}");

            var isData = Directory.Exists(path);

            if (isData == false)
            {
                Console.WriteLine($"Data json on directory {path} don't exist.");
                Console.WriteLine("Create json");
                JsonSetup.JsonCreate();
            }

            Console.WriteLine($"Data json on {path} exist.");

        }

        //public static void RemoveJson()
        //{
        //    Console.WriteLine("*************************");
        //    Console.WriteLine($"{}");
        //    File.Delete();
        //}


        public static void PrintJson()
        {
            Console.WriteLine("Przeczytano plik");
            Console.WriteLine("Wciśnij dowolny przycisk, aby wrócić do poprzedniego okna.");
            Console.ReadKey();
        }

    }
}

