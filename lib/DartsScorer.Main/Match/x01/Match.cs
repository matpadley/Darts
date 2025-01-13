
namespace DartsScorer.Main.Match.x01;

public class Match : CommonMatch
{
    public int RequiredScore { get; private set; }

    public override MatchType MatchType { get; set; } = MatchType.x01;

    public Match(int requiredScore = 5)
    {
        if (requiredScore < 1 || requiredScore > 5)
        {
            throw new ArgumentException("Required score must be between 1 and 5");
        }

        RequiredScore = requiredScore * 100 + 1;
    }
}
