using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Wizards.BusinessLogic
{
    public class FilesOperations
    {
        public static string IsJson()
        {
            string dataDirectory;
            var directory = new DirectoryInfo(Environment.CurrentDirectory);
            var jsonFile = "data.json";

            while (!directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }
            dataDirectory = Path.Combine(directory.FullName, "Wizards.BusinessLogic", "Data");
            Console.WriteLine($"Data directory:\n{dataDirectory}\n");
            var path = Path.Combine($"{dataDirectory}", $"{jsonFile}");

            var isData = Directory.Exists(path);

            if (isData == false)
            {
                Console.WriteLine($"Data json on directory:\n{path}\ndon't exist.\n");
                Console.WriteLine("Create json");
                Console.WriteLine(File.Exists(path));
                //CreateJson();
                
            }
            else
            {
                Console.WriteLine($"Data json on path\n{path}\nexist.");
            }

            return path;

        }

        public static void RemoveJson()
        {
            string path = IsJson();
            Console.WriteLine("*************************");
            Console.WriteLine($"{path}");
            File.Delete(path);
        }

        public static void CreateJson(int playersCount = 15)
        {
            string path = IsJson();
            string json = JsonConvert.SerializeObject(JsonSetup.PlayersListGenerator(playersCount));
            Console.WriteLine("Json created.");
            File.WriteAllText(path, json.ToString());
        }


        public static void PrintJson()
        {
            Console.WriteLine("Przeczytano plik");
            Console.WriteLine("Wciśnij dowolny przycisk, aby wrócić do poprzedniego okna.");
            Console.ReadKey();
        }

    }
}

