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

        Task ByBirthday(int fromYear, int toYear);
        Task ByEmail(string email);
        
    }
}
