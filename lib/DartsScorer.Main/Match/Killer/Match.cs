namespace DartsScorer.Main.Match.Killer;

public class Match: CommonMatch
{

    public Match()
    {
        DartsMatchType = DartsMatchType.Killer;
    }

    public override string Name { get; } = "Killer";
    public override void StartMatch()
    {
        if (CanStartMatch())
        {
            
        }
    }

    public override bool IsMatchComplete { get; }
}