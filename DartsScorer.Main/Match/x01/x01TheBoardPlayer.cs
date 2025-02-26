using DartsScorer.Main.Player;
using DartsScorer.Main.Scoring;

namespace DartsScorer.Main.Match.x01;

public class X01Player(string name, int winningNumber) : MatchPlayer(new Player.Player(name))
{
    public int WinningNumber { get; set; } = winningNumber;

    public int RemainingScore { get; private set; } = winningNumber;
    
    public int CurrentScore() => WinningNumber - RemainingScore;
    
    
    public override void UpdateRequiredBoardNumber(ThrowScore newThrow)
    {
        RemainingScore -= newThrow.Score;
        
        HasWon = RemainingScore == 0;
    }

    public override bool Finished()
    {
        return HasWon;
    }
}