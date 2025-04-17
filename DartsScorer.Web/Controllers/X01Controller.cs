using DartsScorer.Web.Models;
using DartsScorer.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Text.RegularExpressions;

namespace DartsScorer.Web.Controllers;

public class X01Controller : Controller
{
    private readonly IX01Service _x01Service;
    private readonly IPlayerService _playerService;
    private readonly ILogger<X01Controller> _logger;

    public X01Controller(
        IX01Service x01Service,
        IPlayerService playerService,
        ILogger<X01Controller> logger)
    {
        _x01Service = x01Service;
        _playerService = playerService;
        _logger = logger;
    }
    
    // GET
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
            return View(_x01Service.Create(5, reset));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while loading X01 Index");
            TempData["ErrorMessage"] = "An error occurred while loading the game. Please try again.";
            return RedirectToAction("Error", "Home");
        }
    }
    
    public IActionResult MatchPlayers()
    {
        try
        {
            return PartialView("MatchPlayers", _x01Service.Get());
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
                TempData["ErrorMessage"] = "Player name cannot be empty";
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
            
            _x01Service.AddPlayer(playerName);
            _playerService.Add(playerName);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while adding player: {PlayerName}", playerName);
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
            _x01Service.StartMatch();
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
            
            _x01Service.Throw($"{model.Multiplier}{model.ThrowValue}");
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
