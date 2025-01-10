using System;

namespace DartsScorer.Main.Scoring;

public abstract class CommonLeg
{
    public int CurrentScore { get; internal set; }
    public int NextThrow { get; internal set; } = 1;
    public bool IsComplete { get; internal set; }
    public ICollection<ThrowScore> Throws { get; } = new List<ThrowScore>();
    public abstract void ThrowFirst(ThrowScore throwScore);
    public abstract void ThrowSecond(ThrowScore throwScore);
    public abstract void ThrowThird(ThrowScore throwScore);
}
