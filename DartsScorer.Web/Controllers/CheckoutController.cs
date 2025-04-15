using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DartsScorer.Web.Models;
using DartsScorer.Web.Services;

namespace DartsScorer.Web.Controllers;

public class CheckoutController : Controller
{
    private readonly ICheckoutService _checkoutService;

    public CheckoutController(ICheckoutService checkoutService)
    {
        _checkoutService = checkoutService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult CheckoutResult(int score)
    {
        try
        {
            var model = _checkoutService.GetCheckoutResult(score);
            return View(model);
        }
        catch (Exception e)
        {
            ViewBag.Exception = e;
            return View("NoCheckout");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
