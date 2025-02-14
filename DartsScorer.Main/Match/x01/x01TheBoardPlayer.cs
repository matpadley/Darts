using DartsScorer.Main.Player;
using DartsScorer.Main.Scoring;

namespace DartsScorer.Main.Match.x01;

public class X01TheBoardPlayer(string name) : MatchPlayer(new Player.Player(name))
{
    public  int RequiredBoardNumber { get; private set; } = 1;
    
    public override void StartThrow()
    {
        _currentLeg = new Leg();
    }

    public override void Throw(BoardScore one, Multiplier multiplier)
    {
        var newThrow = new ThrowScore(multiplier, one);

        switch (_currentLeg?.NextThrow)
        {
            case 1: 
                _currentLeg.ThrowFirst(newThrow);
                if (newThrow.Score == RequiredBoardNumber)
                {
                    RequiredBoardNumber++;
                }
                break;
            case 2: 
                _currentLeg.ThrowSecond(newThrow);
                if (newThrow.Score == RequiredBoardNumber)
                {
                    RequiredBoardNumber++;
                }
                break;
            case 3: 
                _currentLeg.ThrowThird(newThrow);
                if (newThrow.Score == RequiredBoardNumber)
                {
                    RequiredBoardNumber++;
                }
                break;
        }
        
        if (_currentLeg is { IsComplete: true })
        {
            Legs.Add(_currentLeg);
        }
    }

    public override void EndThrow()
    {
        throw new NotImplementedException();
    }

    public override bool Finished()
    {
        throw new NotImplementedException();
    }
}