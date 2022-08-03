using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration;
using Wizards.Services.SearchService;
using WizardsWeb.ModelViews;
using WizardsWeb.ModelViews.RankingModelViews;



namespace WizardsWeb.Controllers
{
    public class SearchController : Controller
    {


        private readonly ISearchService _searchService;
        private readonly IMapper _mapper;

        public SearchController(ISearchService searchService, IMapper mapper)
        {
            _searchService = searchService;
            _mapper = mapper;

        }


        public async Task<ActionResult> Index()
        {
            var players = await _searchService.GetAll();
            var playerDetails = _mapper.Map<List<PlayerDetailsDto>>(players);
            return View(new RankingModelViews()
            { PlayerDetailsDto = playerDetails });

        }


        [HttpPost]
        public async Task<ActionResult> Index(RankingModelViews ranking)
        // GET: SearchController/Index
        {


            //var players = await _searchService.GetAll();
            //var playerDetails = _mapper.Map<List<PlayerDetailsDto>>(players);
            //var model = playerDetails;

            if (ranking == null)
            {
                return RedirectToAction("Index");
            }

            var playersDetails = new List<PlayerDetailsDto>();


            if (ranking.UserName != null)

            {
                var filtredPlayers = await _searchService.ByUsername(ranking.UserName);
                playersDetails = _mapper.Map<List<PlayerDetailsDto>>(filtredPlayers);
            }

         
            ranking.PlayerDetailsDto = playersDetails;



            //if (searchModelView.DateOfBirth == null && searchModelView.Email == null && searchModelView.UserName == null)
            //{

            //}

            //int i = 0;
            //foreach (var player in playerDetails)
            //{
            //    player.RankNumber = players[i].Heroes.Sum(x => x.Statistics.RankPoints);
            //    player.GoldHeroNumber = players[i].Heroes.Sum(x => x.Gold);
            //    i++;
            //}
            return View(ranking);
        }



        public async Task<ActionResult> SearchByUserName(RankingModelViews ranking)
            // GET: SearchController/Index
        {
            

            if (ranking == null)
            {
                return RedirectToAction("Index");
            }

            var playersDetails = new List<PlayerDetailsDto>();


            if (ranking.UserName != null)

            {
                var filtredPlayers = await _searchService.ByUsername(ranking.UserName);
                playersDetails = _mapper.Map<List<PlayerDetailsDto>>(filtredPlayers);
            }
            

            ranking.PlayerDetailsDto = playersDetails;


            return View(ranking);
        }


        public async Task<ActionResult> SearchByEmail(RankingModelViews ranking)
            // GET: SearchController/Index
        {


            if (ranking == null)
            {
                return RedirectToAction("Index");
            }

            var playersDetails = new List<PlayerDetailsDto>();


            if (ranking.Email != null)

            {
                var filtredPlayers = await _searchService.ByEmail(ranking.Email);
                playersDetails = _mapper.Map<List<PlayerDetailsDto>>(filtredPlayers);
            }

            ranking.PlayerDetailsDto = playersDetails;


            return View(ranking);
        }


        public async Task<ActionResult> SearchByDate(RankingModelViews ranking)
            // GET: SearchController/Index
        {


            if (ranking == null)
            {
                return RedirectToAction("Index");
            }

            var playersDetails = new List<PlayerDetailsDto>();


            if (ranking.FromDate != null && ranking.ToDate != null)

            {
                var filtredPlayers = await _searchService.ByBirthday(ranking.FromDate, ranking.ToDate);
                playersDetails = _mapper.Map<List<PlayerDetailsDto>>(filtredPlayers);
            }


            ranking.PlayerDetailsDto = playersDetails;


            return View(ranking);
        }





        // GET: SearchController/AllUsers
        public ActionResult AllUsers()
        {
            //return _searchService.GetAll();
            return View();
        }



        // GET: SearchController/SearchUsers
        public ActionResult SearchUsers()
        {
            return View();
        }


        // POST: SearchController/SearchUsers
        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public async Task SearchUsers(SearchModelView username)

        //{
        //    var playersDto = new List<PlayerDetailsDto>();
        //    var players = await _searchService.GetAll();
        //    var playerDetails = _mapper.Map<List<PlayerDetailsDto>>(players);
        //    var model = playerDetails;
        //    return View();



        //}


    }
}
