using DartsScorer.Main.Player;
using DartsScorer.Main.Scoring;

namespace DartsScorer.Main.Match.x01;

public class X01TheBoardPlayer(string name) : MatchPlayer(new Player.Player(name))
{
    public  int RequiredBoardNumber { get; private set; } = 1;
    
    public override void Throw(BoardScore one, Multiplier multiplier)
    {
        var newThrow = new ThrowScore(multiplier, one);

        switch (CurrentLeg?.NextThrow)
        {
            case 1: 
                CurrentLeg.ThrowFirst(newThrow);
                if (newThrow.Score == RequiredBoardNumber)
                {
                    RequiredBoardNumber++;
                }
                break;
            case 2: 
                CurrentLeg.ThrowSecond(newThrow);
                if (newThrow.Score == RequiredBoardNumber)
                {
                    RequiredBoardNumber++;
                }
                break;
            case 3: 
                CurrentLeg.ThrowThird(newThrow);
                if (newThrow.Score == RequiredBoardNumber)
                {
                    RequiredBoardNumber++;
                }
                break;
        }
        
        if (CurrentLeg is { IsComplete: true })
        {
            Legs.Add(CurrentLeg);
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