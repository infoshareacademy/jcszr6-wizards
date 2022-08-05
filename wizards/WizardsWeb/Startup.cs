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
using Wizards.Core.Model;
using Microsoft.AspNetCore.Identity;
using Wizards.Services.PermissionService;

namespace WizardsWeb
{
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

            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IPlayerValidator, PlayerValidator>();

            services.AddTransient<IHeroRepository, HeroRepository>();
            services.AddTransient<IHeroService, HeroService>();
            services.AddTransient<IHeroValidator, HeroValidator>();
            services.AddTransient<IHeroPropertiesFactory, HeroPropertiesFactory>();

            services.AddTransient<IPermissionService, PermissionService>();

            services.AddIdentity<Player, IdentityRole<int>>(
                    options =>
                    {
                        options.SignIn.RequireConfirmedAccount = false;
                        //Other options go here

                    })
                .AddEntityFrameworkStores<WizardsContext>();

            services.AddRazorPages();

            var connectionString = Configuration.GetConnectionString("WizardDatabase");
            services.AddDbContext<WizardsContext>(options => options.UseSqlServer(connectionString));

            var profileAssembly = typeof(Startup).Assembly;
            services.AddAutoMapper(profileAssembly);

            


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, WizardsContext wizardsContext)
        {
            wizardsContext.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
}
