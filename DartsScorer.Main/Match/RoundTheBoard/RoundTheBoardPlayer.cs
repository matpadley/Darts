using DartsScorer.Main.Player;
using DartsScorer.Main.Scoring;

namespace DartsScorer.Main.Match.RoundTheBoard;

/// <summary>
/// Represents a player in a Round The Board (Around the Clock) darts match.
/// Players aim to hit numbers in sequence from 1 to 20.
/// </summary>
/// <param name="name">The name of the player</param>
public class RoundTheBoardPlayer(string name) : MatchPlayer(new Player.Player(name))
{
    /// <summary>
    /// Gets the current board number the player needs to hit.
    /// Players start at 1 and progress through 20.
    /// </summary>
    public int RequiredBoardNumber { get; private set; } = 1;

    /// <summary>
    /// The final number needed to win the game (20).
    /// </summary>
    private const int WinningNumber = 20;
    
    /// <summary>
    /// Updates the player's next required board number based on the latest throw.
    /// If the player hits their required number, they advance to the next number.
    /// </summary>
    /// <param name="newThrow">The latest throw made by the player</param>
    public override void UpdateRequiredBoardNumber(ThrowScore newThrow)
    {
        if (newThrow.Score == WinningNumber && RequiredBoardNumber == 20)
        {
            HasWon = true;
        }
        else if (newThrow.NumberScore == RequiredBoardNumber && !HasWon && WinningNumber != RequiredBoardNumber)
        {
            var nextNumber = newThrow.Score + 1;
            RequiredBoardNumber = nextNumber > 20 ? RequiredBoardNumber : nextNumber;
            HasWon = newThrow.Score == WinningNumber;
        }
    }

    /// <summary>
    /// Determines whether this player has finished the match by hitting all numbers from 1 to 20 in sequence.
    /// </summary>
    /// <returns>true if the player has won; otherwise, false</returns>
    public override bool Finished()
    {
        return HasWon;
    }
}