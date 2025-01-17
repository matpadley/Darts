using DartsScorer.Main.Scoring;

namespace DartsScorer.Main.Match;

public class Leg : CommonLeg
{
    public override void ThrowFirst(ThrowScore throwScore)
    {
        if (NextThrow != 1)
        {
            throw new InvalidOperationException("First throw already thrown");
        }

        CurrentScore += throwScore.Score;
        NextThrow = 2;
        Throws.Add(throwScore);
    }

    public override void ThrowSecond(ThrowScore throwScore)
    {
        if (NextThrow != 2)
        {
            throw new InvalidOperationException("Second can only be thrown on the next throw of 2");
        }

        CurrentScore += throwScore.Score;
        NextThrow = 3;
        Throws.Add(throwScore);
    }

    public override void ThrowThird(ThrowScore throwScore)
    {
        if (NextThrow != 3)
        {
            throw new InvalidOperationException("Third can only be thrown on the next throw of 3");
        }

        CurrentScore += throwScore.Score;
        Throws.Add(throwScore);
        IsComplete = true;
    }
}
