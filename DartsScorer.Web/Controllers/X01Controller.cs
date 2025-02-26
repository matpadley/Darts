using DartsScorer.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace DartsScorer.Web.Controllers;

public class X01Controller(ILogger<RoundTheBoardController> logger, 
    IX01Service x01Service,
    IPlayerService playerService) : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    // new action method that takes in an integer parameter and starts a new game of 501
    public IActionResult NewGame(int requiredScore)
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
        return View("Index",x01Service.Create(requiredScore, true));
    }
}
