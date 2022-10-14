using Microsoft.Extensions.DependencyInjection;
using Wizards.Core.Interfaces.LoggerInterface;
using Wizards.LogsSender.Logger;

namespace Wizards.LogsSender.ServiceRegistration;

public static class ServiceRegistration
{
    public static void AddWizardLogger(this IServiceCollection service)
    {
        service.AddTransient<IWizardsLogger, WizardsLogger>();
    }
}