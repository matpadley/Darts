using DartsScorer.Web.Models;
using DartsScorer.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace DartsScorer.Web.Controllers;

public class X01Controller(IX01Service x01Service,
    IPlayerService playerService) : Controller
{
    // GET
    public IActionResult Index(bool reset = false)
    {        var players = playerService.GetPLayersForDropDown();
        
        if (players.Count == 0)
        {
            playerService.Add("Player 1");
            playerService.Add("Player 2");
            playerService.Add("Player 3");
            playerService.Add("Player 4");
        }
        
        ViewBag.PlayerList = playerService.GetPLayersForDropDown();
        return View( x01Service.Create(5, reset));
    }
    
    public IActionResult MatchPlayers()
    {
        return PartialView("MatchPlayers", x01Service.Get());
    }
    
    [HttpPost]
    public IActionResult AddPlayer(string playerName)
    {
        // Add logic to add the player
        x01Service.AddPlayer(playerName);
        playerService.Add(playerName);
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public IActionResult StartMatch()
    {
        // Add logic to add the player
        x01Service.StartMatch();
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public IActionResult Throw([FromBody] ThrowModel model)
    {
        x01Service.Throw($"{model.Multiplier}{model.ThrowValue}");
        return RedirectToAction("Index");
    }
}
