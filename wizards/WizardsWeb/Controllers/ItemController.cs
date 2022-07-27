using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Wizards.Core.Model;
using Wizards.Services.ItemService;
using WizardsWeb.ModelViews.ItemModelViews;

namespace WizardsWeb.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public ItemController(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }
        // GET: ItemController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ItemController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ItemController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ItemCreateModelView itemCreate)
        {
            if (!ModelState.IsValid)
            {
                return View(itemCreate);
            }

            var item = _mapper.Map<Item>(itemCreate);

            try
            {
                await _itemService.Add(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(itemCreate);
            }
        }

        // GET: ItemController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ItemController/Edit/5
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

        // GET: ItemController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ItemController/Delete/5
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
