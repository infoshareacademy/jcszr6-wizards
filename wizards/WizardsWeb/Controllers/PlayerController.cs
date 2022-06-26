using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wizards.BusinessLogic;
using Wizards.BusinessLogic.Services;
using Wizards.BusinessLogic.Services.ModelsValidation.Elements;
using WizardsWeb.ModelViews;

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
        public ActionResult Details(int id)
        {
            var player = _playerService.Get(id);
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
        public ActionResult Create(PlayerCreateModelView playerForCreate)
        {
            if (!ModelState.IsValid)
            {
                return View(playerForCreate);
            }

            var player = playerForCreate.ToPlayer();

            try
            {
                _playerService.Add(player);
                return RedirectToAction(nameof(Details), new { id = player.Id });
            }
            catch (InvalidModelException exception)
            {
                foreach (var data in exception.ModelStatesData)
                {
                    ModelState.AddModelError(data.Key, data.Value);
                }

                return View(playerForCreate);
            }
        }

        // GET: PlayerController/Edit/5
        public ActionResult Edit(int id)
        {
            var player = _playerService.Get(id);
            return View(player);
        }

        // POST: PlayerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Player player)
        {
            if (!ModelState.IsValid)
            {
                return View(player);
            }

            try
            {
                _playerService.Update(player.Id, player);

                var playerToDetails = _playerService.Get(player.Id);

                return RedirectToAction(nameof(Details), new { id = playerToDetails.Id });
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

        // GET: PlayerController/EditPassword/5
        public ActionResult EditPassword(int id)
        {
            var player = _playerService.Get(id);
            var passwordChage = new PasswordChangeModelView(player);
            return View(passwordChage);
        }

        // POST: PlayerController/EditPassword/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPassword(PasswordChangeModelView passwordChange)
        {
            if (!ModelState.IsValid)
            {
                return View(passwordChange);
            }

            var player = passwordChange.GetPlayerWithNewPassword();

            try
            {
                _playerService.UpdatePassword(player.Id, player);
                return RedirectToAction(nameof(Edit), new { id = player.Id });
            }
            catch (InvalidModelException exception)
            {
                foreach (var data in exception.ModelStatesData)
                {
                    ModelState.AddModelError("NewPassword", data.Value);
                }

                return View(passwordChange);
            }
        }


        // GET: PlayerController/Delete/5
        public ActionResult Delete(int id)
        {
            var player = _playerService.Get(id);
            var playerForDelete = new PlayerDeleteModelView(player);
            return View(playerForDelete);
        }

        // POST: PlayerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PlayerDeleteModelView playerForDelete)
        {
            if (!ModelState.IsValid)
            {
                return View(playerForDelete);
            }

            try
            {
                _playerService.Delete(playerForDelete.Id);
                return RedirectToAction(nameof(Index), "Home");
            }
            catch
            {
                return View(playerForDelete);
            }
        }
    }
}
