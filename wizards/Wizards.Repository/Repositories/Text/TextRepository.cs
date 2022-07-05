using Newtonsoft.Json;
using Wizards.Repository.Repositories.Text.Enums;

namespace Wizards.Repository.Repositories.Text
{
    public static class TextRepository
    {
        private static readonly Dictionary<ValueErrorsMsg, string> ValueErrors;

        public static readonly List<string> RestrictedWords;

        static TextRepository()
        {
            string path = Path.Combine(Environment.CurrentDirectory,"..", "Wizards.Repository", "Repositories", "Text", "Json");

            ValueErrors = LoadObjectFromFile<Dictionary<ValueErrorsMsg, string>>(Path.Combine(path, "Value Errors.json"));
            RestrictedWords = LoadObjectFromFile<List<string>>(Path.Combine(path, "RestrictedWords.json"));

        }

        private static T LoadObjectFromFile<T>(string filePath)
        {
            string loadedDataFromFile = File.ReadAllText(filePath);
            var convertedObject = JsonConvert.DeserializeObject<T>(loadedDataFromFile);

            return convertedObject;
        }

        public static string Get(ValueErrorsMsg msg) { return ValueErrors[msg]; }

    }
}