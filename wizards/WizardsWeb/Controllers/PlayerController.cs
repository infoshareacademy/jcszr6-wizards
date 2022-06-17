using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wizards.BusinessLogic;
using Wizards.BusinessLogic.Services;
using Wizards.BusinessLogic.Services.ModelsValidation.Elements;

namespace WizardsWeb.Controllers
{
    public class PlayerController : Controller
    {
        private IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        // GET: PlayerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PlayerController/Details/5
        public ActionResult Details(string userName, string password)
        {
            var id = _playerService.GetIdByLogin(userName, password);
            var player = _playerService.GetById(id);
            return View(player);
        }

        // GET: PlayerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlayerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Player player)
        {
            if (!ModelState.IsValid)
            {
                return View(player);
            }

            try
            {
                _playerService.Add(player);
                return RedirectToAction(nameof(Details), new { userName = player.UserName, password = player.Password});
            }
            catch (InvalidModelException exception)
            {
                foreach (var data in exception.ModelStatesData)
                {
                    ModelState.AddModelError(data.Key, data.Value);
                }
                
                return View(player);
            }
        }

        // GET: PlayerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlayerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Player player)
        {
            if (!ModelState.IsValid)
            {
                return View(player);
            }

            try
            {
                _playerService.Update(id, player);
                return RedirectToAction(nameof(Details), new { id = player.Id });
            }
            catch
            {
                return View(player);
            }
        }

        // GET: PlayerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlayerController/Delete/5
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
