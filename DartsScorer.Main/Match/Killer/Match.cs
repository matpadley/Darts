using DartsScorer.Main.Player;

namespace DartsScorer.Main.Match.Killer;

public sealed class Match: CommonMatch
{ 
    public override DartsMatchType DartsMatchType => DartsMatchType.Killer;

    public override string Name => "Killer";

    public override void StartMatch()
    {
        if (CanStartMatch())
        {
            
        }
    }
}