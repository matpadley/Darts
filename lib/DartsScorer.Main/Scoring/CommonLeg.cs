using System;

namespace DartsScorer.Main.Scoring;

public abstract class CommonLeg
{
    public ICollection<ThrowScore> Throws { get; } = new List<ThrowScore>();

    public abstract void ThrowFirst(ThrowScore throwScore);
    public abstract void ThrowSecond(ThrowScore throwScore);
    public abstract void ThrowThird(ThrowScore throwScore);
}
