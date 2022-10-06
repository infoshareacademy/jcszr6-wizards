using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wizards.RankingAPI.Models.Dto;
using Wizards.Services.SearchService;

namespace Wizards.RankingAPI.Controllers
{
    [Route("api/ranking")]
    [ApiController]
    public class RankingController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISearchService _searchService;

        public RankingController(IMapper mapper, ISearchService searchService)
        {
            _mapper = mapper;
            _searchService = searchService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var allPlayers = await _searchService.GetAll();
            var allPlayersDto = _mapper.Map<List<RankingRecordDto>>(allPlayers);
            return Ok(allPlayersDto);
        }

        [HttpGet("api/ranking/search-by-userName/{userName}")]
        public async Task<IActionResult> GetAllAsync(string userName)
        {
            var players = await _searchService.ByUserName(userName);
            var playersDto = _mapper.Map<List<RankingRecordDto>>(players);
            return Ok(playersDto);
        }
    }
}