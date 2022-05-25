﻿using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Wizards.BusinessLogic;

namespace Wizards.GUI
{
    public static class TextRepository
    {
        private static readonly Dictionary<MenuMsg, string> Menu;
        private static readonly Dictionary<CreatorMsg, string> Creator;
        private static readonly Dictionary<ValueErrorsMsg, string> ValueErrors;
        public static readonly List<string> RestrictedWords;

        static TextRepository()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Text", "Json");

            Menu = LoadObjectFromFile<Dictionary<MenuMsg, string>>(Path.Combine(path, "Menu.json"));
            Creator = LoadObjectFromFile<Dictionary<CreatorMsg, string>>(Path.Combine(path, "Creator.json"));
            ValueErrors = LoadObjectFromFile<Dictionary<ValueErrorsMsg, string>>(Path.Combine(path, "Value Errors.json"));
            RestrictedWords = LoadObjectFromFile<List<string>>(Path.Combine(path, "RestrictedWords.json"));
        }

        private static T LoadObjectFromFile<T>(string filePath)
        {
            string loadedDataFromFile = File.ReadAllText(filePath);
            var convertedObject = JsonConvert.DeserializeObject<T>(loadedDataFromFile);

            return convertedObject;
        }

        public static string Get(MenuMsg msg) { return Menu[msg]; }
        public static string Get(CreatorMsg msg) { return Creator[msg]; }
        public static string Get(ValueErrorsMsg msg) { return ValueErrors[msg]; }

    }
}