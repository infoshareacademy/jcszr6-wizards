using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizards.Core.Model;

namespace Wizards.Services.SearchService
{
    public interface ISearchService
    {

        Task<List<Player>> GetAll();
        Task<List<Player>> ByUsername(string username);

        Task<List<Player>> ByBirthday(int fromYear, int toYear);
        Task<List<Player>> ByEmail(string email);
        
    }
}
