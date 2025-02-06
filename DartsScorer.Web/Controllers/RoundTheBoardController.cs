using DartsScorer.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace DartsScorer.Web.Controllers;

public class RoundTheBoardController(ILogger<RoundTheBoardController> logger, 
    IRoundTheBoardService dartsMatchService) : Controller
{
    public IActionResult Index()
    {
        return View(dartsMatchService.Create());
    }
    
    public IActionResult MatchPlayers()
    {
        return PartialView("MatchPlayers",dartsMatchService.GetPlayers());
    }
    
    [HttpPost]
    public IActionResult AddPlayer(string playerName)
    {
        // Add logic to add the player
        dartsMatchService.AddPlayer(playerName);
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public IActionResult StartMatch()
    {
        // Add logic to add the player
        dartsMatchService.StartMatch();
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public IActionResult Throw(string throwValue)
    {
        dartsMatchService.Throw(throwValue);
        return RedirectToAction("Index");
    }
}