using DartsScorer.Main.Player;
using DartsScorer.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DartsScorer.Web.Controllers;

public class RoundTheBoardController(ILogger<RoundTheBoardController> logger, 
    IRoundTheBoardService dartsMatchService,
    IPlayerService playerService) : Controller
{
    public IActionResult Index()    
    {
        var players = playerService.GetPLayersForDropDown();
        ViewBag.PlayerList = players;
        return View(dartsMatchService.Create());
    }
    
    public IActionResult MatchPlayers()
    {
        return PartialView("MatchPlayers",dartsMatchService.GetPlayers());
    }
    
    [HttpPost]
    public IActionResult AddPlayer(string playerName)
    {
        if (playerService.CheckPlayerExisits(playerName) |
            dartsMatchService.GetPlayers().Any(f => f.Name == playerName))
        {
            return RedirectToAction("Index");
        }
        
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
    //public IActionResult Throw(string throwValue)
    {
        dartsMatchService.Throw($"{multiplier}{throwValue}");
        return RedirectToAction("Index");
    }
}

public class ThrowModel
{
    public string ThrowValue { get; set; }
    public string Multiplyer { get; set; }

    public override string ToString()
    {
        return $"{ThrowValue}{Multiplyer}";
    }
}