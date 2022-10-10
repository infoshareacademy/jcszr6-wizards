using Microsoft.AspNetCore.Identity;
using Wizards.Core.Model.UserModels.Enums;
using Wizards.Repository.GameDataManagement.Factories.Interfaces;

namespace Wizards.Repository.GameDataManagement.Factories.Implementations;

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