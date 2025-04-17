using DartsScorer.Main.Match.x01;

namespace DartsScorer.Web.Services;

/// <summary>
/// Interface for managing X01 matches.
/// </summary>
public interface IX01Service
{
    /// <summary>
    /// Creates a new X01 match or resets an existing one.
    /// </summary>
    /// <param name="requiredScore">The required score to win the match.</param>
    /// <param name="reset">Indicates whether to reset the match.</param>
    /// <returns>The created or reset match.</returns>
    Match Create(int requiredScore, bool reset);

    /// <summary>
    /// Retrieves the current X01 match.
    /// </summary>
    /// <returns>The current match, or null if no match exists.</returns>
    Match Get();

    /// <summary>
    /// Adds a player to the current X01 match.
    /// </summary>
    /// <param name="playerName">The name of the player to add.</param>
    void AddPlayer(string playerName);

    /// <summary>
    /// Starts the current X01 match.
    /// </summary>
    /// <returns>The updated match after starting.</returns>
    Match StartMatch();

    /// <summary>
    /// Processes a throw for the current player in the X01 match.
    /// </summary>
    /// <param name="throwValue">The value of the throw.</param>
    void Throw(string throwValue);
}