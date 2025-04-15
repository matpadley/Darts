using Microsoft.AspNetCore.Mvc;
using DartsScorer.Web.Models.UpdateModels;
using DartsScorer.Web.Services;
using DartsScorer.Web.Services.Development;

namespace DartsScorer.Web.Controllers;

public class PlayerController : Controller
{
    private readonly IPlayerService _playerService;

    public PlayerController(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    public IActionResult Index()
    {
        return View(_playerService.GetPlayers());
    }

    [HttpPost]
    public IActionResult AddPlayer(string name)
    {
        _playerService.Add(name);
        return RedirectToAction("Index");
    }

    [HttpDelete]
    public IActionResult DeletePlayer([FromBody] EditPlayerModel model)
    {
        _playerService.Delete(model.Name);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult EditPlayer([FromBody] EditPlayerModel model)
    {
        _playerService.Edit(model.OldName, model.Name);
        return RedirectToAction("Index");
    }
}
