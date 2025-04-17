using DartsScorer.Main.Player;

namespace DartsScorer.Main.Match.Killer;

/// <summary>
/// Implements the Killer variant of darts.
/// In Killer, each player assigns themselves a number by hitting a number on the board.
/// Players then attempt to "kill" their opponents by hitting their assigned numbers.
/// </summary>
/// <remarks>
/// This class is currently incomplete and should be considered a work in progress.
/// </remarks>
public class Match: CommonMatch
{ 
    /// <summary>
    /// Gets the match type (Killer).
    /// </summary>
    public override DartsMatchType DartsMatchType => DartsMatchType.Killer;

    /// <summary>
    /// Gets the display name of the match type.
    /// </summary>
    public override string Name => "Killer";

    /// <summary>
    /// Starts the Killer match if there are players registered.
    /// </summary>
    /// <remarks>
    /// This method is currently incomplete and requires further implementation.
    /// </remarks>
    public override void StartMatch()
    {
        if (CanStartMatch())
        {
            // TODO: Implement match start logic for Killer game
        }
    }
}