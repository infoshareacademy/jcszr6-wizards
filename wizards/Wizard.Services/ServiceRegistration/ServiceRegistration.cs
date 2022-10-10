using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Wizards.Services.AuthorizationElements;
using Wizards.Services.AuthorizationElements.Selector;
using Wizards.Services.Factories;
using Wizards.Services.HeroService;
using Wizards.Services.Inventory;
using Wizards.Services.ItemService;
using Wizards.Services.MerchantService;
using Wizards.Services.PlayerService;
using Wizards.Services.ScheduleService;
using Wizards.Services.SearchService;
using Wizards.Services.Validation;

namespace Wizards.Services.ServiceRegistration;

public static class ServiceRegistration
{
    public static void AddModelServices(this IServiceCollection services)
    {
        services.AddTransient<IPlayerService, PlayerService.PlayerService>();
        services.AddTransient<IHeroService, HeroService.HeroService>();
        
        services.AddTransient<IHeroPropertiesFactory, HeroPropertiesFactory>();
        services.AddTransient<INewHeroFactory, NewHeroFactory>();
        
        services.AddTransient<ISelector, Selector>();

        services.AddTransient<ISearchService, SearchService.SearchService>();
        services.AddTransient<IItemService, ItemService.ItemService>();

        services.AddTransient<IMerchantService, MerchantService.MerchantService>();
        services.AddTransient<IInventoryService, InventoryService>();
    }

    public static void AddValidators(this IServiceCollection services)
    {
        services.AddTransient<IPlayerValidator, PlayerValidator>();
        services.AddTransient<IHeroValidator, HeroValidator>();
        services.AddTransient<IItemValidator, ItemValidator>();
    }

    public static void AddAuthorizationElements(this IServiceCollection services)
    {
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

    public static void AddQuartzSchedule(this IServiceCollection services)
    {
        services.AddQuartz(q =>
        {
            q.UseMicrosoftDependencyInjectionJobFactory();

            q.ScheduleJob<DailyJob>(trigger => trigger
                .WithIdentity("DailyJobTrigger")
                .WithSchedule(
                    CronScheduleBuilder.DailyAtHourAndMinute(0, 0)
                        .InTimeZone(TimeZoneInfo.Utc))
            );

            q.ScheduleJob<WeeklyJob>(trigger => trigger
                .WithIdentity("WeeklyJobTrigger")
                .WithSchedule(
                    CronScheduleBuilder.WeeklyOnDayAndHourAndMinute(DayOfWeek.Monday, 0, 0)
                    .InTimeZone(TimeZoneInfo.Utc))
            );
        });

        services.AddQuartzServer(q => q.WaitForJobsToComplete = true);
    }
}