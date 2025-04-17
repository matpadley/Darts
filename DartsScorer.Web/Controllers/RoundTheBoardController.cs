using DartsScorer.Web.Models;
using DartsScorer.Web.Services;
using DartsScorer.Web.Services.Development;
using Microsoft.AspNetCore.Mvc;

namespace DartsScorer.Web.Controllers;

public class RoundTheBoardController : Controller
{
    private readonly IRoundTheBoardService _dartsMatchService;
    private readonly IPlayerService _playerService;

    public RoundTheBoardController(IRoundTheBoardService dartsMatchService, IPlayerService playerService)
    {
        _dartsMatchService = dartsMatchService;
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
        return View(_dartsMatchService.Create(reset));
    }

    public IActionResult MatchPlayers()
    {
        return PartialView("MatchPlayers", _dartsMatchService.Get());
    }

    [HttpPost]
    public IActionResult AddPlayer(string playerName)
    {
        _dartsMatchService.AddPlayer(playerName);
        _playerService.Add(playerName);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult StartMatch()
    {
        _dartsMatchService.StartMatch();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Throw([FromBody] ThrowModel model)
    {
        _dartsMatchService.Throw($"{model.Multiplier}{model.ThrowValue}");
        return RedirectToAction("Index");
    }
}
