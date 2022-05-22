using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Wizards.BusinessLogic;

namespace Wizards.GUI
{
    public static class TextRepository
    {
        private static Dictionary<MenuMsg, string> Menu = new Dictionary<MenuMsg, string>();
        private static Dictionary<CreatorMsg, string> Creator = new Dictionary<CreatorMsg, string>();
        private static Dictionary<ValueErrorsMsg, string> ValueErrors = new Dictionary<ValueErrorsMsg, string>();

        static TextRepository()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Text","Json");
            
            var dataFile = File.ReadAllText(Path.Combine(path, "Menu.json"));
            Menu = JsonConvert.DeserializeObject<Dictionary<MenuMsg,string>>(dataFile);

            dataFile = File.ReadAllText(Path.Combine(path, "Creator.json"));
            Creator = JsonConvert.DeserializeObject<Dictionary<CreatorMsg, string>>(dataFile);

            dataFile = File.ReadAllText(Path.Combine(path, "Value Errors.json"));
            ValueErrors = JsonConvert.DeserializeObject<Dictionary<ValueErrorsMsg, string>>(dataFile);
        }

        public static string Get(MenuMsg msg)
        {
            return Menu[msg];
        }

        public static string Get(CreatorMsg msg)
        {
            return Creator[msg];
        }

        public static string Get(ValueErrorsMsg msg)
        {
            return ValueErrors[msg];
        }

    }
}