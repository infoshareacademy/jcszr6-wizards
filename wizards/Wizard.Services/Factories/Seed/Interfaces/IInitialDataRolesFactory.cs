using Microsoft.AspNetCore.Identity;

namespace Wizards.Services.Factories.Seed.Interfaces;

public interface IInitialDataRolesFactory
{
    List<IdentityRole> GetRolesAsync();
}