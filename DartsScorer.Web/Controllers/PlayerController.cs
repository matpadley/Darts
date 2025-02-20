using Microsoft.AspNetCore.Mvc;
using DartsScorer.Web.Models.UpdateModels;
using DartsScorer.Web.Services;

namespace DartsScorer.Web.Controllers;

public class PlayerController(ILogger<PlayerController> logger, IPlayerService playerService) : Controller
{
    private readonly ILogger<PlayerController> _logger = logger;

    public IActionResult Index()
    {
        return View(playerService.GetPlayers());
    }
    
    public IActionResult AddPlayer(string name)
    {
        playerService.Add(name);
        return RedirectToAction("Index");
    }
    
    [HttpDelete]
    public IActionResult DeletePlayer([FromBody] EditPlayerModel model)
    {
        playerService.Delete(model.Name);
        
        return RedirectToAction("Index");
    }
    
    // delete action that takes in the player name
    [HttpPost]
    public IActionResult EditPlayer([FromBody] EditPlayerModel model)
    {
        playerService.Edit(model.OldName, model.Name);
        
        return RedirectToAction("Index");
    }
}
