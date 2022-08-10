using Microsoft.EntityFrameworkCore;

namespace Wizards.Repository.InitialData;

public interface IInitialDataInjector
{
    Task InjectRolesAndUsersAsync();
}