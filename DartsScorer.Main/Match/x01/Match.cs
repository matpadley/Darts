using DartsScorer.Main.Player;

namespace DartsScorer.Main.Match.x01;

public sealed class Match : CommonMatch
{
    public override string Name => "x01";
    public int RequiredScore { get; private set; }
    public override DartsMatchType DartsMatchType => DartsMatchType.X01;

    public Match(MatchConfiguration config, int requiredScore = 5) : base(config)
    {
        if (requiredScore < 1 || requiredScore > 5)
        {
            throw new ArgumentException("Required score must be between 1 and 5");
        }

        RequiredScore = requiredScore * 100 + 1;
    }
    
    public override void StartMatch()
    {
        if (!CanStartMatch()) return;
        SetCurrentPlayer(Players.First());
        MatchInProgress = true;
    }
}
