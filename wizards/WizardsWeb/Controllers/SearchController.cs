using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wizards.Services.SearchService;
using WizardsWeb.ModelViews.RankingModelViews;

namespace WizardsWeb.Controllers;

public class SearchController : Controller
{
    private readonly ISearchService _searchService;
    private readonly IMapper _mapper;

    public SearchController(ISearchService searchService, IMapper mapper)
    {
        _searchService = searchService;
        _mapper = mapper;
    }

    // GET: SearchController/Index
    public async Task<ActionResult> Index()
    {
        var players = await _searchService.GetAll();
        var playerDetails = _mapper.Map<List<PlayerDetailsDto>>(players).OrderByDescending(n => n.RankNumber).ToList();
        return View(new RankingModelViews()
        { PlayerDetailsDto = playerDetails });
    }

    [HttpPost]
    public async Task<ActionResult> Index(RankingModelViews ranking)
    {
        if (ranking == null)
        {
            return RedirectToAction("Index");
        }

        var playersDetails = new List<PlayerDetailsDto>();

        if (ranking.UserName != null)
        {
            var filtredPlayers = await _searchService.ByUserName(ranking.UserName);
            playersDetails = _mapper.Map<List<PlayerDetailsDto>>(filtredPlayers).OrderByDescending(n => n.RankNumber)

                .ToList();

            ranking.PlayerDetailsDto = playersDetails;
            return View(ranking);
        }

        if (ranking.HeroName != null)
        {
            var filtredPlayers = await _searchService.ByHeroName(ranking.HeroName);
            playersDetails = _mapper.Map<List<PlayerDetailsDto>>(filtredPlayers).OrderByDescending(n => n.RankNumber)
                .ToList();

            ranking.PlayerDetailsDto = playersDetails;
            return View(ranking);
        }

        if (ranking.Email != null)
        {
            var filtredPlayers = await _searchService.ByEmail(ranking.Email);
            playersDetails = _mapper.Map<List<PlayerDetailsDto>>(filtredPlayers).OrderByDescending(n => n.RankNumber).ToList();
            ranking.PlayerDetailsDto = playersDetails;
            return View(ranking);
        }

        if (ranking.FromRankPoints != null && ranking.ToRankPoints != null)
        {
            var filtredPlayers = await _searchService.ByRankPoints(ranking.FromRankPoints, ranking.ToRankPoints);
            playersDetails = _mapper.Map<List<PlayerDetailsDto>>(filtredPlayers).OrderByDescending(n => n.RankNumber)
                .ToList();
            ranking.PlayerDetailsDto = playersDetails;
            return View(ranking);
        }

        return View(ranking);
    }
    
}