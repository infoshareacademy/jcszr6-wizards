using Microsoft.AspNetCore.Identity;

namespace Wizards.Repository.GameDataManagement.Factories.Interfaces;

public interface IInitialDataRolesFactory
{
    List<IdentityRole<int>> GetRolesAsync();
}