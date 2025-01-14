using DartsScorer.Main.Models;

namespace DartsScorer.Main.Killer;

public class Match: MatchBase
{
    public override DartsMatchType MatchType { get; set; } = DartsMatchType.Killer;

    public Match()
    {

    }

    public override void AddPlayer(Player player)
    {
       
    }
}