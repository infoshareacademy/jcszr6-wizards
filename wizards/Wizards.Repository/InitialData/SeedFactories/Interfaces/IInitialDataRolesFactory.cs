using Microsoft.AspNetCore.Identity;

namespace Wizards.Repository.InitialData.SeedFactories.Interfaces;

public interface IInitialDataRolesFactory
{
    List<IdentityRole> GetRolesAsync();
}