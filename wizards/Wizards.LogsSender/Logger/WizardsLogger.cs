using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Wizards.Core.Interfaces.LoggerInterface;
using Wizards.LogsSender.Models;
using Wizards.LogsSender.RestApiClient;

namespace Wizards.LogsSender.Logger;

public class WizardsLogger : IWizardsLogger
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly IHttpClientFactory _clientFactory;

    public WizardsLogger(ILoggerFactory loggerFactory, IHttpClientFactory clientFactory)
    {
        _loggerFactory = loggerFactory;
        _clientFactory = clientFactory;
    }

    public Task SendLogAsync<T>(LogLevel logLevel, string message, params object?[] args)
    {
        var logRecord = new LogRecord();
        _loggerFactory.CreateLogger<T>().Log(logLevel, message, args);
        
        logRecord.TimeStamp = DateTime.Now;
        logRecord.LogMessage = message;
        logRecord.LogLevel = logLevel.ToString();
        logRecord.AppName = "Wizards";
        logRecord.Exception = "";
        logRecord.Properties = GetSerializedArguments(args);

        SendLogToLogCollector(logRecord);

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

    private async Task SendLogToLogCollector(LogRecord logRecord)
    {
        var httpClient = _clientFactory.CreateLogCollectorHttpClient();
        
        try
        {
            var response = await httpClient.PostAsJsonAsync("/api/logs", logRecord);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception exception)
        {
            _loggerFactory.CreateLogger<WizardsLogger>().LogError($"Cannot send log record to LogCollector. API [POST]: {httpClient.BaseAddress}/api/logs does not respond", logRecord, exception);
        }
    }
}