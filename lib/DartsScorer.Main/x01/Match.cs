using DartsScorer.Main.Models;

namespace DartsScorer.Main.x01;

public class Match : MatchBase
{
    public override DartsMatchType MatchType { get; set; } = DartsMatchType.x01;

    public Match()
    {

    }

    public override void AddPlayer(Player player)
    {
        _players.Add(new MatchPlayer(player));
    }
}