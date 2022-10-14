using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wizards.Core.Interfaces.LoggerInterface;
using Wizards.Core.Model.UserModels;
using Wizards.Services.Extentions;
using Wizards.Services.HeroService;
using Wizards.Services.Validation.Elements;
using WizardsWeb.ModelViews.HeroModelViews;

namespace WizardsWeb.Controllers;
[Authorize]
public class HeroController : Controller
{
    private readonly IHeroService _heroService;
    private readonly IMapper _mapper;
    private readonly IWizardsLogger _logger;

    public HeroController(IHeroService heroService, IMapper mapper, IWizardsLogger logger)
    {
        _heroService = heroService;
        _mapper = mapper;
        _logger = logger;
    }

    // GET: HeroController/Details/5
    public async Task<ActionResult> Details()
    {
        try
        {
            var hero = await _heroService.Get(User);
            var heroDetails = _mapper.Map<HeroDetailsModelView>(hero);
            heroDetails.Basics.ShowButtons = true;
            return View(heroDetails);
        }
        catch
        {
            return RedirectToAction("Details", "Player");
        }
    }

    // GET: HeroController/Create
    public ActionResult StartCreation()
    {
        var model = new HeroCreateModelView() { AvatarImageNumber = 1 };
        return View("SetProfession", model);
    }

    public ActionResult SetProfessionView(HeroCreateModelView heroCreate)
    {
        ModelState.Clear();
        return View("SetProfession", heroCreate);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult SetProfession(HeroCreateModelView heroCreate)
    {
        ModelState.Clear();
        return View("SetAvatar", heroCreate);
    }

    public ActionResult SetAvatarView(HeroCreateModelView heroCreate)
    {
        ModelState.Clear();
        return View("SetAvatar", heroCreate);
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
            await _logger.SendLogAsync<HeroController>(LogLevel.Information,$"{heroCreate.NickName} hero create failed", ModelState);
            return View(heroCreate);
        }

        var hero = _mapper.Map<Hero>(heroCreate);

        try
        {
            await _heroService.Add(User, hero);
            await _logger.SendLogAsync<HeroController>(LogLevel.Information, $"{heroCreate.NickName} hero create successful");
            return RedirectToAction("SelectHero", "Selector", new { id = hero.Id, actionName = "Details" });
        }
        catch (Exception exception)
        {
            ModelState.AddModelErrorByException(exception);
            if (exception is InvalidModelException)
            {
                await _logger.SendLogAsync<HeroController>(LogLevel.Information, $"{heroCreate.NickName} hero create failed {exception.GetType()}", ModelState);
            }
            else
            {
                await _logger.SendLogAsync<HeroController>(LogLevel.Error, $"{heroCreate.NickName} hero create failed {exception.GetType()}", ModelState);
            }
            return View(heroCreate);
        }
    }

    // GET: HeroController/Edit/5
    public async Task<ActionResult> EditNickName()
    {
        try
        {
            var hero = await _heroService.Get(User);
            var heroEdit = _mapper.Map<HeroEditModelView>(hero);
            heroEdit.Cost = _heroService.GetChangeNickNameCost();
            return View(heroEdit);
        }
        catch
        {
            return RedirectToAction("Details", "Player");
        }
    }

    // POST: HeroController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> EditNickName(HeroEditModelView heroEdit)
    {
        var newNickName = heroEdit.NickName;
        var originalHero = await _heroService.Get(User);

        heroEdit = _mapper.Map<HeroEditModelView>(originalHero);
        heroEdit.NickName = newNickName;
        heroEdit.Cost = _heroService.GetChangeNickNameCost();

        if (!ModelState.IsValid)
        {
            await _logger.SendLogAsync<HeroController>(LogLevel.Information, $"{heroEdit.NickName} hero edit nick name failed", ModelState);
            return View(heroEdit);
        }

        var hero = _mapper.Map<Hero>(heroEdit);

        try
        {
            await _heroService.Update(originalHero.Id, hero);
            await _logger.SendLogAsync<HeroController>(LogLevel.Information, $"{heroEdit.NickName} hero edit nick name successful");
            return RedirectToAction(nameof(Details));
        }
        catch (Exception exception)
        {
            ModelState.AddModelErrorByException(exception);
            if (exception is InvalidModelException)
            {
                await _logger.SendLogAsync<HeroController>(LogLevel.Information, $"{heroEdit.NickName} hero edit nick name failed {exception.GetType()}", ModelState);
            }
            else
            {
                await _logger.SendLogAsync<HeroController>(LogLevel.Error, $"{heroEdit.NickName} hero edit nick name failed {exception.GetType()}", ModelState);
            }
            return View(heroEdit);
        }
    }

