using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using Wizards.Core.Interfaces.LoggerInterface;
using WizardsWeb.Models;

namespace WizardsWeb.Controllers;

public class HomeController : Controller
{
    private readonly IWizardsLogger _logger;


    public HomeController(IWizardsLogger logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Authors()
    {
        return View();
    }

    public async Task<IActionResult> Error404()
    {
        await _logger.SendLogAsync<HeroController>(LogLevel.Error, "404 Not Found error page was shown");
        return View("Error404");
    }

    public async Task<IActionResult> Error500()
    {
        await _logger.SendLogAsync<HeroController>(LogLevel.Error, "500 Internal Server Error page was shown");
        return View("Error500");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
