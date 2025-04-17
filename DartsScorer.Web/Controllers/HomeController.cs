using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DartsScorer.Web.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace DartsScorer.Web.Controllers;

public class HomeController() : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(int? code, string? message)
    {
        var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
        var error = new ErrorViewModel 
        { 
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier 
        };
        
        if (code.HasValue)
        {
            error.StatusCode = code.Value;
        }
        
        if (!string.IsNullOrEmpty(message))
        {
            error.Message = message;
        }
        else if (exceptionHandlerPathFeature?.Error != null)
        {
            error.Message = exceptionHandlerPathFeature.Error.Message;
            
            // Only show detailed error information in development
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                error.ShowDetails = true;
                error.Details = exceptionHandlerPathFeature.Error.StackTrace;
            }
        }
        
        return View(error);
    }
}
