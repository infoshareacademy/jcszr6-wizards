using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Wizards.Core.Model.UserModels;
using Wizards.GamePlay.ServicesRegistration;
using Wizards.Repository;
using Wizards.Services.ServiceRegistration;
using Wizards.Repository.ServiceRegistration;
using WizardsWeb.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog;
using Wizards.LogsSender.ServiceRegistration;
using Wizards.Repository.GameDataManagement;

namespace WizardsWeb;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();

        // Business Logic Services Configuration
        services.AddRepositories();
        services.AddDataInitializer();

        services.AddValidators();
        services.AddModelServices();
        services.AddQuartzSchedule();

        services.AddGamePlayServices();
        services.AddWizardLogger();

        // External Packages Configuration
        var connectionString = Configuration.GetConnectionString("WizardDatabase");
        services.AddDbContext<WizardsContext>(options => options.UseSqlServer(connectionString));

        var profileAssembly = typeof(Startup).Assembly;
        services.AddAutoMapper(profileAssembly);

        // Identity necessary configuration
        services.AddIdentity<Player, IdentityRole<int>>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
        })
            .AddEntityFrameworkStores<WizardsContext>();

        services.AddRazorPages();

        // Simple Authorization configuration
        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/Player/Login/";
            options.AccessDeniedPath = "/Home/Index/";
            options.LogoutPath = "/Home/Index/";
        });

        services.AddAuthorizationElements();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IGameDataManager gameDataManager, ILoggerFactory loggerFactory)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            // app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        gameDataManager.ApplicationStartupScheduleAsync(env.IsDevelopment()).Wait();

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(Configuration)
            .Enrich.FromLogContext()
            .CreateLogger();

        loggerFactory.AddSerilog();

        app.UseMiddleware<MyExceptionHandler>();

        app.Use(async (context, next) =>
        {
            await next();
            if (context.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                context.Request.Path = "/Home/Error404";
                await next();
            }
        });

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}