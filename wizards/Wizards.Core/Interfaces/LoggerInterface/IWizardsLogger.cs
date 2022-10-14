using Microsoft.Extensions.Logging;

namespace Wizards.Core.Interfaces.LoggerInterface;
public interface IWizardsLogger
{
    Task SendLogAsync<T>(LogLevel logLevel, string message, params object?[] args);
}