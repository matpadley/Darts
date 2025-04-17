using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DartsScorer.Web.Models;
using Microsoft.Extensions.Logging;

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
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CheckoutResult(int score)
    {
        try
        {
            // Validate score range (darts checkout scores are between 2-170)
            if (score < 2 || score > 170)
            {
                _logger.LogWarning("Invalid checkout score requested: {Score}", score);
                TempData["ErrorMessage"] = "Please enter a valid score between 2 and 170";
                return RedirectToAction("Index");
            }
            
            var calculator = new Main.Checkout.CheckoutCalculator();
            var results = calculator.Calculate(score);
            
            if (results == null || results.Length == 0)
            {
                _logger.LogInformation("No checkout found for score: {Score}", score);
                return View("NoCheckout");
            }
            
            var model = new CheckoutResultModel
            {
                Score = score,
                Results = results
            };
        
            return View(model);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error calculating checkout for score: {Score}", score);
            TempData["ErrorMessage"] = "An error occurred while calculating checkout";
            return RedirectToAction("Index");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