    // GET: HeroController/Edit/5
    public async Task<ActionResult> EditAvatar(int id)
    {
        try
        {
            var hero = await _heroService.Get(User);
            var heroEdit = _mapper.Map<HeroEditModelView>(hero);
            heroEdit.Cost = _heroService.GetChangeAvatarCost();
            return View(heroEdit);
        }
        catch
        {
            return RedirectToAction("Details", "Player");
        }
    }

    // POST: HeroController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> EditAvatar(HeroEditModelView heroEdit)
    {
        var newAvatarNumber = heroEdit.AvatarImageNumber;
        var originalHero = await _heroService.Get(User);

        heroEdit = _mapper.Map<HeroEditModelView>(originalHero);
        heroEdit.AvatarImageNumber = newAvatarNumber;
        heroEdit.Cost = _heroService.GetChangeAvatarCost();

        ModelState.Clear();

        var hero = _mapper.Map<Hero>(heroEdit);

        try
        {
            await _heroService.Update(originalHero.Id, hero);
            await _logger.SendLogAsync<HeroController>(LogLevel.Information, $"{originalHero.NickName} hero edit avatar successful");
            return RedirectToAction(nameof(Details));
        }
        catch (Exception exception)
        {
            ModelState.AddModelErrorByException(exception);
            if (exception is InvalidModelException)
            {
                await _logger.SendLogAsync<HeroController>(LogLevel.Information, $"{originalHero.NickName} hero edit avatar failed {exception.GetType()}", ModelState, exception);
            }
            else
            {
                await _logger.SendLogAsync<HeroController>(LogLevel.Information, $"{originalHero.NickName} hero edit avatar failed {exception.GetType()}", ModelState, exception);
            }
            return View(heroEdit);
        }
    }

    // GET: HeroController/Delete/5
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var hero = await _heroService.Get(User);
            var heroDelete = _mapper.Map<HeroDeleteModelView>(hero);
            return View(heroDelete);
        }
        catch
        {
            return RedirectToAction("Details", "Player");
        }
    }

    // POST: HeroController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(HeroDeleteModelView heroDelete)
    {
        var originalHero = await _heroService.Get(User);
        var confirmNickName = heroDelete.ConfirmNickName;

        heroDelete = _mapper.Map<HeroDeleteModelView>(originalHero);

        if (!ModelState.IsValid)
        {
            await _logger.SendLogAsync<HeroController>(LogLevel.Information, $"{originalHero.NickName} hero delete failed (The confirmation NickName not correct)", ModelState);
            return View(heroDelete);
        }

        try
        {
            await _heroService.Delete(originalHero.Id, confirmNickName);
            await _logger.SendLogAsync<HeroController>(LogLevel.Information, $"{originalHero.NickName} hero delete successful");
            return RedirectToAction(nameof(Details), "Player");
        }
        catch (Exception exception)
        {
            ModelState.AddModelErrorByException(exception);
            if (exception is InvalidModelException)
            {
                await _logger.SendLogAsync<HeroController>(LogLevel.Information, $"{originalHero.NickName} hero delete failed {exception.GetType()}", ModelState);
            }
            else
            {
                await _logger.SendLogAsync<HeroController>(LogLevel.Information, $"{originalHero.NickName} hero delete failed {exception.GetType()}", ModelState);
            }
            return View(heroDelete);
        }
    }
}