using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Wizards.Core.Model;
using Wizards.Core.Model.Enums;
using Wizards.Services.HeroService;
using Wizards.Services.Validation.Elements;
using WizardsWeb.ModelViews;
using WizardsWeb.ModelViews.Properties;

namespace WizardsWeb.Controllers
{
    public class HeroController : Controller
    {
        private readonly IHeroService _heroService;
        private readonly IMapper _mapper;

        public HeroController(IHeroService heroService, IMapper mapper)
        {
            _heroService = heroService;
            _mapper = mapper;
        }
        // GET: HeroController
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: HeroController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var hero = await _heroService.Get(id);
            var heroDetails = _mapper.Map<HeroDetailsModelView>(hero);
            heroDetails.Basics = _mapper.Map<HeroBasicsModelView>(hero);
            return View(heroDetails);
        }

        // GET: HeroController/Create
        public ActionResult StartCreation(int playerId)
        {
            return View("SetProfession", new HeroCreateModelView() { PlayerId = playerId });
        }

        public ActionResult SetProfessionView(int playerId, HeroProfession profession)
        {
            return View("SetProfession", new HeroCreateModelView() { PlayerId = playerId, Profession = profession });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetProfession(HeroCreateModelView heroCreate)
        {
            ModelState.Clear();
            return View("SetAvatar", heroCreate);
        }

        public ActionResult SetAvatarView(int playerId, HeroProfession profession, int avatar)
        {
            return View("SetAvatar", new HeroCreateModelView() { PlayerId = playerId, Profession = profession, AvatarImageNumber = avatar });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetAvatar(HeroCreateModelView heroCreate)
        {
            ModelState.Clear();
            return View("Create", heroCreate);
        }

        // POST: HeroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(HeroCreateModelView heroCreate)
        {
            if (!ModelState.IsValid)
            {
                return View(heroCreate);
            }

            var hero = _mapper.Map<Hero>(heroCreate);

            try
            {
                await _heroService.Add(heroCreate.PlayerId, hero);
                return RedirectToAction(nameof(Details), new { id = hero.Id });
            }
            catch (InvalidModelException exception)
            {
                foreach (var data in exception.ModelStatesData)
                {
                    ModelState.AddModelError(data.Key, data.Value);
                }

                return View(heroCreate);
            }
        }

        // GET: HeroController/Edit/5
        public async Task<ActionResult> EditNickName(int id)
        {
            var hero = await _heroService.Get(id);
            var heroEdit = _mapper.Map<HeroEditModelView>(hero);
            heroEdit.Cost = _heroService.GetChangeNickNameCost();
            return View(heroEdit);
        }

        // POST: HeroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditNickName(HeroEditModelView heroEdit)
        {
            var originalHero = await _heroService.Get(heroEdit.Id);
            heroEdit.AvatarImageNumber = originalHero.AvatarImageNumber;
            heroEdit.Gold = originalHero.Gold;
            heroEdit.Cost = _heroService.GetChangeNickNameCost();

            if (!await _heroService.CanChangeNickName(heroEdit.Id))
            {
                ModelState.AddModelError("NickName", "You don't have enough gold!");
            }

            if (!ModelState.IsValid)
            {
                return View(heroEdit);
            }

            var hero = _mapper.Map<Hero>(heroEdit);
            hero.Profession = originalHero.Profession;

            try
            {
                await _heroService.Update(hero.Id, hero);
                return RedirectToAction(nameof(Details), new { id = hero.Id });
            }
            catch (InvalidModelException exception)
            {
                foreach (var data in exception.ModelStatesData)
                {
                    ModelState.AddModelError(data.Key, data.Value);
                }

                return View(heroEdit);
            }
        }

        // GET: HeroController/Edit/5
        public async Task<ActionResult> EditAvatar(int id)
        {
            var hero = await _heroService.Get(id);
            var heroEdit = _mapper.Map<HeroEditModelView>(hero);
            heroEdit.Cost = _heroService.GetChangeAvatarCost();
            return View(heroEdit);
        }

        // POST: HeroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAvatar(HeroEditModelView heroEdit)
        {
            var originalHero = await _heroService.Get(heroEdit.Id);
            heroEdit.NickName = originalHero.NickName;
            heroEdit.Gold = originalHero.Gold;
            heroEdit.Cost = _heroService.GetChangeNickNameCost();
            ModelState.Clear();

            if (!await _heroService.CanChangeAvatar(heroEdit.Id))
            {
                ModelState.AddModelError("AvatarImageNumber", "You don't have enough gold!");
            }

            if (!ModelState.IsValid)
            {
                return View(heroEdit);
            }

            var hero = _mapper.Map<Hero>(heroEdit);
            hero.Profession = originalHero.Profession;

            try
            {
                await _heroService.Update(hero.Id, hero);
                return RedirectToAction(nameof(Details), new { id = hero.Id });
            }
            catch (InvalidModelException exception)
            {
                foreach (var data in exception.ModelStatesData)
                {
                    ModelState.AddModelError(data.Key, data.Value);
                }

                return View(heroEdit);
            }
        }

        // GET: HeroController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var hero = await _heroService.Get(id);
            var heroDelete = _mapper.Map<HeroDeleteModelView>(hero);
            heroDelete.Basics = _mapper.Map<HeroBasicsModelView>(hero);
            return View(heroDelete);
        }

        // POST: HeroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(HeroDeleteModelView heroDelete)
        {
            var heroOriginalModel = await _heroService.Get(heroDelete.Id);

            if (heroOriginalModel.NickName != heroDelete.ConfirmNickName)
            {
                ModelState.AddModelError("ConfirmNickName", "Invalid Nick Name!");
            }

            heroDelete = _mapper.Map<HeroDeleteModelView>(heroOriginalModel);
            heroDelete.Basics = _mapper.Map<HeroBasicsModelView>(heroOriginalModel);

            if (!ModelState.IsValid)
            {
                return View(heroDelete);
            }

            try
            {
                await _heroService.Delete(heroDelete.Id);
                return RedirectToAction(nameof(Details), "Player", new { id = heroDelete.PlayerId });
            }
            catch
            {
                return View(heroDelete);
            }
        }
    }
}
