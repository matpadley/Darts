using DartsScorer.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace DartsScorer.Web.Controllers;

public class RoundTheBoardController(ILogger<RoundTheBoardController> logger, 
    IRoundTheBoardService dartsMatchService,
    IPlayerService playerService) : Controller
{
    public IActionResult Index()    
    {
        var players = playerService.GetPLayersForDropDown();
        
        if (players.Count == 0)
        {
            playerService.Add("Player 1");
            playerService.Add("Player 2");
            playerService.Add("Player 3");
            playerService.Add("Player 4");
        }
        
        ViewBag.PlayerList = playerService.GetPLayersForDropDown();
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
        playerService.Add(playerName);
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
    public IActionResult Throw(string multiplier, string throwValue)
    {
        dartsMatchService.Throw($"{multiplier}{throwValue}");
        return RedirectToAction("Index");
    }
}
