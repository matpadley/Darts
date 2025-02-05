using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DartsScorer.Web.Models;
using DartsScorer.Web.Views.Checkout;

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
        var calculator = new DartsScorer.Main.Checkout();
        string[] result = new string[] { };
        
        try 
        {
            result = calculator.Calculate(score);
        }
        catch (ArgumentException)
        {
        }
        
        var model = new CheckoutResultModel()
        {
            Score = score,
            Result = result
        };
        
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
