using DartsScorer.Main.Exceptions;
using DartsScorer.Web.Models;
using DartsScorer.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace DartsScorer.Web.Controllers;

public class RoundTheBoardController : Controller
{
    private readonly IRoundTheBoardService _dartsMatchService;
    private readonly IPlayerService _playerService;
    private readonly ILogger<RoundTheBoardController> _logger;

    public RoundTheBoardController(
        IRoundTheBoardService dartsMatchService,
        IPlayerService playerService,
        ILogger<RoundTheBoardController> logger)
    {
        _dartsMatchService = dartsMatchService;
        _playerService = playerService;
        _logger = logger;
    }
    
    public IActionResult Index(bool reset = false)    
    {
        try
        {
            var players = _playerService.GetPLayersForDropDown();
            
            if (players.Count == 0)
            {
                _playerService.Add("Player 1");
                _playerService.Add("Player 2");
                _playerService.Add("Player 3");
                _playerService.Add("Player 4");
            }
            
            ViewBag.PlayerList = _playerService.GetPLayersForDropDown();
            return View(_dartsMatchService.Create(reset));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while loading Round The Board Index");
            TempData["ErrorMessage"] = "An error occurred while loading the game. Please try again.";
            return RedirectToAction("Error", "Home");
        }
    }
    
    public IActionResult MatchPlayers()
    {
        try
        {
            return PartialView("MatchPlayers", _dartsMatchService.Get());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while loading match players");
            return StatusCode(500, "Failed to load match players");
        }
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddPlayer(string playerName)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(playerName))
            {
                ModelState.AddModelError("playerName", "Player name cannot be empty");
                return RedirectToAction("Index");
            }
            
            // Validate player name contains only safe characters (alphanumeric, spaces, and common punctuation)
            var safeNamePattern = new Regex(@"^[a-zA-Z0-9\s\.\-_]{1,50}$");
            if (!safeNamePattern.IsMatch(playerName))
            {
                ModelState.AddModelError("playerName", "Player name contains invalid characters");
                TempData["ErrorMessage"] = "Player name can only contain letters, numbers, spaces, and simple punctuation";
                return RedirectToAction("Index");
            }
            
            _dartsMatchService.AddPlayer(playerName);
            _playerService.Add(playerName);
            return RedirectToAction("Index");
        }
        catch (ArgumentException)
        {
            _logger.LogWarning("Invalid player name: {PlayerName}", playerName);
            TempData["ErrorMessage"] = "Invalid player name";
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            var sanitizedPlayerName = playerName.Replace("\n", "").Replace("\r", "").Trim();
            _logger.LogError(ex, "Error occurred while adding player: {PlayerName}", sanitizedPlayerName);
            TempData["ErrorMessage"] = "Failed to add player";
            return RedirectToAction("Index");
        }
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult StartMatch()
    {
        try
        {
            _dartsMatchService.StartMatch();
            return RedirectToAction("Index");
        }
        catch (MatchOperationException ex)
        {
            _logger.LogWarning(ex, "Match operation error when starting match");
            TempData["ErrorMessage"] = ex.Message;
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while starting match");
            TempData["ErrorMessage"] = "Failed to start match";
            return RedirectToAction("Index");
        }
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Throw([FromBody] ThrowModel model)
    {
        try
        {
            if (model == null)
            {
                throw new ArgumentException("Throw data is required");
            }
            
            _dartsMatchService.Throw($"{model.Multiplier}{model.ThrowValue}");
            return RedirectToAction("Index");
        }
        catch (InvalidThrowException ex)
        {
            _logger.LogWarning(ex, "Invalid throw: {MultiplierValue} {ThrowValue}", 
                model?.Multiplier, model?.ThrowValue);
            
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return BadRequest(ex.Message);
            }
            
            TempData["ErrorMessage"] = ex.Message;
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while processing throw: {MultiplierValue} {ThrowValue}", 
                model?.Multiplier, model?.ThrowValue);
            
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return StatusCode(500, "Failed to process throw");
            }
            
            TempData["ErrorMessage"] = "Failed to process throw";
            return RedirectToAction("Index");
        }
    }
}
