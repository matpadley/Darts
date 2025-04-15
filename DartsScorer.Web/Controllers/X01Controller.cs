using DartsScorer.Web.Models;
using DartsScorer.Web.Services;
using DartsScorer.Web.Services.Development;
using Microsoft.AspNetCore.Mvc;

namespace DartsScorer.Web.Controllers;

public class X01Controller : Controller
{
    private readonly IX01Service _x01Service;
    private readonly IPlayerService _playerService;

    public X01Controller(IX01Service x01Service, IPlayerService playerService)
    {
        _x01Service = x01Service;
        _playerService = playerService;
    }

    public IActionResult Index(bool reset = false)
    {
        var players = _playerService.GetPlayersForDropDown();

        if (players.Count == 0) // Corrected the method call
        {
            _playerService.Add("Player 1");
            _playerService.Add("Player 2");
            _playerService.Add("Player 3");
            _playerService.Add("Player 4");
        }

        ViewBag.PlayerList = _playerService.GetPlayersForDropDown();
        return View(_x01Service.Create(5, reset));
    }

    public IActionResult MatchPlayers()
    {
        return PartialView("MatchPlayers", _x01Service.Get());
    }

    [HttpPost]
    public IActionResult AddPlayer(string playerName)
    {
        _x01Service.AddPlayer(playerName);
        _playerService.Add(playerName);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult StartMatch()
    {
        _x01Service.StartMatch();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Throw([FromBody] ThrowModel model)
    {
        _x01Service.Throw($"{model.Multiplier}{model.ThrowValue}");
        return RedirectToAction("Index");
    }
}
