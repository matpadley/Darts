using DartsScorer.Main.Player;
using DartsScorer.Main.Scoring;

namespace DartsScorer.Main.Match.x01;

public class X01Player(string name, int winningNumber) : MatchPlayer(new Player.Player(name))
{
    public int WinningNumber { get; set; } = winningNumber;

    public int CurrentScore { get; private set; } = winningNumber;
    
    public override void UpdateRequiredBoardNumber(ThrowScore newThrow)
    {
        CurrentScore -= newThrow.Score;
        
        HasWon = CurrentScore == 0;
    }

    public override bool Finished()
    {
        return HasWon;
    }
}