using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizards.Core.Interfaces;
using Wizards.Core.Model;


namespace Wizards.Services.SearchService
{
    public class SearchService : ISearchService
    {

        private readonly IPlayerRepository _playerRepository;

        

        public SearchService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public Task<List<Player>> GetAll()
        {
            return  _playerRepository.GetAll();

        }


        public async Task<List<Player>> ByUsername(string username)
        {
            return await _playerRepository.GetByUserName(username);
        }



        public async Task<List<Player>> ByBirthday(int fromYear, int toYear)
        {
           return await _playerRepository.GetByYearRange(fromYear, toYear);
        }



        public async Task<List<Player>> ByEmail(string email)
        {
            return await _playerRepository.GetByEmailAddress(email);
        }




    }
}
