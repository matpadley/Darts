using DartsScorer.Main.Player;
using DartsScorer.Main.Scoring;

namespace DartsScorer.Main.Match.RoundTheBoard;

public class RoundTheBoardPlayer(string name) : MatchPlayer(new Player.Player(name))
{
    public  int RequiredBoardNumber { get; private set; } = 1;
    public  ICollection<Leg?> Legs { get; set; } = new List<Leg?>();

    private Leg? _currentLeg;
    
    public void StartThrow()
    {
        // a check to make sure that the last leg has finished
        if (_currentLeg != null)
        {
            throw new InvalidOperationException("The last leg has not finished.");
        }
        _currentLeg = new Leg();
    }

    public void Throw(BoardScore one, Multiplier single)
    {
        var newThrow = new ThrowScore(single, one);
        
        // a check to make sure that the leg has started and the leg is not null
        if (_currentLeg == null)
        {
            throw new InvalidOperationException("The leg has not started.");
        }
        
        // if a new throw is attempted after the thrird throw throw and error
        if (_currentLeg.Throws.Count == 3)
        {
            throw new InvalidOperationException("The leg has been completed.");
        }

        switch (_currentLeg?.NextThrow)
        {
            case 1:
                _currentLeg.ThrowFirst(newThrow);
                if (newThrow.Score == RequiredBoardNumber)
                {
                    RequiredBoardNumber ++;
                }
                break;
            case 2:
                _currentLeg.ThrowSecond(newThrow);
                if (newThrow.Score == RequiredBoardNumber)
                {
                    RequiredBoardNumber ++;
                }
                break;
            case 3:
                _currentLeg.ThrowThird(newThrow);
                if (newThrow.Score == RequiredBoardNumber)
                {
                    RequiredBoardNumber ++;
                }
                break;
        }
    }
    
    // add method to end the throw and add the leg to the list of legs
    public void EndThrow()
    {
        if (_currentLeg == null)
        {
            throw new InvalidOperationException("The leg has not started.");
        }
        
        // a check to make sure that 3 throws have happened
        if (_currentLeg.Throws.Count != 3)
        {
            throw new InvalidOperationException("The leg has not been completed.");
        }

        Legs.Add(_currentLeg);
        _currentLeg = null;
    }
}