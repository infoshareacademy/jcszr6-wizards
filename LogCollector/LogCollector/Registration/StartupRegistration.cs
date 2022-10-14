using LogCollector.Repository;
using Microsoft.EntityFrameworkCore;

namespace LogCollector.Registration;

public static class StartupRegistration
{
    public static void MigrateDatabase(this IServiceProvider services)
    {
        using (var scope = services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<LogDbContext>();
            context.Database.CloseConnection();
            context.Database.EnsureDeleted();
            context.Database.Migrate();
        }
    }
}