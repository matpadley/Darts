using Microsoft.AspNetCore.Mvc;
using DartsScorer.Web.Models.UpdateModels;
using DartsScorer.Web.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Text.RegularExpressions;

namespace DartsScorer.Web.Controllers;

public class PlayerController : Controller
{
    private readonly IPlayerService _playerService;
    private readonly ILogger<PlayerController> _logger;

    public PlayerController(IPlayerService playerService, ILogger<PlayerController> logger)
    {
        _playerService = playerService;
        _logger = logger;
    }
    
    public IActionResult Index()
    {
        try
        {
            return View(_playerService.GetPlayers());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while loading players");
            TempData["ErrorMessage"] = "Failed to load players";
            return RedirectToAction("Error", "Home");
        }
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddPlayer(string name)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                ModelState.AddModelError("name", "Player name cannot be empty");
                TempData["ErrorMessage"] = "Player name cannot be empty";
                return RedirectToAction("Index");
            }
            
            // Validate player name contains only safe characters (alphanumeric, spaces, and common punctuation)
            var safeNamePattern = new Regex(@"^[a-zA-Z0-9\s\.\-_]{1,50}$");
            if (!safeNamePattern.IsMatch(name))
            {
                ModelState.AddModelError("name", "Player name contains invalid characters");
                TempData["ErrorMessage"] = "Player name can only contain letters, numbers, spaces, and simple punctuation";
                return RedirectToAction("Index");
            }
            
            _playerService.Add(name);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while adding player: {Name}", name);
            TempData["ErrorMessage"] = "Failed to add player";
            return RedirectToAction("Index");
        }
    }
    
    [HttpDelete]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePlayer([FromBody] EditPlayerModel model)
    {
        try
        {
            if (model == null || string.IsNullOrWhiteSpace(model.Name))
            {
                return BadRequest("Player name is required");
            }
            
            // Validate player name contains only safe characters (alphanumeric, spaces, and common punctuation)
            var safeNamePattern = new Regex(@"^[a-zA-Z0-9\s\.\-_]{1,50}$");
            if (!safeNamePattern.IsMatch(model.Name))
            {
                return BadRequest("Player name contains invalid characters");
            }
            
            _playerService.Delete(model.Name);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while deleting player: {Name}", model?.Name);
            return StatusCode(500, "Failed to delete player");
        }
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditPlayer([FromBody] EditPlayerModel model)
    {
        try
        {
            if (model == null || string.IsNullOrWhiteSpace(model.Name) || string.IsNullOrWhiteSpace(model.OldName))
            {
                return BadRequest("Both old and new player names are required");
            }
            
            // Validate player names contain only safe characters (alphanumeric, spaces, and common punctuation)
            var safeNamePattern = new Regex(@"^[a-zA-Z0-9\s\.\-_]{1,50}$");
            if (!safeNamePattern.IsMatch(model.Name) || !safeNamePattern.IsMatch(model.OldName))
            {
                return BadRequest("Player name contains invalid characters");
            }
            
            _playerService.Edit(model.OldName, model.Name);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while editing player: {OldName} to {NewName}", 
                model?.OldName, model?.Name);
            return StatusCode(500, "Failed to edit player");
        }
    }
}
