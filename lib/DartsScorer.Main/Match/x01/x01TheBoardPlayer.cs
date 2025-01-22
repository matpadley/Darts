using DartsScorer.Main.Player;
using DartsScorer.Main.Scoring;

namespace DartsScorer.Main.Match.x01;

public class X01TheBoardPlayer(string name) : MatchPlayer(new Player.Player(name))
{
    public  int RequiredBoardNumber { get; private set; } = 1;
    public  ICollection<Leg?> Legs { get; set; } = new List<Leg?>();

    private Leg? _currentLeg;
    
    public void StartThrow()
    {
        _currentLeg = new Leg();
    }

    public void Throw(BoardScore one, Multiplier single)
    {
        var newThrow = new ThrowScore(single, one);

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
        
        if (_currentLeg.IsComplete)
        {
            Legs.Add(_currentLeg);
        }
    }
}