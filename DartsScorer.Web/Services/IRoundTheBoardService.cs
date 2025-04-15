using DartsScorer.Main.Match.RoundTheBoard;
using DartsScorer.Main.Player;
using Microsoft.Extensions.Caching.Memory;

namespace DartsScorer.Web.Services.Development;

/// <summary>
/// Interface for managing Round The Board matches.
/// </summary>
public interface IRoundTheBoardService
{
    /// <summary>
    /// Creates a new Round The Board match or resets an existing one.
    /// </summary>
    /// <param name="reset">Indicates whether to reset the match.</param>
    /// <returns>The created or reset match.</returns>
    Match Create(bool reset);

    /// <summary>
    /// Retrieves the current Round The Board match.
    /// </summary>
    /// <returns>The current match, or null if no match exists.</returns>
    Match Get();

    /// <summary>
    /// Adds a player to the current Round The Board match.
    /// </summary>
    /// <param name="playerName">The name of the player to add.</param>
    void AddPlayer(string playerName);

    /// <summary>
    /// Starts the current Round The Board match.
    /// </summary>
    /// <returns>The updated match after starting.</returns>
    Match StartMatch();

    /// <summary>
    /// Processes a throw for the current player in the Round The Board match.
    /// </summary>
    /// <param name="throwValue">The value of the throw.</param>
    void Throw(string throwValue);
}