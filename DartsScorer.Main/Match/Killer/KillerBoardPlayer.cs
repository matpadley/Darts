using DartsScorer.Main.Player;
using DartsScorer.Main.Scoring;

namespace DartsScorer.Main.Match.Killer;

/// <summary>
/// Represents a player in a Killer darts match.
/// Killer players have an assigned number and attempt to eliminate other players
/// by hitting their numbers while protecting their own.
/// </summary>
/// <remarks>
/// This class is currently incomplete and should be considered a work in progress.
/// </remarks>
/// <param name="name">The name of the player</param>
public class KillerBoardPlayer(string name) : MatchPlayer(new Player.Player(name))
{
    /// <summary>
    /// Updates the player's state based on the latest throw.
    /// </summary>
    /// <param name="newThrow">The latest throw made by the player</param>
    /// <exception cref="NotImplementedException">This method is not yet implemented</exception>
    /// <remarks>
    /// This method requires implementation to track player's killer status and lives.
    /// </remarks>
    public override void UpdateRequiredBoardNumber(ThrowScore newThrow)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Determines whether this player has finished the match according to Killer game rules.
    /// </summary>
    /// <returns>true if the player has finished; otherwise, false</returns>
    /// <exception cref="NotImplementedException">This method is not yet implemented</exception>
    /// <remarks>
    /// This method should return true when the player has eliminated all other players
    /// or false if the player has been eliminated or the game is still in progress.
    /// </remarks>
    public override bool Finished()
    {
        throw new NotImplementedException();
    }
}