using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DartsScorer.Web.Models;

namespace DartsScorer.Web.Controllers;

public class CheckoutController : Controller
{
    private readonly ILogger<CheckoutController> _logger;

    public CheckoutController(ILogger<CheckoutController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult CheckoutResult(int score)
    {
        var calculator = new Main.Checkout.CheckoutCalculator();
        try
        {
            var model = new CheckoutResultModel
            {
                Score = score,
                Results = calculator.Calculate(score)
            };
        
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
