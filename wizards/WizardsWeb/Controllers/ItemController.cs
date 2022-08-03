using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Wizards.Core.Model;
using Wizards.Services.ItemService;
using Wizards.Services.Validation.Elements;
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
            catch (InvalidModelException exception)
            {
                foreach (var data in exception.ModelStatesData)
                {
                    ModelState.AddModelError(data.Key, data.Value);
                }

                return View(itemCreate);
            }
        }
        // GET: ItemController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var item = await _itemService.Get(id);
            var itemEdit = _mapper.Map<ItemEditModelView>(item);
            return View(itemEdit);
        }

        // POST: ItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ItemEditModelView itemEdit)
        {
            if (!ModelState.IsValid)
            {
                return View(itemEdit);
            }

            var item = _mapper.Map<Item>(itemEdit);

            try
            {
                await _itemService.Update(item);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidModelException exception)
            {
                foreach (var data in exception.ModelStatesData)
                {
                    ModelState.AddModelError(data.Key, data.Value);
                }

                return View(itemEdit);
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
