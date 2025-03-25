using DartsScorer.Web.Models;
using DartsScorer.Web.Services.Development;
using Microsoft.AspNetCore.Mvc;

namespace DartsScorer.Web.Controllers;

public class RoundTheBoardController(IRoundTheBoardService dartsMatchService,
    IPlayerService playerService) : Controller
{
    public IActionResult Index(bool reset = false)    
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
        return View(dartsMatchService.Create(reset));
    }
    
    public IActionResult MatchPlayers()
    {
        return PartialView("MatchPlayers", dartsMatchService.Get());
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
    public IActionResult Throw([FromBody] ThrowModel model)
    {
        dartsMatchService.Throw($"{model.Multiplier}{model.ThrowValue}");
        return RedirectToAction("Index");
    }
}
