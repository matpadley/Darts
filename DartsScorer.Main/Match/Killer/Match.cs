using DartsScorer.Main.Player;

namespace DartsScorer.Main.Match.Killer;

public class Match: CommonMatch
{ 
    public override DartsMatchType DartsMatchType => DartsMatchType.Killer;
    public override string Name { get; } = "Killer";
    public override void StartMatch()
    {
        if (CanStartMatch())
        {
            
        }
    }

    public override bool IsMatchComplete { get; }
    public override MatchPlayer Winner { get; }
}