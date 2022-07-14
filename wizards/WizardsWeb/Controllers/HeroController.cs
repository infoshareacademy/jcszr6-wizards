using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Wizards.Core.Model.Enums;
using Wizards.Services.HeroService;
using Wizards.Services.Validation.Elements;
using WizardsWeb.ModelViews;

namespace WizardsWeb.Controllers
{
    public class HeroController : Controller
    {
        private readonly IHeroService _heroService;

        public HeroController(IHeroService heroService)
        {
            _heroService = heroService;
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
            return View(hero);
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
            return View("SetAvatar", new HeroCreateModelView() { PlayerId = playerId, Profession = profession, AvatarImageNumber = avatar});
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

            var hero = heroCreate.ToHero();

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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HeroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HeroController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HeroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
