using Microsoft.Extensions.DependencyInjection;
using Wizards.Core.Interfaces.LoggerInterface;
using Wizards.LogsSender.Logger;
using Wizards.LogsSender.RestApiClient;

namespace Wizards.LogsSender.ServiceRegistration;

public static class ServiceRegistration
{
    public static void RegisterHttpClients(this IServiceCollection service)
    {
        service.AddHttpClient(LogCollectorApiConfiguration.LogCollectorApiHttpClientName,
                client => { client.BaseAddress = new Uri("https://localhost:7013"); })
            .AddPolicyHandler(LogCollectorApiConfiguration.TimeoutPolicy)
            .AddPolicyHandler(LogCollectorApiConfiguration.RetryPolicy);
    }

    public static void AddWizardLogger(this IServiceCollection service)
    {
        service.AddTransient<IWizardsLogger, WizardsLogger>();
    }
}