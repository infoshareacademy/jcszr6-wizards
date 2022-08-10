using Microsoft.AspNetCore.Identity;
using Wizards.Core.Model.Enums;
using Wizards.Repository.InitialData.SeedFactories.Interfaces;

namespace Wizards.Repository.InitialData.SeedFactories.Implementations;

public class InitialDataRolesFactory : IInitialDataRolesFactory
{
    public  List<IdentityRole<int>> GetRolesAsync()
    {
        var result = new List<IdentityRole<int>>();
        var roles = Enum.GetNames(typeof(UserRoles)).ToList();

        foreach (var role in roles)
        {
            result.Add(new IdentityRole<int>(role));
        }

        return result;
    }
}