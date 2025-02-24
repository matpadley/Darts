using DartsScorer.Main.Player;
using DartsScorer.Main.Scoring;

namespace DartsScorer.Main.Match.RoundTheBoard;

public class RoundTheBoardPlayer(string name) : MatchPlayer(new Player.Player(name))
{
    public int RequiredBoardNumber { get; private set; } = 1;

    private const int WinningNumber = 20;
    private bool HasWon { get; set; }
    public override void Throw(BoardScore boardScore, Multiplier multiplier)
    {
        // if the leg is finished return
        if (HasWon)
        {
            EndThrow();
            return;
        }
        
        var newThrow = new ThrowScore(multiplier, boardScore);
        
        // a check to make sure that the leg has started and the leg is not null
        CurrentLeg ??= new Leg();
        
        switch (CurrentLeg?.NextThrow)
        {
            case 1:
                CurrentLeg.ThrowFirst(newThrow);
                UpdateRequiredBoardNumber(newThrow);
                if (HasWon) EndThrow();
                break;
            case 2:
                CurrentLeg.ThrowSecond(newThrow);
                UpdateRequiredBoardNumber(newThrow);
                if (HasWon) EndThrow();
                break;
            case 3:
                CurrentLeg.ThrowThird(newThrow);
                UpdateRequiredBoardNumber(newThrow);
                EndThrow(); 
                break;
        }
    }
    
    private void UpdateRequiredBoardNumber(ThrowScore newThrow)
    {
        if (newThrow.NumberScore == RequiredBoardNumber && !HasWon && WinningNumber != RequiredBoardNumber)
        {
            var nextNumber = newThrow.Score + 1;
            RequiredBoardNumber = nextNumber > 20 ? RequiredBoardNumber : nextNumber;
        }

        if (newThrow.NumberScore == 20 && RequiredBoardNumber == 20)
        {
            HasWon = true;
        }
    }
    
    // add method to end the throw and add the leg to the list of legs
    public override void EndThrow()
    {
        if (CurrentLeg != null)
        {
            Legs.Add(CurrentLeg);
        }
        CurrentLeg = null;
        // CurrentLeg = null; // this is the bit that is causing the set current player leg null
    }

    public override bool Finished()
    {
        return HasWon;
    }
}