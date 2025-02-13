namespace DartsScorer.Main.Match.x01;

public class Match : CommonMatch
{
    public int RequiredScore { get; private set; } = 501;

    public Match()
    {
        DartsMatchType = DartsMatchType.X01;
    }

    public Match(int requiredScore = 5)
    {
        if (requiredScore < 1 || requiredScore > 5)
        {
            throw new ArgumentException("Required score must be between 1 and 5");
        }

        RequiredScore = requiredScore * 100 + 1;
    }

    public override string Name { get; } = "x01";
    public override void StartMatch()
    {
        if (CanStartMatch())
        {
            
        }
    }

    public virtual bool IsMatchComplete { get; }
}
