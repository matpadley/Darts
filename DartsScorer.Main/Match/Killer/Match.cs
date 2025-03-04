using DartsScorer.Main.Player;

namespace DartsScorer.Main.Match.Killer;

public class Match(MatchConfiguration config) : CommonMatch(config)
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