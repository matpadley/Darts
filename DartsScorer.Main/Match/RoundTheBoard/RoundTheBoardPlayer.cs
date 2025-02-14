using DartsScorer.Main.Player;
using DartsScorer.Main.Scoring;

namespace DartsScorer.Main.Match.RoundTheBoard;

public class RoundTheBoardPlayer(string name) : MatchPlayer(new Player.Player(name))
{
    public int RequiredBoardNumber { get; private set; } = 1;

    private const int WinningNumber = 20;
    private bool HasWon { get; set; }
    public override void StartThrow()
    {
        if (Legs.Any())
        {
            if (Legs.Last().IsComplete == false)
            {
                throw new InvalidOperationException("The last leg has not finished.");
            }
        }
        else if (Legs.Count != 0 && _currentLeg == null)
        {
            throw new InvalidOperationException("The last leg has not finished.");
        }
        
        _currentLeg = new Leg();
    }

    public override void Throw(BoardScore boardScore, Multiplier multiplier)
    {
        HasFinishedLeg = false;
        // if the leg is finished return
        if (HasWon)
        {
            EndThrow();
            return;
        }
        
        var newThrow = new ThrowScore(multiplier, boardScore);
        
        // a check to make sure that the leg has started and the leg is not null
        _currentLeg ??= new Leg();
        
        switch (_currentLeg?.NextThrow)
        {
            case 1:
                _currentLeg.ThrowFirst(newThrow);
                UpdateRequiredBoardNumber(newThrow);
                if (HasWon) EndThrow();
                break;
            case 2:
                _currentLeg.ThrowSecond(newThrow);
                UpdateRequiredBoardNumber(newThrow);
                if (HasWon) EndThrow();
                break;
            case 3:
                _currentLeg.ThrowThird(newThrow);
                UpdateRequiredBoardNumber(newThrow);
                HasFinishedLeg = true;
                if (HasWon) EndThrow();
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
        
        HasWon = newThrow.NumberScore == 20 && RequiredBoardNumber == 20;
    }
    
    // add method to end the throw and add the leg to the list of legs
    public override void EndThrow()
    {
        //HasFinishedLeg = true;
        Legs.Add(_currentLeg);
        _currentLeg = null;
    }

    public override bool Finished()
    {
        HasFinishedLeg = true;
        return HasWon;
    }
}