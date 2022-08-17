using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wizards.Services.Validation;
using Wizards.Repository;
using Microsoft.EntityFrameworkCore;
using Wizards.Core.Interfaces;
using Wizards.Repository.Repository;
using Wizards.Services.Factories;
using Wizards.Services.HeroService;
using Wizards.Services.PlayerService;
using Wizards.Services.ItemService;
using Wizards.Core.Model;
using Microsoft.AspNetCore.Identity;
using Wizards.Repository.InitialData;
using Wizards.Services.AuthorizationElements;
using Wizards.Services.AuthorizationElements.Selector;
using Wizards.Services.Inventory;
using Wizards.Services.MerchantService;

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

        // Busines Logic Services Configuration
        services.AddTransient<IPlayerRepository, PlayerRepository>();
        services.AddTransient<IPlayerService, PlayerService>();
        services.AddTransient<IPlayerValidator, PlayerValidator>();

        services.AddTransient<IHeroRepository, HeroRepository>();
        services.AddTransient<IHeroService, HeroService>();
        services.AddTransient<IHeroValidator, HeroValidator>();
        services.AddTransient<IHeroPropertiesFactory, HeroPropertiesFactory>();

        services.AddTransient<ISelector, Selector>();

        services.AddTransient<IItemRepository, ItemRepository>();
        services.AddTransient<IItemService, ItemService>();
        services.AddTransient<IItemValidator, ItemValidator>();

        services.AddTransient<IHeroItemRepository, HeroItemRepository>();
        services.AddTransient<IMerchantService, MerchantService>();
        services.AddTransient<IInventoryService, InventoryService>();

        services.AddDataInitializer();

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

        // Policy for Resource-Based Authorization configuration
        services.AddAuthorization(options =>
        {
            options.AddPolicy("HeroOwnerPolicy", policy =>
                policy.Requirements.Add(new HeroOwnerRequirement()));
        });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("ItemOwnerPolicy", policy =>
                policy.Requirements.Add(new ItemOwnerRequirement()));
        });

        // Resource-Based Authorization Handler Configuration
        services.AddTransient<IAuthorizationHandler, HeroAuthorizationHandler>();
        services.AddTransient<IAuthorizationHandler, ItemAuthorizationHandler>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, WizardsContext wizardsContext, IInitialDataInjector injector)
    {
        wizardsContext.Database.Migrate();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();

            var result = injector.InjectRolesAndUsersAsync();
            result.Wait();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
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