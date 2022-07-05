using Newtonsoft.Json;
using Wizards.Core.Model;

namespace Wizards.Repository.FileOperations
{
    public class WizardsRepository : IWizardsRepository
    {
        public void Update(List<Player> players)
        {
            var path = GetJsonDirectory();
            
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Directory.CreateDirectory(path);
            }

            var json = JsonConvert.SerializeObject(players);

            using (var writer = File.CreateText(path))
            {
                writer.Write(json);
            }
        }

        public List<Player> GetAll()
        {
            var path = GetJsonDirectory();
            
            if (File.Exists(path))
            {
                string dataFile;
                
                using (var reader = File.OpenText(path))
                {
                    dataFile = reader.ReadToEnd();
                }
                
                return JsonConvert.DeserializeObject<List<Player>>(dataFile);
            }

            return new List<Player>();
        }

        private static string GetJsonDirectory()
        {
            string result;
            var directory = new DirectoryInfo(Environment.CurrentDirectory);

            while (!directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }
            
            result = Path.Combine(directory.FullName, "Wizards.Repository", "Data", "data.json");
            return result;
        }
    }
}