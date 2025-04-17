using DartsScorer.Main.Player;

namespace DartsScorer.Main.Match.RoundTheBoard;

/// <summary>
/// Implements the "Round The Board" variant of darts, also known as "Around the Clock".
/// Players attempt to hit numbers in sequence from 1 to 20.
/// The first player to hit all numbers in sequence wins.
/// </summary>
public sealed class Match : CommonMatch
{
    /// <summary>
    /// Gets the display name of the match type.
    /// </summary>
    public override string Name => "Round The Board";
    
    /// <summary>
    /// Gets the match type (RoundTheBoard).
    /// </summary>
    public override DartsMatchType DartsMatchType => DartsMatchType.RoundTheBoard;
    
    /// <summary>
    /// Starts the Round The Board match if there are players registered.
    /// Sets the first player as the current player and marks the match as in progress.
    /// </summary>
    public override void StartMatch()
    {
        if (!CanStartMatch()) return;
        SetCurrentPlayer(Players.First());
        MatchInProgress = true;
    }
}