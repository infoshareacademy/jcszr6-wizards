using Microsoft.Extensions.DependencyInjection;
using Wizards.LogsSender.Sender;

namespace Wizards.LogsSender.ServiceRegistration;

public static class ServiceRegistration
{
    public static void AddWizardLogger(this IServiceCollection service)
    {
        service.AddTransient<IWizardsLogger, WizardsLogger>();
    }
}