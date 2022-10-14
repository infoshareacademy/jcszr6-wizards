using System.Text.Json;
using Microsoft.Extensions.Logging;
using Wizards.Core.Interfaces.LoggerInterface;
using Wizards.LogsSender.Models;

namespace Wizards.LogsSender.Logger;

public class WizardsLogger : IWizardsLogger
{
    private readonly ILoggerFactory _loggerFactory;
    
    public WizardsLogger(ILoggerFactory loggerFactory)
    {
        _loggerFactory = loggerFactory;
    }

    public Task SendLogAsync<T>(LogLevel logLevel, string message, params object?[] args)
    {
        var logRecord = new LogRecord();
        _loggerFactory.CreateLogger<T>().Log(logLevel, message, args);
        
        logRecord.TimeStamp = DateTime.Now;
        logRecord.LogMessage = message;
        logRecord.LogLevel = logLevel.ToString();
        logRecord.AppName = "Wizards";
        logRecord.Properties = GetSerializedArguments(args);
        
        return Task.CompletedTask;
    }

    private string GetSerializedArguments(object?[] args)
    {
        int counter = 1;
        var argumentRecords = new List<ArgumentRecord>();

        foreach (var arg in args)
        {
            var argumentRecord = new ArgumentRecord();
            var json = "";

            try
            {
                json = JsonSerializer.Serialize(arg);
            }
            catch (Exception)
            {
                json = $"Cannot serialize object: {arg.GetType()}";
            }

            argumentRecord.Number = counter;
            argumentRecord.JsonSerializedObject = json;
            argumentRecord.ObjectType = arg.GetType().ToString();

            argumentRecords.Add(argumentRecord);

            counter++;
        }

        var result = JsonSerializer.Serialize(argumentRecords);
        return result;
    }
}