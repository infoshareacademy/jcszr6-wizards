using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration;
using Wizards.Services.SearchService;
using WizardsWeb.ModelViews;
using WizardsWeb.ModelViews.PlayerDetailsDto;
using WizardsWeb.ModelViews.SearchModelViews;


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




        public async Task<ActionResult> Index(SearchModelView searchModelView)
        // GET: SearchController/Index
        {

            var playersDto = new List<PlayerDetailsDto>();
            var players = await  _searchService.GetAll();
            var playerDetails = _mapper.Map<List<PlayerDetailsDto>>(players);
            var model = playerDetails;
            if (searchModelView.DateOfBirth == null && searchModelView.Email == null && searchModelView.UserName == null)
            {

            }
            
            //int i = 0;
            //foreach (var player in playerDetails)
            //{
            //    player.RankNumber = players[i].Heroes.Sum(x => x.Statistics.RankPoints);
            //    player.GoldHeroNumber = players[i].Heroes.Sum(x => x.Gold);
            //    i++;
            //}
         return View(model);
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
