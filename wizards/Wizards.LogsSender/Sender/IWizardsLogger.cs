using Microsoft.Extensions.Logging;

namespace Wizards.LogsSender.Sender;
public interface IWizardsLogger
{
    Task SendLogAsync<T>(LogLevel logLevel, string message, params object?[] args);
}