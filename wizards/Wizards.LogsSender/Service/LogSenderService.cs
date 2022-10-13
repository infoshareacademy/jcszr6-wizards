using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Wizards.LogsSender.Service
{
    internal class LogSenderService : ILogSenderService
    {
        public Task SendLogAsync(LogLevel logLevel, string message, params object?[] args)
        {
            var logRecord = new LogRecord();
            logRecord.LogMessage = message;
            logRecord.LogLevel = logLevel.ToString();
            logRecord.AppName = "Wizards";
            logRecord.TimeStamp = DateTime.Now;
            logRecord.Properties = GetSerializedArguments(args);
        }

        private string GetSerializedArguments(object?[] args)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("{");
            int counter = 1;

            foreach (var arg in args)
            {
                stringBuilder.Append($"\"SerializedObject{counter}\":");
                var json = "";

                try
                {
                    json = JsonSerializer.Serialize(arg);
                }
                catch (Exception)
                {
                    json = $"\"Can not serialize object: {arg.GetType()}\"";
                }

                stringBuilder.Append(json);
                stringBuilder.Append(",");
                counter++;
            }
            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }
    }
}