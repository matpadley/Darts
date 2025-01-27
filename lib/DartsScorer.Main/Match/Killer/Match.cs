using DartsScorer.Main.Player;

namespace DartsScorer.Main.Match.Killer;

public class Match: CommonMatch
{

    public Match()
    {
        DartsMatchType = DartsMatchType.Killer;
    }

    public override string Name { get; } = "Killer";
}