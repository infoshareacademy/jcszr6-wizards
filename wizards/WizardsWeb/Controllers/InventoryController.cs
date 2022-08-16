using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wizards.Core.Model.Enums;
using Wizards.Services.Helpers;
using Wizards.Services.HeroService;
using Wizards.Services.Inventory;
using WizardsWeb.ModelViews.Inventory;
using WizardsWeb.ModelViews.Properties;

namespace WizardsWeb.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventoryService _inventoryService;
        private readonly IMapper _mapper;
        private readonly IHeroService _heroService;

        public InventoryController(IInventoryService inventoryService, IMapper mapper, IHeroService heroService)
        {
            _inventoryService = inventoryService;
            _mapper = mapper;
            _heroService = heroService;
        }

        // /Inventory/ManageInventory/
        public async Task<IActionResult> ManageInventory()
        {
            var heroInventory = await _inventoryService.GetHeroInventory(User);
            var mappedItems = _mapper.Map<List<HeroItemDetailsModelView>>(heroInventory);

            var inventoryModelView = new InventoryModelView();

            inventoryModelView.Equipped.AddRange(mappedItems.Where(hi => hi.Equipped));
            inventoryModelView.Weapons.AddRange(mappedItems.Where(hi => hi.Type == ItemType.Weapon && !hi.Equipped));
            inventoryModelView.Armors.AddRange(mappedItems.Where(hi => hi.Type == ItemType.Armor && !hi.Equipped));
            inventoryModelView.Miscellaneous.AddRange(mappedItems.Where(hi => hi.Type != ItemType.Armor && hi.Type != ItemType.Weapon));

            var hero = await _heroService.Get(User);
            var attributes = hero.Attributes;

            inventoryModelView.Attributes = _mapper.Map<HeroAttributesModelView>(attributes);
            inventoryModelView.Gold = hero.Gold;
            inventoryModelView.ItemTier = hero.GetAvargeItemTier();
            
            return View(inventoryModelView);
        }
    }
}
