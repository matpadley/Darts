using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DartsScorer.Web.Models;
using DartsScorer.Web.Services;

namespace DartsScorer.Web.Controllers;

public class PlayerController(ILogger<PlayerController> logger, IPLayerService playerService) : Controller
{
    private readonly ILogger<PlayerController> _logger = logger;

    public IActionResult Index()
    {
        return View(playerService.GetPLayers());
    }
    
    public IActionResult AddPlayer(string name)
    {
        playerService.AddP(name);
        return RedirectToAction("Index");
    }
    
    // delete action that takes in the player name
    public IActionResult DeletePlayer(string name)
    {
        playerService.Delete(name);
        
        return RedirectToAction("Index");
    }
    
    // delete action that takes in the player name
    public IActionResult EditPlayer(string name, string oldName)
    {
        playerService.Edit(oldName, name);
        
        return RedirectToAction("Index");
    }
}
