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
        public async Task<IActionResult> GetAllAsync(
            [FromQuery] string? userName,
            [FromQuery] string? heroName,
            [FromQuery] int? fromRankingPoints,
            [FromQuery] int? toRankingPoints)
        {
            var allPlayers = await _searchService.FilteringForApi(userName, heroName, fromRankingPoints, toRankingPoints);
            var allPlayersDto = _mapper.Map<List<RankingRecordDto>>(allPlayers);
            return Ok(allPlayersDto);
        }
    }
}