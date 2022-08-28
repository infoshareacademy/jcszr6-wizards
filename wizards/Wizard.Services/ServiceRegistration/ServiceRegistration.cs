using Microsoft.Extensions.DependencyInjection;
using Wizards.Services.AuthorizationElements.Selector;
using Wizards.Services.Factories;
using Wizards.Services.HeroService;
using Wizards.Services.Inventory;
using Wizards.Services.ItemService;
using Wizards.Services.MerchantService;
using Wizards.Services.PlayerService;
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
}