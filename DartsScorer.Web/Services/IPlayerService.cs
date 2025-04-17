using DartsScorer.Main.Player;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DartsScorer.Web.Services.Development;

/// <summary>
/// Interface for managing players.
/// </summary>
public interface IPlayerService
{
    /// <summary>
    /// Retrieves all players.
    /// </summary>
    /// <returns>A list of players.</returns>
    IList<Player>? GetPlayers();

    /// <summary>
    /// Adds a new player.
    /// </summary>
    /// <param name="name">The name of the player to add.</param>
    void Add(string name);

    /// <summary>
    /// Deletes a player by name.
    /// </summary>
    /// <param name="name">The name of the player to delete.</param>
    void Delete(string name);

    /// <summary>
    /// Edits a player's name.
    /// </summary>
    /// <param name="oldName">The current name of the player.</param>
    /// <param name="name">The new name of the player.</param>
    void Edit(string oldName, string name);

    /// <summary>
    /// Retrieves players for a dropdown list.
    /// </summary>
    /// <returns>A list of players formatted for a dropdown.</returns>
    IList<SelectListItem> GetPlayersForDropDown();

    /// <summary>
    /// Checks if a player exists by name.
    /// </summary>
    /// <param name="name">The name of the player to check.</param>
    /// <returns>True if the player exists, otherwise false.</returns>
    bool CheckPlayerExists(string name);
}