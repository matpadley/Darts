using DartsScorer.Main.Player;
using DartsScorer.Main.Scoring;

namespace DartsScorer.Main.Match.RoundTheBoard;

public class RoundTheBoardPlayer(string name) : MatchPlayer(new Player.Player(name))
{
    public int RequiredBoardNumber { get; private set; } = 1;

    private const int WinningNumber = 20;
    
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

    public override bool Finished()
    {
        return HasWon;
    }
}